using System;
using System.Collections.Generic;

namespace WGnet.Utils
{
    /// <summary>
    /// Параметры запроса к WG API.
    /// </summary>
    [Serializable]
    public class WgParameters : Dictionary<string, string>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="WgParameters"/>.
        /// </summary>
        public WgParameters()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="WgParameters"/> на основе словаря.
        /// </summary>
        /// <param name="parameters">
        /// Параметры запроса.
        /// </param>
        public WgParameters(IDictionary<string, string> parameters) : base(parameters)
        {
        }

        /// <summary>
        /// Параметры для запроса без параметров.
        /// </summary>
        public static WgParameters Empty
        {
            get { return new WgParameters(); }
        }

        /// <summary>
        /// Добавляет параметр запроса.
        /// </summary>
        /// <typeparam name="T">Тип значения параметра запроса.</typeparam>
        /// <param name="name">Имя параметра запроса.</param>
        /// <param name="value">Значение параметра запроса.</param>
        public void Add<T>(string name, T value)
        {
            if (value == null)
                return;

            if (typeof(T).IsEnum)
            {
                Add(name, (int)(object)value);
                return;
            }

            var stringValue = value.ToString();
            if (!string.IsNullOrEmpty(stringValue))
                base.Add(name, stringValue);
        }

        /// <summary>
        /// Добавляет параметр запроса, представляющий собой последовательность элементов заданного типа.
        /// Последовательность добавляется в виде строкового значения, содержащего ее элементы, разделенные запятой.
        /// </summary>
        /// <typeparam name="T">Имя типа элементов последовательности.</typeparam>
        /// <param name="name">Имя параметра запроса.</param>
        /// <param name="collection">Последовательность, представляющая значение параметра запроса.</param>
        public void Add<T>(string name, IEnumerable<T> collection)
        {
            Add(name, collection);
        }

        /// <summary>
        /// Добавляет именованный параметр запроса, представляющий собой коллекцию элементов заданного типа.
        /// Коллекция добавляетсяв виде строкового значения, содержащего ее элементы, разделенные запятой.
        /// </summary>
        /// <typeparam name="T">Имя типа элементов коллекции.</typeparam>
        /// <param name="name">Имя параметра запроса.</param>
        /// <param name="collection">Коллекция, представляющая значение параметра запроса.</param>
        public void Add<T>(string name, List<T> collection)
        {
            Add(name, (IEnumerable<T>)collection);
        }

        /// <summary>
        /// Добавляет параметр запроса. 
        /// Если передан null, то добавление параметра не производится.
        /// </summary>
        /// <typeparam name="T">Тип значения параметра запроса.</typeparam>
        /// <param name="name">Имя параметра запроса.</param>
        /// <param name="nullableValue">Значение параметра запроса.</param>
        public void Add<T>(string name, T? nullableValue) where T : struct
        {
            if (!nullableValue.HasValue)
                return;

            Add(name, nullableValue.Value);
        }

        /// <summary>
        /// Добавляет логический параметр. 
        /// Если передан null или значение параметра false, то добавление не производится.
        /// </summary>
        /// <param name="name">Имя параметра запроса.</param>
        /// <param name="nullableValue">Значение параметра.</param>
        public void Add(string name, bool? nullableValue)
        {
            if (!nullableValue.HasValue || !nullableValue.Value)
                return;

            base.Add(name, "1");
        }

        /// <summary>
        /// Добавляет логический параметр. 
        /// Если передан null, то добавление не производится.
        /// </summary>
        /// <param name="name">Имя параметра запроса.</param>
        /// <param name="value">Значение параметра.</param>
        public void Add(string name, bool value)
        {
            base.Add(name, value ? "1" : "0");
        }
    }
}
