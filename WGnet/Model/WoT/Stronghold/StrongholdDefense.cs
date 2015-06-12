using Newtonsoft.Json;

namespace WGnet.Model.WoT.Stronghold
{
    /// <summary>
    /// Информация об активном Периоде обороны
    /// </summary>
    public class StrongholdDefense
    {
        /// <summary>
        /// Общее количество атак
        /// </summary>
        [JsonProperty("attacks_count")]
        public long AttacksCount { get; set; }

        /// <summary>
        /// Эффективность Атак
        /// </summary>
        [JsonProperty("attacks_efficiency")]
        public float AttacksEfficiency { get; set; }

        /// <summary>
        /// Количество атак, в которых клан разграбил хотя бы одно вражеское строение
        /// </summary>
        [JsonProperty("attacks_wins")]
        public long AttacksWins { get; set; }

        /// <summary>
        /// Общее количество боёв
        /// </summary>
        [JsonProperty("battles_count")]
        public long BattlesCount { get; set; }

        /// <summary>
        /// Процент побед
        /// </summary>
        [JsonProperty("battles_win_percentage")]
        public float BattlesWinPercentage { get; set; }

        /// <summary>
        /// Количество побед в боях
        /// </summary>
        [JsonProperty("battles_wins")]
        public long BattlesWins { get; set; }

        /// <summary>
        /// Количество захваченных коммандных центров
        /// </summary>
        [JsonProperty("capture_bases_count")]
        public long CaptureBasesCount { get; set; }

        /// <summary>
        /// Количество разграбленных вражеских строений
        /// </summary>
        [JsonProperty("capture_buildings_count")]
        public long CaptureBuildingsCount { get; set; }

        /// <summary>
        /// Количество захваченного промресурса
        /// </summary>
        [JsonProperty("capture_resources_count")]
        public long CaptureResourcesCount { get; set; }

        /// <summary>
        /// Общее количество боёв за строения
        /// </summary>
        [JsonProperty("clashes_count")]
        public long ClashesCount { get; set; }

        /// <summary>
        /// Процент побед в боях за строения
        /// </summary>
        [JsonProperty("clashes_win_percentage")]
        public float ClashesWinPercentage { get; set; }

        /// <summary>
        /// Количество атак, в которых клан разграбил хотя бы одно вражеское строение
        /// </summary>
        [JsonProperty("clashes_wins")]
        public long ClashesWins { get; set; }

        /// <summary>
        /// Общее количество Оборон
        /// </summary>
        [JsonProperty("defenses_count")]
        public long DefensesCount { get; set; }

        /// <summary>
        /// Эффективность Обороны
        /// </summary>
        [JsonProperty("defenses_efficiency")]
        public float DefensesEfficiency { get; set; }

        /// <summary>
        /// Количество Оборон, в которых клан не потерял ни одного строения
        /// </summary>
        [JsonProperty("defenses_wins")]
        public long DefensesWins { get; set; }

        /// <summary>
        /// Количество потерянных коммандных центров
        /// </summary>
        [JsonProperty("loss_bases_count")]
        public long LossBasesCount { get; set; }

        /// <summary>
        /// Количество разграбленных строений клана
        /// </summary>
        [JsonProperty("loss_buildings_count")]
        public long LossBuildingsCount { get; set; }

        /// <summary>
        /// Количество потерянного промресурса
        /// </summary>
        [JsonProperty("loss_resources_count")]
        public long LossResourcesCount { get; set; }
    }
}
