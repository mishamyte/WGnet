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
                    throw new FieldNotSpecifiedException("Не заполнено обязательное поле " + response["field"], code);
                case 407:
                    throw new InvalidOrLimitException(message, code, (string)response["field"], (string)response["value"]);
                default:
                    throw new WgApiException(message);
            }
        }
    }
}
