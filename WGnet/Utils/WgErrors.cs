using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WGnet.Exceptions;

namespace WGnet.Utils
{
    internal sealed class WgErrors
    {
        public static void IfErrorThrowException(string json)
        {
            JObject obj;
            try
            {
                obj = JObject.Parse(json);
            }
            catch (JsonReaderException ex)
            {                
                throw new WgApiException("Wrong json data",ex);
            }

            var response = obj["error"];
            if (response == null)
                return;

            var code = (int)response["code"];
            var message = (string)response["message"];

            switch (code)
            {
                case 402:
                    throw new WgFieldNotSpecifiedException("Не заполнено обязательное поле " + response["field"] + ".", code);
                case 404:
                    throw new WgNotFoundException(message, code, (string)response["field"], (string)response["value"]);
                case 405:
                    throw new WgMethodDisabledException("Указаный метод API отключён.", code);
                case 407:
                    throw new WgInvalidOrLimitException(message, code, (string)response["field"], (string)response["value"]);
                case 504:
                    throw new WgSourceNotAvailableException("Источник данных не доступен.", code);
                default:
                    throw new WgApiException(message);
            }
        }
    }
}
