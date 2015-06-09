using System.ComponentModel;

namespace WGnet.Enums
{
    /// <summary>
    /// Сортировка
    /// </summary>
    public enum OrderBy
    {
        /// <summary>
        /// По идентификатору клана
        /// </summary>
        [Description("id")]
        Id,
        /// <summary>
        /// По идентификатору клана в обратном порядке
        /// </summary>
        [Description("-id")]
        ReverseId,
        /// <summary>
        /// По названию клана
        /// </summary>
        [Description("name")]
        Name,
        /// <summary>
        /// По названию клана в обратном порядке
        /// </summary>
        [Description("-name")]
        ReverseName,
        /// <summary>
        /// По численности клана
        /// </summary>
        [Description("members_count")]
        MembersCount,
        /// <summary>
        /// По численности клана в обратном порядке
        /// </summary>
        [Description("-members_count")]
        ReverseMembersCount,
        /// <summary>
        /// По тегу клана
        /// </summary>
        [Description("tag")]
        Tag,
        /// <summary>
        /// По тегу клана в обратном порядке
        /// </summary>
        [Description("-tag")]
        ReverseTag,
        /// <summary>
        /// По дате создания клана
        /// </summary>
        [Description("created_at")]
        CreatedAt,
        /// <summary>
        /// По дате создания клана в обратном порядке
        /// </summary>
        [Description("-created_at")]
        ReverseCreatedAt,
    }
}
