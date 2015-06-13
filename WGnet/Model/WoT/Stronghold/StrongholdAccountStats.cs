using Newtonsoft.Json;

namespace WGnet.Model.WoT.Stronghold
{
    /// <summary>
    /// Cтатистикf игрока по Укрепрайону текущего клана
    /// </summary>
    public class StrongholdAccountStats
    {
        /// <summary>
        /// Идентификатор аккаунта игрока
        /// </summary>
        [JsonProperty("account_id")]
        public long AccountId { get; set; }

        /// <summary>
        /// Идентификатор клана игрока
        /// </summary>
        [JsonProperty("clan_id")]
        public long ClanId { get; set; }

        /// <summary>
        /// Статистика боёв игрока в режиме обороны в текущем клане. Если у клана игрока нет Укрепрайона, полю присваивается значение null.
        /// См. <see cref="StrongholdAccountStatsDefense"/>
        /// </summary>
        [JsonProperty("stronghold_defense")]
        public StrongholdAccountStatsDefense StrongholdDefense { get; set; }

        /// <summary>
        /// Статистика боёв игрока в режиме вылазок в текущем клане. Если у клана игрока нет Укрепрайона, полю присваивается значение null.
        /// См. <see cref="StrongholdAccountStatsSkirmish"/>
        /// </summary>
        [JsonProperty("stronghold_skirmish")]
        public StrongholdAccountStatsSkirmish StrongholdSkirmish { get; set; }
    }
}
