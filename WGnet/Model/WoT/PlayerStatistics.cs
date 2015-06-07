using System.Collections.Generic;
using Newtonsoft.Json;

namespace WGnet.Model.WoT
{
    /// <summary>
    /// Статистика игрока 
    /// См. описание <see cref="http://ru.wargaming.net/developers/api_reference/wot/account/info/"/>
    /// </summary>
    public class PlayerStatistics
    {
        /// <summary>
        /// Количество и модели уничтоженной игроком техники. Приватные данные игрока.
        /// </summary>
        [JsonProperty("frags")]
        public Dictionary<long, long> Frags { get; set; }
        
        /// <summary>
        /// Количество поваленных деревьев
        /// </summary>
        [JsonProperty("trees_cut")]
        public long TreesCut { get; set; }

        /// <summary>
        /// Вся статистика
        /// См. <see cref="PlayerStatisticsAll"/>
        /// </summary>
        [JsonProperty("all")]
        public PlayerStatisticsAll All { get; set; }

        /// <summary>
        /// Статистика боёв в составе клана
        /// См. <see cref="PlayerStatisticsClan"/>
        /// </summary>
        [JsonProperty("clan")]
        public PlayerStatisticsClan Clan { get; set; }

        /// <summary>
        /// Статистика боёв в составе роты
        /// См. <see cref="PlayerStatisticsCompany"/>
        /// </summary>
        [JsonProperty("company")]
        public PlayerStatisticsCompany Company { get; set; }

        /// <summary>
        /// Статистика исторических боёв
        /// См. <see cref="PlayerStatisticsHistorical"/>
        /// </summary>
        [JsonProperty("historical")]
        public PlayerStatisticsHistorical Historical { get; set; }

        /// <summary>
        /// Статистика командных боёв постоянных команд
        /// См. <see cref="PlayerStatisticsRegularTeam"/>
        /// </summary>
        [JsonProperty("regular_team")]
        public PlayerStatisticsRegularTeam RegularTeam { get; set; }

        /// <summary>
        /// Общая по всем кланам статистика боёв игрока в режиме обороны Укрепрайона
        /// См. <see cref="PlayerStatisticsStrongholdDefense"/>
        /// </summary>
        [JsonProperty("stronghold_defense")]
        public PlayerStatisticsStrongholdDefense StrongholdDefense { get; set; }

        /// <summary>
        /// Общая по всем кланам статистика боёв игрока в режиме вылазок Укрепрайона
        /// См. <see cref="PlayerStatisticsStrongholdSkirmish"/>
        /// </summary>
        [JsonProperty("stronghold_skirmish")]
        public PlayerStatisticsStrongholdSkirmish StrongholdSkirmish { get; set; }

        /// <summary>
        /// Статистика командных боёв
        /// </summary>
        [JsonProperty("team")]
        public PlayerStatisticsTeam Team { get; set; }
    }
}
