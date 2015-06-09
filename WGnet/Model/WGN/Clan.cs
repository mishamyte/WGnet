using Newtonsoft.Json;

namespace WGnet.Model.WGN
{
    /// <summary>
    /// Базовая информация о клане
    /// См описание <see cref="http://ru.wargaming.net/developers/api_reference/wgn/clans/list/"/>
    /// </summary>
    public class Clan
    {
        /// <summary>
        /// Идентификатор клана
        /// </summary>
        [JsonProperty("clan_id")]
        public long ClanId { get; set; }

        /// <summary>
        /// Цвет клана в формате HEX #RRGGBB
        /// </summary>
        [JsonProperty("color")]
        public string Color { get; set; }

        /// <summary>
        /// Дата создания клана
        /// </summary>
        [JsonProperty("created_at")]
        public long CreatedAt { get; set; }

        /// <summary>
        /// Количество участников клана
        /// </summary>
        [JsonProperty("members_count")]
        public long MembersCount { get; set; }

        /// <summary>
        /// Название клана
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Тег клана
        /// </summary>
        [JsonProperty("tag")]
        public string Tag { get; set; }

        /// <summary>
        /// Информация об эмблемах клана в играх и на клановом портале
        /// См. <see cref="ClanEmblems"/>
        /// </summary>
        [JsonProperty("emblems")]
        public ClanEmblems Emblems { get; set; }
    }
}
