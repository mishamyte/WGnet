using System;
using System.Linq.Expressions;
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

        public static void ThrowIfNumberIsNegative(Expression<Func<long?>> expr)
        {
            var result = ThrowIfNumberIsNegative<Func<long?>>(expr);

            string name = result.Item1;
            long? value = result.Item2();

            if (value.HasValue && value < 0) throw new ArgumentException("Отрицательное значение.", name);
        }

        public static void ThrowIfNumberIsNegative(Expression<Func<long>> expr)
        {
            var result = ThrowIfNumberIsNegative<Func<long>>(expr);

            var name = result.Item1;
            long value = result.Item2();

            if (value < 0) throw new ArgumentException("Отрицательное значение.", name);
        }

        private static Tuple<string, T> ThrowIfNumberIsNegative<T>(Expression<T> expr)
        {
            if (expr == null)
                throw new ArgumentNullException("expr");

            string name = string.Empty;

            // Если значение передается из вызывающего метода
            var unary = expr.Body as UnaryExpression;
            if (unary != null)
            {
                var member = unary.Operand as MemberExpression;
                if (member != null)
                {
                    name = member.Member.Name;
                }
            }

            // Если в метод передается значение напрямую
            var body = expr.Body as MemberExpression;
            if (body != null)
            {
                name = body.Member.Name;
            }

            T func = expr.Compile();

            return new Tuple<string, T>(name, func);
        }
    }
}
