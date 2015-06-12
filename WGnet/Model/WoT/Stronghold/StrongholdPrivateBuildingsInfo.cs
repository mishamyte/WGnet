using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace WGnet.Model.WoT.Stronghold
{
    /// <summary>
    /// Секретная информация о строениях по уникальным ключам их типов
    /// </summary>
    public class StrongholdPrivateBuildingsInfo
    {
        /// <summary>
        /// Список идентификаторов аккаунтов игроков, которые закреплены за данным строением
        /// </summary>
        [JsonProperty("attached_account_ids")]
        public ReadOnlyCollection<long> AttachedAccountIds { get; set; } 

        /// <summary>
        /// Количество промресурса в данном строении
        /// </summary>
        [JsonProperty("resource_amount")]
        public long ResourceAmount { get; set; }

        /// <summary>
        /// Тип строения
        /// </summary>
        [JsonProperty("type")]
        public long Type { get; set; }
    }
}
