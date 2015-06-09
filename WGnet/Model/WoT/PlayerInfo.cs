using Newtonsoft.Json;

namespace WGnet.Model.WoT
{
    /// <summary>
    /// Информация о игроке
    /// См. описание <see cref="http://ru.wargaming.net/developers/api_reference/wot/account/info/"/>
    /// </summary>
    public class PlayerInfo
    {
        /// <summary>
        /// Идентификатор игрока
        /// </summary>
        [JsonProperty("account_id")]
        public long AccountId { get; set; }

        /// <summary>
        /// Идентификатор клана
        /// </summary>
        [JsonProperty("clan_id")]
        public long? ClanId { get; set; }

        /// <summary>
        /// Язык, выбранный в клиенте игры
        /// </summary>
        [JsonProperty("client_language")]
        public string ClientLanguage { get; set; }

        /// <summary>
        /// Дата создания аккаунта игрока
        /// </summary>
        [JsonProperty("created_at")]
        public long CreatedAt { get; set; }

        /// <summary>
        /// Личный рейтинг
        /// </summary>
        [JsonProperty("global_rating")]
        public long GlobalRating { get; set; }

        /// <summary>
        /// Время последнего боя
        /// </summary>
        [JsonProperty("last_battle_time")]
        public long LastBattleTime { get; set; }

        /// <summary>
        /// Время окончания последней игровой сессии
        /// </summary>
        [JsonProperty("logout_at")]
        public long LogoutAt { get; set; }

        /// <summary>
        /// Имя игрока
        /// </summary>
        [JsonProperty("nickname")]
        public string NickName { get; set; }

        /// <summary>
        /// Дата обновления информации об игроке
        /// </summary>
        [JsonProperty("updated_at")]
        public long UpdatedAt { get; set; }

        /// <summary>
        /// Приватные данные игрока
        /// См. <see cref="PlayerPrivate"/>
        /// </summary>
        [JsonProperty("private")]
        public PlayerPrivate Private { get; set; }

        /// <summary>
        /// Статистика игрока
        /// См. <see cref="PlayerStatistics"/>
        /// </summary>
        [JsonProperty("statistics")]
        public PlayerStatistics Statistics { get; set; }
    }
}
