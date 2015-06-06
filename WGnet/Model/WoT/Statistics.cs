using System.Collections.Generic;
using Newtonsoft.Json;

namespace WGnet.Model.WoT
{
    /// <summary>
    /// Статистика игрока 
    /// См. описание <see cref="http://ru.wargaming.net/developers/api_reference/wot/account/info/"/>
    /// </summary>
    public class Statistics
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
        /// См. <see cref="StatisticsAll"/>
        /// </summary>
        [JsonProperty("all")]
        public StatisticsAll All { get; set; }

        /// <summary>
        /// Статистика боёв в составе клана
        /// См. <see cref="StatisticsClan"/>
        /// </summary>
        [JsonProperty("clan")]
        public StatisticsClan Clan { get; set; }

        /// <summary>
        /// Статистика боёв в составе роты
        /// См. <see cref="StatisticsCompany"/>
        /// </summary>
        [JsonProperty("company")]
        public StatisticsCompany Company { get; set; }

        /// <summary>
        /// Статистика исторических боёв
        /// См. <see cref="StatisticsHistorical"/>
        /// </summary>
        [JsonProperty("historical")]
        public StatisticsHistorical Historical { get; set; }

        /// <summary>
        /// Статистика командных боёв постоянных команд
        /// См. <see cref="StatisticsRegularTeam"/>
        /// </summary>
        [JsonProperty("regular_team")]
        public StatisticsRegularTeam RegularTeam { get; set; }

        /// <summary>
        /// Общая по всем кланам статистика боёв игрока в режиме обороны Укрепрайона
        /// См. <see cref="StatisticsStrongholdDefense"/>
        /// </summary>
        [JsonProperty("stronghold_defense")]
        public StatisticsStrongholdDefense StrongholdDefense { get; set; }

        /// <summary>
        /// Общая по всем кланам статистика боёв игрока в режиме вылазок Укрепрайона
        /// См. <see cref="StatisticsStrongholdSkirmish"/>
        /// </summary>
        [JsonProperty("stronghold_skirmish")]
        public StatisticsStrongholdSkirmish StrongholdSkirmish { get; set; }

        /// <summary>
        /// Статистика командных боёв
        /// </summary>
        [JsonProperty("team")]
        public StatisticsTeam Team { get; set; }
    }
}
