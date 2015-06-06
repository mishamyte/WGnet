namespace WGnet.Model
{
    /// <summary>
    /// Мета-данные, получаемые от серверов WG
    /// </summary>
    public class Meta
    {
        /// <summary>
        /// Количество полученных экзепляров данных. Формат данных зависит от запроса
        /// См. <see cref="http://ru.wargaming.net/developers/api_reference/"/>
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Количество экземпляров данных всего. Формат данных зависит от запроса
        /// См. <see cref="http://ru.wargaming.net/developers/api_reference/"/>
        /// </summary>
        public int? Total { get; set; }
    }
}
