using Newtonsoft.Json;

namespace WGnet.Model.WoT.Globalwar
{
    /// <summary>
    /// Информация о карте на Глобальной карте
    /// См. описание <see cref="http://ru.wargaming.net/developers/api_reference/wot/globalwar/maps/"/>
    /// </summary>
    public class GlobalwarMaps
    {
        /// <summary>
        /// Идентификатор Глобальной карты
        /// </summary>
        [JsonProperty("map_id")]
        public string MapId { get; set; }

        /// <summary>
        /// URL карты на сайте
        /// </summary>
        [JsonProperty("map_url")]
        public string MapUrl { get; set; }

        /// <summary>
        /// Состояние карты:
        /// - freezed - заморожена
        /// - active - активна
        /// - unavailable - недоступна
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }

        /// <summary>
        /// Тип карты: 
        /// - обычная карта
        /// - карта события
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Информация о последнем сезоне
        /// См. <see cref="Globalwar.SeasonInfo"/>
        /// </summary>
        [JsonProperty("season_info")]
        public SeasonInfo SeasonInfo { get; set; }

    }
}
