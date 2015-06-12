using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace WGnet.Model.WoT.Stronghold
{
    /// <summary>
    /// Информация об Укрепрайоне клана
    /// См. описание <see cref="http://ru.wargaming.net/developers/api_reference/wot/stronghold/info/"/>
    /// </summary>
    public class Stronghold
    {
        /// <summary>
        /// Идентификатор клана
        /// </summary>
        [JsonProperty("clan_id")]
        public long ClanId { get; set; }

        /// <summary>
        /// Показывает, что период обороны активирован
        /// </summary>
        [JsonProperty("defense_mode_is_activated")]
        public bool DefenseModeIsActivated { get; set; }

        /// <summary>
        /// Количество направлений
        /// </summary>
        [JsonProperty("directions_count")]
        public long DirectionsCount { get; set; }

        /// <summary>
        /// Уровень
        /// </summary>
        [JsonProperty("level")]
        public long Level { get; set; }

        /// <summary>
        /// Информация о строениях по уникальным ключам их типов
        /// См. <see cref="StrongholdBuildingsInfo"/>
        /// </summary>
        [JsonProperty("buildings")]
        public ReadOnlyDictionary<int, StrongholdBuildingsInfo> Buildings { get; set; } 

        /// <summary>
        /// Информация об активном Периоде обороны
        /// Если оборона отключена, полю присваивается значение null
        /// См. <see cref="StrongholdDefense"/>
        /// </summary>
        [JsonProperty("defense")]
        public StrongholdDefense Defense { get; set; }

        /// <summary>
        /// Секретные данные Укрепрайона
        /// См. <see cref="StrongholdPrivate"/>
        /// </summary>
        [JsonProperty("private")]
        public StrongholdPrivate Private { get; set; }

        /// <summary>
        /// Информация о вылазках
        /// См. <see cref="StrongholdSkirmish"/>
        /// </summary>
        [JsonProperty("skirmish")]
        public StrongholdSkirmish Skirmish { get; set; }
    }
}
