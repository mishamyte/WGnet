using Newtonsoft.Json;

namespace WGnet.Model.WoT
{
    /// <summary>
    /// Статистика машины
    /// </summary>
    public class PlayerTanksStatistics
    {
        /// <summary>
        /// Проведено боёв
        /// </summary>
        [JsonProperty("battles")]
        public long Battles { get; set; }

        /// <summary>
        /// Победы
        /// </summary>
        [JsonProperty("wins")]
        public long Wins { get; set; }
    }
}
