using Newtonsoft.Json;

namespace WGnet.Model.WGN.Clan
{
    /// <summary>
    /// Участники клана
    /// </summary>
    public class ClanMembers
    {
        /// <summary>
        /// Идентификатор игрока
        /// </summary>
        [JsonProperty("account_id")]
        public long AccountId { get; set; }

        /// <summary>
        /// Имя игрока
        /// </summary>
        [JsonProperty("account_name")]
        public string AccountName { get; set; }

        /// <summary>
        /// Дата вступления в клан
        /// </summary>
        [JsonProperty("joined_at")]
        public long JoinedAt { get; set; }

        /// <summary>
        /// Техническое название должности
        /// </summary>
        [JsonProperty("role")]
        public string Role { get; set; }

        /// <summary>
        /// Локализованная должность
        /// </summary>
        [JsonProperty("role_i18n")]
        public string RoleI18N { get; set; }
    }
}
