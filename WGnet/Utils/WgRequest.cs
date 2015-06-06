using System.IO;
using System.Net;

namespace WGnet.Utils
{
    /// <summary>
    /// Класс для работы с запросами на WG API
    /// </summary>
    public class WgRequest
    {
        private readonly WebRequest _request;

        private WgRequest()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="WgRequest"/>
        /// </summary>
        /// <param name="requestUri"></param>
        public WgRequest(string requestUri)
        {
            _request = WebRequest.Create(requestUri);
        }

        /// <summary>
        /// Получение ответа сервера
        /// </summary>
        /// <returns>Строку ответа сервера</returns>
        public string GetResponse()
        {
            var response = _request.GetResponse();

            var responseStream = response.GetResponseStream();
            string result;
            using (var reader = new StreamReader(responseStream))
            {
                result = reader.ReadToEnd();
            }
            response.Close();

            return result;
        }
    }
}
