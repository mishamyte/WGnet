using System.Collections.Generic;
using Newtonsoft.Json;

namespace WGnet.Model.WoT
{
    /// <summary>
    /// Достижения игрока
    /// См. описание <see cref="http://ru.wargaming.net/developers/api_reference/wot/account/achievements/"/>
    /// </summary>
    public class PlayerAchievements
    {
        /// <summary>
        /// Полученные достижения
        /// </summary>
        [JsonProperty("achievements")]
        public Dictionary<string, int> Achievements { get; set; } 

        /// <summary>
        /// Прогресс достижений
        /// </summary>
        [JsonProperty("frags")]
        public Dictionary<string, int> Frags { get; set; }

        /// <summary>
        /// Максимальные значения серийных достижений
        /// </summary>
        [JsonProperty("max_series")]
        public Dictionary<string, int> MaxSeries { get; set; } 
    }
}
