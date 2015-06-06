using System;
using System.Runtime.Serialization;

namespace WGnet.Exceptions
{
    /// <summary>
    /// Выбрасывается при следующих ошибках:
    /// - Указаный метод API отключён
    /// </summary>
    [Serializable]
    public class WgMethodDisabledException : WgApiException
    {
        /// <summary>
        /// Код ошибки, полученный от сервера WG
        /// </summary>
        public int ErrorCode { get; private set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="WgMethodDisabledException"/>.
        /// </summary>
        public WgMethodDisabledException()
        {            
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="WgMethodDisabledException"/> с указанным описанием
        /// </summary>
        /// <param name="message">Описание исключения</param>
        public WgMethodDisabledException(string message) : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="WgMethodDisabledException"/> с указанным описанием
        /// </summary>
        /// <param name="message">Описание исключения</param>
        /// /// <param name="innerException">Внутреннее исключение</param>
        public WgMethodDisabledException(string message, Exception innerException) : base(message, innerException)
        {            
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="WgMethodDisabledException"/> с указанным описанием и кодом ошибки
        /// </summary>
        /// <param name="message">Описание исключения</param>
        /// <param name="code">Код ошибки, полученный от сервера WG</param>
        public WgMethodDisabledException(string message, int code) : base(message)
        {
            ErrorCode = code;
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="WgMethodDisabledException"/> с указанным описанием, кодом ошибки и внутренним исключением
        /// </summary>
        /// <param name="message">Описание исключения</param>
        /// <param name="code">Код ошибки, полученный от сервера WG</param>
        /// <param name="innerException">Внутреннее исключение</param>
        public WgMethodDisabledException(string message, int code, Exception innerException) : base(message, innerException)
        {
            ErrorCode = code;
        }
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="WgMethodDisabledException"/> на основе ранее сериализованных данных
        /// </summary>
        /// <param name="info">Содержит все данные, необходимые для десериализации</param>
        /// <param name="context">Описывает источник и назначение данного сериализованного потока и предоставляет дополнительный, 
        /// определяемый вызывающим, контекст</param>
        protected WgMethodDisabledException(SerializationInfo info, StreamingContext context) : base(info, context)
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
