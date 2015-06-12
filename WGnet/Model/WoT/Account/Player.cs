using Newtonsoft.Json;

namespace WGnet.Model.WoT.Account
{
    /// <summary>
    /// Базовая информация о игроке
    /// См. описание <see cref="http://ru.wargaming.net/developers/api_reference/wot/account/list/"/>
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Идентификатор аккаунта игрока
        /// </summary>
        [JsonProperty("account_id")]
        public long AccountId { get; set; } 

        /// <summary>
        /// Имя игрока
        /// </summary>
        [JsonProperty("nickname")]
        public string NickName { get; set; }
    }
}
