﻿using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace WGnet.Model.WoT.Globalwar
{
    /// <summary>
    /// Информация о клане, участвующем в "Мировой войне"
    /// </summary>
    public class GlobalwarClan
    {
        /// <summary>
        /// Идентификатор клана
        /// </summary>
        [JsonProperty("clan_id")]
        public long ClanId { get; set; }

        /// <summary>
        /// Список провинций клана
        /// </summary>
        [JsonProperty("provinces")]
        public ReadOnlyCollection<GlobalwarClanProvince> Provinces { get; set; } 
    }
}
