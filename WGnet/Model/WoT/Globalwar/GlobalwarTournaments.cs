using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace WGnet.Model.WoT.Globalwar
{
    /// <summary>
    /// Информация о турнирах на Глобальной карте
    /// См. описание <see cref="http://ru.wargaming.net/developers/api_reference/wot/globalwar/tournaments/"/>
    /// </summary>
    public class GlobalwarTournaments
    {
        /// <summary>
        /// Список участников
        /// </summary>
        [JsonProperty("competitors")]
        public ReadOnlyCollection<long> Competitors { get; set; } 

        /// <summary>
        /// Время окончания. Если турнир не завершён, полю присваивается значение null.
        /// </summary>
        [JsonProperty("finish_time")]
        public long? FinishTime { get; set; }

        /// <summary>
        /// Максимальное количество участников
        /// </summary>
        [JsonProperty("max_competitors")]
        public int MaxCompetitors { get; set; }

        /// <summary>
        /// Локализованное название провинции
        /// </summary>
        [JsonProperty("province_i18n")]
        public string ProvinceI18N { get; set; }

        /// <summary>
        /// Идентификатор провинции
        /// </summary>
        [JsonProperty("province_id")]
        public string ProvinceId { get; set; }

        /// <summary>
        /// Тип провинции: 
        /// - normal - Обычная провинция 
        /// - start - Стартовая провинция 
        /// - gold - Ключевая провинция 
        /// - mutiny - Мятежная провинция 
        /// - delayed_mutiny - Провинция с отложенным мятежом
        /// </summary>
        [JsonProperty("province_status")]
        public string ProvinceStatus { get; set; }

        /// <summary>
        /// Время начала. Если время начала пока неизвестно, полю присваивается значение null.
        /// </summary>
        [JsonProperty("start_time")]
        public long? StartTime { get; set; }

        /// <summary>
        /// Статус турнира: 
        /// - 0 - запланированный, 
        /// - 1 - в процессе, 
        /// - 2 - завершённый.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Дата обновления информации о боях клана
        /// </summary>
        [JsonProperty("updated_at")]
        public long UpdatedAt { get; set; }

        /// <summary>
        /// Победитель. Если победитель ещё не определён, полю присваивается значение null.
        /// </summary>
        [JsonProperty("winner")]
        public long? Winner { get; set; }

        /// <summary>
        /// Расписание турнира
        /// См. <see cref="GlobalwarTournamentTree"/>
        /// </summary>
        [JsonProperty("tournament_tree")]
        public ReadOnlyCollection<GlobalwarTournamentTree> TournamentTree { get; set; }
    }
}
