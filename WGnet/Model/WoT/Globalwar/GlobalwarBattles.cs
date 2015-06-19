using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace WGnet.Model.WoT.Globalwar
{
    /// <summary>
    /// Информация о боях клана
    /// </summary>
    public class GlobalwarBattles
    {
        /// <summary>
        /// Бой начался
        /// </summary>
        [JsonProperty("started")]
        public bool Started { get; set; }

        /// <summary>
        /// Время начала боя
        /// </summary>
        [JsonProperty("time")]
        public long Time { get; set; }

        /// <summary>
        /// Тип боя:
        /// - for_province — бой за провинцию;
        /// - meeting_engagement — встречный бой;
        /// - landing — бой за высадку.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Информация о карте
        /// См. <see cref="GlobalwarBattlesArenas"/>
        /// </summary>
        [JsonProperty("arenas")]
        public ReadOnlyCollection<GlobalwarBattlesArenas> Arenas { get; set; }

        /// <summary>
        /// Cекретная информация клана
        /// См. <see cref="GlobalwarBattlesPrivate"/>
        /// </summary>
        [JsonProperty("private")]
        public GlobalwarBattlesPrivate Private { get; set; }

        /// <summary>
        /// Провинции
        /// См. <see cref="GlobalwarBattlesProvinces"/>
        /// </summary>
        [JsonProperty("provinces_i18n")]
        public ReadOnlyCollection<GlobalwarBattlesProvinces> ProvincesI18N { get; set; }
    }
}
