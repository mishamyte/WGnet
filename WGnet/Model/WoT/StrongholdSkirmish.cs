using Newtonsoft.Json;

namespace WGnet.Model.WoT
{
    /// <summary>
    /// Информация о вылазках
    /// </summary>
    public class StrongholdSkirmish
    {
        /// <summary>
        /// Общее количество Вылазок
        /// </summary>
        [JsonProperty("battles_count")]
        public long BattlesCount { get; set; }

        /// <summary>
        /// Процент побед в Вылазках
        /// </summary>
        [JsonProperty("battles_win_percentage")]
        public float BattlesWinPercentage { get; set; }

        /// <summary>
        /// Количество побед в Вылазках
        /// </summary>
        [JsonProperty("battles_wins")]
        public long BattlesWins { get; set; }
    }
}
