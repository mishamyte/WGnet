using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using WGnet.Categories;
using WGnet.Enums;
using WGnet.Utils;

namespace WGnet
{
    //TODO: Create settings class, which will consist info like APIUrl, RequestProtocol etc.
    /// <summary>
    /// API для работы с WG. Выступает в качестве фабрики для различных категорий API
    /// </summary>
    public class WgApi
    {
        private readonly string _applicationId;
        private readonly string _apiUrl;
        private readonly RequestProtocol _protocol;

        /// <summary>
        /// API для работы с методами WoT
        /// </summary>
        public WoTCategory WoT { get; private set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="WgApi"/>.
        /// <param name="applicationId">ID приложения, полученное у WG</param>
        /// </summary>
        public WgApi(string applicationId) : this(applicationId, Region.RU)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="WgApi"/>.
        /// <param name="applicationId">ID приложения, полученное у WG.</param>
        /// <param name="region">Кластер, с которым будет идти работа.</param>
        /// </summary>
        public WgApi(string applicationId, Region region)
        {
            _applicationId = applicationId;
            _apiUrl = GetEnumDescription(region);
            _protocol = RequestProtocol.HTTPS; //TODO: remove to settings class
            WoT = new WoTCategory(this);
        }

        internal string Call(string methodName, IDictionary<string, string> parameters)
        {
            string url = GetApiUrl(methodName, parameters);
            var request = new WgRequest(url);
            string answer = request.GetResponse();

            WgErrors.IfErrorThrowException(answer);
            return answer;
        }

        private string GetApiUrl(string methodName, IEnumerable<KeyValuePair<string, string>> values)
        {
            var builder = new StringBuilder();

            builder.AppendFormat("{0}://{1}{2}",Enum.GetName(typeof(RequestProtocol), _protocol).ToLower(), _apiUrl, methodName);

            builder.AppendFormat("?application_id={0}", _applicationId);

            foreach (var pair in values)
                builder.AppendFormat("&{0}={1}", pair.Key, pair.Value);

            return builder.ToString();
        }

        private static string GetEnumDescription(Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());

            var attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }
    }
}
