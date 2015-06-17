using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace WGnet.Model.WoT.Globalwar
{
    /// <summary>
    /// Расписание турнира
    /// </summary>
    public class GlobalwarTournamentTree
    {
        /// <summary>
        /// Текущий тур
        /// </summary>
        [JsonProperty("current")]
        public bool Current { get; set; }

        /// <summary>
        /// Этап турнира: 
        /// - 0 — бой с владельцем провинции, 
        /// - 1 — финал, 
        /// - 2 — полуфинал и т.д.
        /// </summary>
        [JsonProperty("round_idx")]
        public int RoundIdx { get; set; }

        /// <summary>
        /// Бои тура
        /// См. <see cref="GlobalwarTournamentTreeBattles"/>
        /// </summary>
        [JsonProperty("battles")]
        public ReadOnlyCollection<GlobalwarTournamentTreeBattles> Battles { get; set; }
    }
}
