using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WGnet.Model.WoT
{
    /// <summary>
    /// Информация о технике игрока
    /// См. описание <see cref="http://ru.wargaming.net/developers/api_reference/wot/account/tanks/"/>
    /// </summary>
    public class PlayerTanks
    {
        /// <summary>
        /// Знаки классности:
        /// 0 — Отсутствует
        /// 1 — 3 степень
        /// 2 — 2 степень
        /// 3 — 1 степень
        /// 4 — Мастер
        /// </summary>
        [JsonProperty("mark_of_mastery")]
        public int MarkOfMastery { get; set; }

        /// <summary>
        /// Идентификатор техники
        /// </summary>
        [JsonProperty("tank_id")]
        public long TankId { get; set; }

        /// <summary>
        /// Статистика машины
        /// См. <see cref="PlayerTanksStatistics"/>
        /// </summary>
        [JsonProperty("statistics")]
        public PlayerTanksStatistics TanksStatistics { get; set; }
    }
}
