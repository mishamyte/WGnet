using Newtonsoft.Json;

namespace WGnet.Model.WoT.Globalwar
{
    /// <summary>
    /// Информация о карте
    /// </summary>
    public class GlobalwarBattlesArenas
    {
        /// <summary>
        /// Идентификатор карты
        /// </summary>
        [JsonProperty("arena_id")]
        public string ArenaId { get; set; }

        /// <summary>
        /// Локализованное название карты
        /// </summary>
        [JsonProperty("name_i18n")]
        public string NameI18N { get; set; }
    }
}
