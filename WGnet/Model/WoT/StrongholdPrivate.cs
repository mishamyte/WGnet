using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace WGnet.Model.WoT
{
    /// <summary>
    /// Секретные данные Укрепрайона
    /// </summary>
    public class StrongholdPrivate
    {
        /// <summary>
        /// Общее количество промресурса в Укрепрайоне
        /// </summary>
        [JsonProperty("total_resource_amount")]
        public long TotalResourceAmount { get; set; }

        /// <summary>
        /// Секретная информация о строениях по уникальным ключам их типов
        /// См. <see cref="StrongholdPrivateBuildings"/>
        /// </summary>
        [JsonProperty("buildings")]
        public ReadOnlyDictionary<int, StrongholdPrivateBuildings> Buildings { get; set; } 

        /// <summary>
        /// Секретная информация о вылазках
        /// См. <see cref="StrongholdPrivateSkirmish"/>
        /// </summary>
        [JsonProperty("skirmish")]
        public StrongholdPrivateSkirmish Skirmish { get; set; }
    }
}
