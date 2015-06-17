using Newtonsoft.Json;

namespace WGnet.Model.WoT.Globalwar
{
    /// <summary>
    /// Бои тура
    /// </summary>
    public class GlobalwarTournamentTreeBattles
    {
        /// <summary>
        /// Показывает, был ли бой отменён
        /// </summary>
        [JsonProperty("canceled")]
        public bool Canceled { get; set; }

        /// <summary>
        /// Идентификатор первого участника. Если участник еще не определён, полю присваивается значение null.
        /// </summary>
        [JsonProperty("clan1")]
        public long? Clan1 { get; set; }

        /// <summary>
        /// Идентификатор второго участника. Если участник ещё не определён, полю присваивается значение null.
        /// </summary>
        [JsonProperty("clan2")]
        public long? Clan2 { get; set; }

        /// <summary>
        /// Показывает, завершился ли бой ничьей
        /// </summary>
        [JsonProperty("draw")]
        public bool Draw { get; set; }

        /// <summary>
        /// Время начала турнира
        /// </summary>
        [JsonProperty("start_at")]
        public long StartAt { get; set; }

        /// <summary>
        /// Показывает, завершился ли бой технической победой
        /// </summary>
        [JsonProperty("technical")]
        public bool Technical { get; set; }

        /// <summary>
        /// Идентификатор клана победителя. Если победитель ещё не определён или бой завершился ничьей, полю присваивается значение null.
        /// </summary>
        [JsonProperty("winner")]
        public long? Winner { get; set; }
    }
}
