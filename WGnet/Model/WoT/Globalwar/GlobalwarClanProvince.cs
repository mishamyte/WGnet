using Newtonsoft.Json;

namespace WGnet.Model.WoT.Globalwar
{
    /// <summary>
    /// Информация о провинции клана
    /// </summary>
    public class GlobalwarClanProvince
    {
        /// <summary>
        /// Время владения провинцией (в днях)
        /// </summary>
        [JsonProperty("occupancy_time")]
        public long OccupancyTime { get; set; }

        /// <summary>
        /// Название провинции
        /// </summary>
        [JsonProperty("province_i18n")]
        public string ProvinceI18N { get; set; }

        /// <summary>
        /// Идентификатор провинции
        /// </summary>
        [JsonProperty("province_id")]
        public string ProvinceId { get; set; }
    }
}
