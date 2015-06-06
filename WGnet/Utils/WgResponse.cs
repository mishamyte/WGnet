using WGnet.Model;

namespace WGnet.Utils
{
    /// <summary>
    /// Ответ от серверов WG
    /// </summary>
    /// <typeparam name="T">Generic-класс Data</typeparam>
    public class WgResponse<T> where T : class, new ()
    {
        /// <summary>
        /// Статус запроса
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Мета-данные запроса <see cref="Model.Meta"/>
        /// </summary>
        public Meta Meta { get; set; }

        /// <summary>
        /// Блок, содержащий запрашиваемые данные. Формат ответа зависит от запроса
        /// См. <see cref="http://ru.wargaming.net/developers/api_reference/"/>
        /// </summary>
        public T Data { get; set; }
    }
}
