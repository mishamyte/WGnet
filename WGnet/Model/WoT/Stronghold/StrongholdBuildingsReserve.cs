using Newtonsoft.Json;

namespace WGnet.Model.WoT.Stronghold
{
    /// <summary>
    /// Информация о резерве
    /// </summary>
    public class StrongholdBuildingsReserve
    {
        /// <summary>
        /// Локализованное описание
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Ссылка на изображение
        /// </summary>
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Локализованное название
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
