using System.IO;
using System.Net;

namespace WGnet.Utils
{
    public class WgRequest
    {
        private readonly WebRequest _request;

        private WgRequest()
        {
        }

        public WgRequest(string requestUri)
        {
            _request = WebRequest.Create(requestUri);
        }

        public string GetResponse()
        {
            var response = _request.GetResponse();

            var responseStream = response.GetResponseStream();
            string result = string.Empty;
            using (var reader = new StreamReader(responseStream))
            {
                result = reader.ReadToEnd();
            }
            response.Close();

            return result;
        }
    }
}
