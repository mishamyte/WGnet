using System;
using System.Runtime.Serialization;

namespace WGnet.Exceptions
{
    [Serializable]
    public class WgInvalidOrLimitException : WgApiException
    {
        /// <summary>
        /// Код ошибки, полученный от сервера WG.
        /// </summary>
        public int ErrorCode { get; private set; }
        /// <summary>
        /// Поле, в котором ошибка
        /// </summary>
        public string ErrorField { get; private set; }
        /// <summary>
        /// Ошибочное значение
        /// </summary>
        public string ErrorValue { get; private set; }
        /// <summary>
        /// Сообщение об ошибке
        /// </summary>
        public string ErrorMessage { get; private set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="WgInvalidOrLimitException"/>.
        /// </summary>
        public WgInvalidOrLimitException()
        {            
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="WgInvalidOrLimitException"/> с указанным описанием.
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        public WgInvalidOrLimitException(string message) : base(message)
        {
        }


        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="WgInvalidOrLimitException"/> с указанным описанием и кодом ошибки.
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="code">Код ошибки, полученный от сервера WG.</param>
        public WgInvalidOrLimitException(string message, int code)
            : base(message)
        {
            ErrorCode = code;
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="WgInvalidOrLimitException"/> с указанным описанием и кодом ошибки.
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="field">Поле, в котором ошибка</param>
        /// <param name="code">Код ошибки, полученный от сервера WG.</param>
        public WgInvalidOrLimitException(string message, int code, string field) : base(message)
        {
            ErrorCode = code;
            ErrorField = field;
            ErrorMessage = GetErrorMessage(message);
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="WgInvalidOrLimitException"/> с указанным описанием и кодом ошибки.
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="field">Поле, в котором ошибка</param>
        /// <param name="value">Ошибочное значение</param>
        /// <param name="code">Код ошибки, полученный от сервера WG.</param>
        public WgInvalidOrLimitException(string message,  int code, string field, string value) : base(message)
        {
            ErrorCode = code;
            ErrorField = field;
            ErrorValue = value;
            ErrorMessage = GetErrorMessage(message);
        }


        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="WgInvalidOrLimitException"/> с указанным описанием.
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="innerException">Внутреннее исключение.</param>
        public WgInvalidOrLimitException(string message, Exception innerException) : base(message, innerException)
        {            
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="WgInvalidOrLimitException"/> с указанным описанием, кодом ошибки и внутренним исключением.
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="code">Код ошибки, полученный от сервера WG.</param>
        /// <param name="innerException">Внутреннее исключение.</param>
        public WgInvalidOrLimitException(string message, int code, Exception innerException) : base(message, innerException)
        {
            ErrorCode = code;
        }


        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="WgInvalidOrLimitException"/> с указанным описанием, кодом ошибки, полем, в котором ошибка и внутренним исключением.
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="code">Код ошибки, полученный от сервера WG.</param>
        /// <param name="field">Поле, в котором ошибка</param>
        /// <param name="innerException">Внутреннее исключение.</param>
        public WgInvalidOrLimitException(string message, int code, string field, Exception innerException) : base(message, innerException)
        {
            ErrorCode = code;
            ErrorField = field;
            ErrorMessage = GetErrorMessage(message);
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="WgInvalidOrLimitException"/> с указанным описанием, кодом ошибки,полем, в котором ошибка, значением ошибки и внутренним исключением.
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="code">Код ошибки, полученный от сервера WG.</param>
        /// <param name="field">Поле, в котором ошибка</param>
        /// <param name="value">Ошибочное значение</param>
        /// <param name="innerException">Внутреннее исключение.</param>
        public WgInvalidOrLimitException(string message, int code, string field, string value, Exception innerException) : base(message, innerException)
        {
            ErrorCode = code;
            ErrorField = field;
            ErrorValue = value;
            ErrorMessage = GetErrorMessage(message);
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="WgInvalidOrLimitException"/> на основе ранее сериализованных данных.
        /// </summary>
        /// <param name="info">Содержит все данные, необходимые для десериализации.</param>
        /// <param name="context">Описывает источник и назначение данного сериализованного потока и предоставляет дополнительный, 
        /// определяемый вызывающим, контекст.</param>
        protected WgInvalidOrLimitException(SerializationInfo info, StreamingContext context) : base(info, context)
        {            
        }

        #region Служебные методы
        private string GetErrorMessage(string errorMessage)
        {
            if (errorMessage.Equals("APPLICATION_IS_BLOCKED")) return "Приложение заблокировано администрацией.";
            if (errorMessage.Equals("INVALID_APPLICATION_ID")) return "Неверный идентификатор приложения.";
            if (errorMessage.Equals("INVALID_IP_ADDRESS")) return "Недопустимый IP-адрес для серверного приложения.";
            if (errorMessage.Equals("REQUEST_LIMIT_EXCEEDED")) return "Превышены лимиты квотирования.";
            if (errorMessage.Contains("_LIST_LIMIT_EXCEEDED"))
                return "Превышен лимит переданных идентификаторов в поле " + ErrorField;
            if (errorMessage.Contains("INVALID_")) return "Указано невалидное значение параметра " + ErrorField;
            return errorMessage;
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue("ErrorCode", ErrorCode);
            info.AddValue("ErrorField",ErrorField);
            info.AddValue("ErrorValue", ErrorValue);
            info.AddValue("ErrorMessage", ErrorMessage);
        }

        #endregion
    }
}
