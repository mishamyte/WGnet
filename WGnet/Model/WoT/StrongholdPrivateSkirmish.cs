using Newtonsoft.Json;

namespace WGnet.Model.WoT
{
    /// <summary>
    /// Секретная информация о вылазках
    /// </summary>
    public class StrongholdPrivateSkirmish
    {
        /// <summary>
        /// Количество вылазок в Абсолютном дивизионе
        /// </summary>
        [JsonProperty("absolute_battles_count")]
        public long AbsoluteBattlesCount { get; set; }

        /// <summary>
        /// Количество промресурса, захваченного в вылазках Абсолютного дивизиона
        /// </summary>
        [JsonProperty("absolute_resource_capture")]
        public long AbsoluteResourceCapture { get; set; }

        /// <summary>
        /// Количество вылазок в Чемпионском дивизионе
        /// </summary>
        [JsonProperty("champion_battles_count")]
        public long ChampionBattlesCount { get; set; }

        /// <summary>
        /// Количество промресурса, захваченного в вылазках Чемпионского дивизиона
        /// </summary>
        [JsonProperty("champion_resource_capture")]
        public long ChampionResourceCapture { get; set; }

        /// <summary>
        /// Количество вылазок в Среднем дивизионе
        /// </summary>
        [JsonProperty("middle_battles_count")]
        public long MiddleBattlesCount { get; set; }

        /// <summary>
        /// Количество промресурса, захваченного в вылазках Среднего дивизиона
        /// </summary>
        [JsonProperty("middle_resource_capture")]
        public long MiddleResourceCapture { get; set; }
    }
}
