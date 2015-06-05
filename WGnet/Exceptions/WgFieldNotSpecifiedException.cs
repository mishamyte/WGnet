using System;
using System.Runtime.Serialization;

namespace WGnet.Exceptions
{
    [Serializable]
    public class WgFieldNotSpecifiedException : WgApiException
    {
        /// <summary>
        /// Код ошибки, полученный от сервера WG.
        /// </summary>
        public int ErrorCode { get; private set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="WgFieldNotSpecifiedException"/>.
        /// </summary>
        public WgFieldNotSpecifiedException()
        {            
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="WgFieldNotSpecifiedException"/> с указанным описанием.
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        public WgFieldNotSpecifiedException(string message) : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="WgFieldNotSpecifiedException"/> с указанным описанием.
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// /// <param name="innerException">Внутреннее исключение.</param>
        public WgFieldNotSpecifiedException(string message, Exception innerException) : base(message, innerException)
        {            
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="WgFieldNotSpecifiedException"/> с указанным описанием и кодом ошибки.
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="code">Код ошибки, полученный от сервера WG.</param>
        public WgFieldNotSpecifiedException(string message, int code) : base(message)
        {
            ErrorCode = code;
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="WgFieldNotSpecifiedException"/> с указанным описанием, кодом ошибки и внутренним исключением.
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="code">Код ошибки, полученный от сервера WG.</param>
        /// <param name="innerException">Внутреннее исключение.</param>
        public WgFieldNotSpecifiedException(string message, int code, Exception innerException) : base(message, innerException)
        {
            ErrorCode = code;
        }
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="WgFieldNotSpecifiedException"/> на основе ранее сериализованных данных.
        /// </summary>
        /// <param name="info">Содержит все данные, необходимые для десериализации.</param>
        /// <param name="context">Описывает источник и назначение данного сериализованного потока и предоставляет дополнительный, 
        /// определяемый вызывающим, контекст.</param>
        protected WgFieldNotSpecifiedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {            
        }

        #region Служебные методы

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue("ErrorCode", ErrorCode);
        }

        #endregion
    }
}
