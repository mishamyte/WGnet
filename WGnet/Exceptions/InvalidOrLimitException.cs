using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WGnet.Exceptions
{
    [Serializable]
    public class InvalidOrLimitException : WgApiException
    {
        /// <summary>
        /// Код ошибки, полученный от сервера WG.
        /// Поле, в котором ошибка
        /// Ошибочное значение
        /// </summary>
        public int ErrorCode { get; private set; }
        public string ErrorField { get; private set; }
        public string ErrorValue { get; private set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="InvalidOrLimitException"/>.
        /// </summary>
        public InvalidOrLimitException()
        {            
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="InvalidOrLimitException"/> с указанным описанием.
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        public InvalidOrLimitException(string message) : base(message)
        {
        }


        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="InvalidOrLimitException"/> с указанным описанием и кодом ошибки.
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="code">Код ошибки, полученный от сервера WG.</param>
        public InvalidOrLimitException(string message, int code)
            : base(message)
        {
            ErrorCode = code;
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="InvalidOrLimitException"/> с указанным описанием и кодом ошибки.
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="field">Поле, в котором ошибка</param>
        /// <param name="code">Код ошибки, полученный от сервера WG.</param>
        public InvalidOrLimitException(string message, int code, string field)
            : base(GetMessage(message, field))
        {
            ErrorCode = code;
            ErrorField = field;
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="InvalidOrLimitException"/> с указанным описанием и кодом ошибки.
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="field">Поле, в котором ошибка</param>
        /// <param name="value">Ошибочное значение</param>
        /// <param name="code">Код ошибки, полученный от сервера WG.</param>
        public InvalidOrLimitException(string message,  int code, string field, string value)
            : base(GetMessage(message, field))
        {
            ErrorCode = code;
            ErrorField = field;
            ErrorValue = value;
        }


        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="InvalidOrLimitException"/> с указанным описанием.
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="innerException">Внутреннее исключение.</param>
        public InvalidOrLimitException(string message, Exception innerException) : base(message, innerException)
        {            
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="InvalidOrLimitException"/> с указанным описанием, кодом ошибки и внутренним исключением.
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="code">Код ошибки, полученный от сервера WG.</param>
        /// <param name="innerException">Внутреннее исключение.</param>
        public InvalidOrLimitException(string message, int code, Exception innerException) : base(message, innerException)
        {
            ErrorCode = code;
        }


        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="InvalidOrLimitException"/> с указанным описанием, кодом ошибки, полем, в котором ошибка и внутренним исключением.
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="code">Код ошибки, полученный от сервера WG.</param>
        /// <param name="field">Поле, в котором ошибка</param>
        /// <param name="innerException">Внутреннее исключение.</param>
        public InvalidOrLimitException(string message, int code, string field, Exception innerException)
            : base(GetMessage(message, field), innerException)
        {
            ErrorCode = code;
            ErrorField = field;
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="InvalidOrLimitException"/> с указанным описанием, кодом ошибки,полем, в котором ошибка, значением ошибки и внутренним исключением.
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="code">Код ошибки, полученный от сервера WG.</param>
        /// <param name="field">Поле, в котором ошибка</param>
        /// <param name="value">Ошибочное значение</param>
        /// <param name="innerException">Внутреннее исключение.</param>
        public InvalidOrLimitException(string message, int code, string field, string value, Exception innerException)
            : base(GetMessage(message, field), innerException)
        {
            ErrorCode = code;
            ErrorField = field;
            ErrorValue = value;
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="InvalidOrLimitException"/> на основе ранее сериализованных данных.
        /// </summary>
        /// <param name="info">Содержит все данные, необходимые для десериализации.</param>
        /// <param name="context">Описывает источник и назначение данного сериализованного потока и предоставляет дополнительный, 
        /// определяемый вызывающим, контекст.</param>
        protected InvalidOrLimitException(SerializationInfo info, StreamingContext context) : base(info, context)
        {            
        }

        private static string GetMessage(string errorMessage, string errorField)
        {
            if (errorMessage.Equals("APPLICATION_IS_BLOCKED")) return "Приложение заблокировано администрацией.";
            if (errorMessage.Equals("INVALID_APPLICATION_ID")) return "Неверный идентификатор приложения.";
            if (errorMessage.Equals("INVALID_IP_ADDRESS")) return "Недопустимый IP-адрес для серверного приложения.";
            if (errorMessage.Equals("REQUEST_LIMIT_EXCEEDED")) return "Превышены лимиты квотирования.";
            if (errorMessage.Contains("_LIST_LIMIT_EXCEEDED"))
                return "Превышен лимит переданных идентификаторов в поле " + errorField;
            if (errorMessage.Contains("INVALID_")) return "Указано не валидное значение параметра " + errorField;
            return errorMessage;
        }
    }
}
