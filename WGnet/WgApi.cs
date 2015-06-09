using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using WGnet.Categories;
using WGnet.Enums;
using WGnet.Utils;

namespace WGnet
{
    //TODO: Create settings class, which will contain info like APIUrl, RequestProtocol etc.
    /// <summary>
    /// API для работы с WG. Выступает в качестве фабрики для различных категорий API
    /// </summary>
    public class WgApi
    {
        private readonly string _applicationId;
        private readonly string _apiDomain;
        private readonly RequestProtocol _protocol;

        /// <summary>
        /// API для работы с методами WoT
        /// </summary>
        public WoTCategory WoT { get; private set; }

        /// <summary>
        /// API для работы с методами сервисом Wargaming.NET
        /// </summary>
        public WGNCategory WGN { get; private set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="WgApi"/>.
        /// <param name="applicationId">ID приложения, полученное у WG</param>
        /// </summary>
        public WgApi(string applicationId)
            : this(applicationId, WgRegion.RU)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="WgApi"/>.
        /// <param name="applicationId">ID приложения, полученное у WG</param>
        /// <param name="region">Кластер, с которым будет идти работа</param>
        /// </summary>
        public WgApi(string applicationId, WgRegion region)
        {
            _applicationId = applicationId;
            _apiDomain = region.GetEnumDescription();
            _protocol = RequestProtocol.HTTPS; //TODO: remove to settings class
            WoT = new WoTCategory(this);
            WGN = new WGNCategory(this);
        }

        internal string Call(string methodName, Enum section, IDictionary<string, string> parameters)
        {
            string url = GetApiUrl(methodName, section, parameters);
            var request = new WgRequest(url);
            string answer = request.GetResponse();

            WgErrors.IfErrorThrowException(answer);
            return answer;
        }

        private string GetApiUrl(string methodName, Enum section, IEnumerable<KeyValuePair<string, string>> values)
        {
            var builder = new StringBuilder();

            builder.AppendFormat("{0}://{1}{2}/{3}/{4}", Enum.GetName(typeof(RequestProtocol), _protocol).ToLower(), section.GetEnumDescription(), _apiDomain, Enum.GetName(typeof(WgSection), section).ToLower(), methodName);

            builder.AppendFormat("?application_id={0}", _applicationId);

            foreach (var pair in values)
                builder.AppendFormat("&{0}={1}", pair.Key, pair.Value);

            #if DEBUG && !UNIT_TEST
            Trace.WriteLine(builder.ToString());
            #endif

            return builder.ToString();
        }
    }
}
