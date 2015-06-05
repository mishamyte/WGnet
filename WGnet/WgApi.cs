using System.Collections.Generic;
using System.Text;
using WGnet.Categories;
using WGnet.Utils;

namespace WGnet
{
    public class WgApi
    {
        private readonly string _applicationId;
        private const string DefaultUrl = "https://api.worldoftanks.ru/wot/"; //TEMP

        public AccountCategory Account { get; private set; }

        public WgApi(string applicationId)
        {
            _applicationId = applicationId;

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

        private string GetApiUrl(string methodName, IDictionary<string, string> values)
        {
            var builder = new StringBuilder();

            builder.AppendFormat("{0}{1}", DefaultUrl, methodName);

            builder.AppendFormat("?application_id={0}", _applicationId);

            foreach (var pair in values)
                builder.AppendFormat("&{0}={1}", pair.Key, pair.Value);

            return builder.ToString();
        }
    }
}
