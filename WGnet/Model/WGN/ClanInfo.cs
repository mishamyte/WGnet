using System.Collections.Generic;
using Newtonsoft.Json;

namespace WGnet.Model.WGN
{
    /// <summary>
    /// Информация о клане
    /// См. описание <see cref="http://ru.wargaming.net/developers/api_reference/wgn/clans/info/"/>
    /// </summary>
    public class ClanInfo
    {
        /// <summary>
        /// Клан может приглашать игроков
        /// </summary>
        [JsonProperty("accepts_join_requests")]
        public bool AcceptsJoinRequests { get; set; }

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
        /// Идентификатор игрока, создавшего клан
        /// </summary>
        [JsonProperty("creator_id")]
        public long CreatorId { get; set; }

        /// <summary>
        /// Имя игрока, создавшего клан
        /// </summary>
        [JsonProperty("creator_name")]
        public string CreatorName { get; set; }

        /// <summary>
        /// Описание клана
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Описание клана в HTML
        /// </summary>
        [JsonProperty("description_html")]
        public string DescriptionHtml { get; set; }

        /// <summary>
        /// Клан удалён. Информация об удалённом клане содержит актуальные значения только для следующих полей:
        /// <see cref="ClanId"/>
        /// <see cref="IsClanDisbanded"/>
        /// <see cref="UpdatedAt"/>
        /// </summary>
        [JsonProperty("is_clan_disbanded")]
        public bool IsClanDisbanded { get; set; }

        /// <summary>
        /// Идентификатор Командующего клана
        /// </summary>
        [JsonProperty("leader_id")]
        public long LeaderId { get; set; }

        /// <summary>
        /// Имя Командующего
        /// </summary>
        [JsonProperty("leader_name")]
        public string LeaderName { get; set; }

        /// <summary>
        /// Количество участников клана
        /// </summary>
        [JsonProperty("members_count")]
        public long MembersCount { get; set; }

        /// <summary>
        /// Девиз клана
        /// </summary>
        [JsonProperty("motto")]
        public string Motto { get; set; }

        /// <summary>
        /// Название клана
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Старое название клана
        /// </summary>
        [JsonProperty("old_name")]
        public string OldName { get; set; }

        /// <summary>
        /// Старый тег клана
        /// </summary>
        [JsonProperty("old_tag")]
        public string OldTag { get; set; }

        /// <summary>
        /// Время последнего переименования клана в UTC
        /// </summary>
        [JsonProperty("renamed_at")]
        public long RenamedAt { get; set; }

        /// <summary>
        /// Тег клана
        /// </summary>
        [JsonProperty("tag")]
        public string Tag { get; set; }

        /// <summary>
        /// Время обновления информации о клане
        /// </summary>
        [JsonProperty("updated_at")]
        public long UpdatedAt { get; set; }

        /// <summary>
        /// Информация об эмблемах клана в играх и на клановом портале
        /// См. <see cref="ClanEmblems"/>
        /// </summary>
        [JsonProperty("emblems")]
        public ClanEmblems Emblems { get; set; }

        /// <summary>
        /// Участники клана
        /// </summary>
        [JsonProperty("members")]
        public List<ClanMembers> Members { get; set; }

        /// <summary>
        /// Cекретная информация клана
        /// См. <see cref="ClanPrivate"/>
        /// </summary>
        [JsonProperty("private")]
        public ClanPrivate Private { get; set; }
    }
}
