using Newtonsoft.Json;

namespace WGnet.Model.WoT
{
    /// <summary>
    /// Информация о строениях по уникальным ключам их типов
    /// </summary>
    public class StrongholdBuildings
    {
        /// <summary>
        /// Название направления. Значение '–-' используется только для Командного центра.
        /// </summary>
        [JsonProperty("direction_name")]
        public string DirectionName { get; set; }

        /// <summary>
        /// Уровень строения
        /// </summary>
        [JsonProperty("level")]
        public long Level { get; set; }

        /// <summary>
        /// Тип строения
        /// </summary>
        [JsonProperty("type")]
        public long Type { get; set; }
    }
}
