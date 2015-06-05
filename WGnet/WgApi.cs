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
    public class WgApi
    {
        private readonly string _applicationId;
        private readonly string _apiUrl;
        private readonly RequestProtocol _protocol;

        public AccountCategory Account { get; private set; }

        public WgApi(string applicationId) : this(applicationId, Region.RU)
        {
        }

        public WgApi(string applicationId, Region region)
        {
            _applicationId = applicationId;
            _apiUrl = GetEnumDescription(region);
            _protocol = RequestProtocol.HTTPS; //TODO: remove to settings class
            Account = new AccountCategory(this);
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
