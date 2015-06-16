using Newtonsoft.Json;

namespace WGnet.Model.WoT.Globalwar
{
    /// <summary>
    /// Регионы
    /// </summary>
    public class GlobalWarProvincesRegions
    {
        /// <summary>
        /// Название региона
        /// </summary>
        [JsonProperty("region_i18n")]
        public string RegionI18N { get; set; }

        /// <summary>
        /// Идентификатор региона
        /// </summary>
        [JsonProperty("region_id")]
        public string RegionId { get; set; }
    }
}
