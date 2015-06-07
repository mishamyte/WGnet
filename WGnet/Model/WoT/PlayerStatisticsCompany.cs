using Newtonsoft.Json;

namespace WGnet.Model.WoT
{
    /// <summary>
    /// Статистика боёв в составе роты
    /// </summary>
    public class PlayerStatisticsCompany
    {
        /// <summary>
        /// Средний урон, нанесённый с вашей помощью. Значение считается с версии игры 8.8.
        /// </summary>
        [JsonProperty("avg_damage_assisted")]
        public float AvgDamageAssisted { get; set; }

        /// <summary>
        /// Средний урон по вашим разведданным. Значение считается с версии игры 8.8.
        /// </summary>
        [JsonProperty("avg_damage_assisted_radio")]
        public float AvgDamageAssistedRadio { get; set; }

        /// <summary>
        /// Средний урон после вашего попадания, сбившего гусеницу. Значение считается с версии игры 8.8.
        /// </summary>
        [JsonProperty("avg_damage_assisted_track")]
        public float AvgDamageAssistedTrack { get; set; }

        /// <summary>
        /// Средний заблокированный бронёй урон за бой. Заблокированный бронёй урон — это урон от снарядов (бронебойных, кумулятивных и подкалиберных), которые попали в танк, но не нанесли урона. Значение считается с версии игры 9.0.
        /// </summary>
        [JsonProperty("avg_damage_blocked")]
        public float AvgDamageBlocked { get; set; }

        /// <summary>
        /// Средний опыт за бой
        /// </summary>
        [JsonProperty("battle_avg_xp")]
        public long BattleAvgXp { get; set; }

        /// <summary>
        /// Проведено боёв
        /// </summary>
        [JsonProperty("battles")]
        public long Battles { get; set; }

        /// <summary>
        /// Очки захвата базы
        /// </summary>
        [JsonProperty("capture_points")]
        public long CapturePoints { get; set; }

        /// <summary>
        /// Нанесено повреждений
        /// </summary>
        [JsonProperty("damage_dealt")]
        public long DamageDealt { get; set; }

        /// <summary>
        /// Получено урона
        /// </summary>
        [JsonProperty("damage_received")]
        public long DamageReceived { get; set; }

        /// <summary>
        /// Количество полученных прямых попаданий
        /// </summary>
        [JsonProperty("direct_hits_received")]
        public long DirectHitsReceived { get; set; }

        /// <summary>
        /// Ничьи
        /// </summary>
        [JsonProperty("draws")]
        public long Draws { get; set; }

        /// <summary>
        /// Очки защиты базы
        /// </summary>
        [JsonProperty("dropped_capture_points")]
        public long DroppedCapturePoints { get; set; }

        /// <summary>
        /// Количество нанесённых осколочно-фугасных попаданий
        /// </summary>
        [JsonProperty("explosion_hits")]
        public long ExplosionHits { get; set; }

        /// <summary>
        /// Количество полученных осколочно-фугасных попаданий
        /// </summary>
        [JsonProperty("explosion_hits_received")]
        public long ExplosionHitsReceived { get; set; }

        /// <summary>
        /// Уничтожено техники
        /// </summary>
        [JsonProperty("frags")]
        public long Frags { get; set; }

        /// <summary>
        /// Попадания
        /// </summary>
        [JsonProperty("hits")]
        public long Hits { get; set; }

        /// <summary>
        /// Процент попаданий
        /// </summary>
        [JsonProperty("hits_percents")]
        public long HitsPercents { get; set; }

        /// <summary>
        /// Поражения
        /// </summary>
        [JsonProperty("losses")]
        public long Losses { get; set; }

        /// <summary>
        /// Количество полученных прямых попаданий, не нанёсших урон
        /// </summary>
        [JsonProperty("no_damage_direct_hits_received")]
        public long NoDamageDirectHitsReceived { get; set; }

        /// <summary>
        /// Количество пробитий
        /// </summary>
        [JsonProperty("piercings")]
        public long Piercings { get; set; }

        /// <summary>
        /// Количество полученных пробитий
        /// </summary>
        [JsonProperty("piercings_received")]
        public long PiercingsReceived { get; set; }

        /// <summary>
        /// Произведено выстрелов
        /// </summary>
        [JsonProperty("shots")]
        public long Shots { get; set; }

        /// <summary>
        /// Обнаружено противников
        /// </summary>
        [JsonProperty("spotted")]
        public long Spotted { get; set; }

        /// <summary>
        /// Выжил в боях
        /// </summary>
        [JsonProperty("survived_battles")]
        public long SurvivedBattles { get; set; }

        /// <summary>
        /// Отношение заблокированного бронёй урона к полученному игроком урону от бронебойных, кумулятивных, подкалиберных снарядов. Значение считается с версии игры 9.0.
        /// </summary>
        [JsonProperty("tanking_factor")]
        public float TankingFactor { get; set; }

        /// <summary>
        /// Победы
        /// </summary>
        [JsonProperty("wins")]
        public long Wins { get; set; }

        /// <summary>
        /// Суммарный опыт
        /// </summary>
        [JsonProperty("xp")]
        public long Xp { get; set; }
    }
}
