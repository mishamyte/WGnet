using System;
using System.Runtime.Serialization;

namespace WGnet.Exceptions
{

    /// <summary>
    /// Базовый класс для всех исключений, выбрасываемых библиотекой.
    /// </summary>
    [Serializable]
    public class WgApiException : Exception
    {

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="WgApiException"/>.
        /// </summary>
        public WgApiException()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="WgApiException"/> с указанным описанием.
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        public WgApiException(string message) : base(message)
        {
        }


        public WgApiException(string message, Exception innerException) : base(message, innerException)
        {            
        }


        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="WgApiException"/> на основе ранее сериализованных данных.
        /// </summary>
        /// <param name="info">Содержит все данные, необходимые для десериализации.</param>
        /// <param name="context">Описывает источник и назначение данного сериализованного потока и предоставляет дополнительный, 
        /// определяемый вызывающим, контекст.</param>
        protected WgApiException(SerializationInfo info, StreamingContext context) : base(info, context)
        {            
        }
    }
}
