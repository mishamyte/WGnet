using Newtonsoft.Json;

namespace WGnet.Model.WoT.Globalwar
{
    /// <summary>
    /// Провинции
    /// </summary>
    public class GlobalwarBattlesProvinces
    {
        /// <summary>
        /// Локализованное название провинции
        /// </summary>
        [JsonProperty("name_i18n")]
        public string NameI18N { get; set; }

        /// <summary>
        /// Идентификатор провинции
        /// </summary>
        [JsonProperty("province_id")]
        public string ProvinceId { get; set; }
    }
}
