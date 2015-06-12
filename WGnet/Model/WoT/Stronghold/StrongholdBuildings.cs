using Newtonsoft.Json;

namespace WGnet.Model.WoT.Stronghold
{
    /// <summary>
    /// Информацию из энциклопедии обо всех строениях Укрепрайона
    /// См. описание <see cref="http://ru.wargaming.net/developers/api_reference/wot/stronghold/buildings/"/>
    /// </summary>
    public class StrongholdBuildings
    {
        /// <summary>
        /// Локализованное полное описание
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Ссылка на изображение
        /// </summary>
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Локализованное краткое описание
        /// </summary>
        [JsonProperty("short_description")]
        public string ShortDescription { get; set; }

        /// <summary>
        /// Локализованное название
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Уникальный тип
        /// </summary>
        [JsonProperty("type")]
        public int Type { get; set; }

        /// <summary>
        /// Информация о резерве
        /// См. <see cref="StrongholdBuildingsReserve"/>
        /// </summary>
        [JsonProperty("reserve")]
        public StrongholdBuildingsReserve Reserve { get; set; }
    }
}
