using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace WGnet.Model.WoT.Account
{
    /// <summary>
    /// Приватные данные игрока
    /// </summary>
    public class PlayerPrivate
    {
        /// <summary>
        /// Информация о блокировке аккаунта
        /// </summary>
        [JsonProperty("ban_info")]
        public string BanInfo { get; set; }

        /// <summary>
        /// Время окончания блокировки аккаунта
        /// </summary>
        [JsonProperty("ban_time")]
        public long? BanTime { get; set; }

        /// <summary>
        /// Общее время в бою до уничтожения в секундах
        /// </summary>
        [JsonProperty("battle_life_time")]
        public long BattleLifeTime { get; set; }

        /// <summary>
        /// Кредиты
        /// </summary>
        [JsonProperty("credits")]
        public long Credits { get; set; }

        /// <summary>
        /// Свободный опыт
        /// </summary>
        [JsonProperty("free_xp")]
        public long FreeXp { get; set; }

        /// <summary>
        /// Идентификаторы аккаунтов друзей игрока
        /// </summary>
        [JsonProperty("friends")]
        public ReadOnlyCollection<long> Friends { get; set; } 

        /// <summary>
        /// Золото
        /// </summary>
        [JsonProperty("gold")]
        public long Gold { get; set; }

        /// <summary>
        /// Показывает, привязан ли аккаунт к номеру мобильного телефона
        /// </summary>
        [JsonProperty("is_bound_to_phone")]
        public bool IsBoundToPhone { get; set; }

        /// <summary>
        /// Показывает, является ли аккаунт премиум аккаунтом
        /// </summary>
        [JsonProperty("is_premium")]
        public bool IsPremium { get; set; }

        /// <summary>
        /// Срок действия премиум аккаунта
        /// </summary>
        [JsonProperty("premium_expires_at")]
        public long PremiumExpiresAt { get; set; }

        /// <summary>
        /// Ограничения аккаунта
        /// См. <see cref="Account.Restrictions"/>
        /// </summary>
        [JsonProperty("restrictions")]
        public Restrictions Restrictions { get; set; }
    }
}
