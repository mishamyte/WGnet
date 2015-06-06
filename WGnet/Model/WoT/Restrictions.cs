using Newtonsoft.Json;

namespace WGnet.Model.WoT
{
    /// <summary>
    /// Ограничения аккаунта
    /// </summary>
    public class Restrictions
    {
        /// <summary>
        /// Время окончания блокировки в чате
        /// </summary>
        [JsonProperty("chat_ban_time")]
        public long? ChatBanTime { get; set; }

        /// <summary>
        /// Время окончания кланового ограничения
        /// </summary>
        [JsonProperty("clan_time")]
        public long? ClanTime { get; set; }
    }
}
