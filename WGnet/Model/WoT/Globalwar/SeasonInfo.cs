using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace WGnet.Model.WoT.Globalwar
{
    /// <summary>
    /// Информация о последнем сезоне
    /// </summary>
    public class SeasonInfo
    {
        /// <summary>
        /// Дата окончания
        /// </summary>
        [JsonProperty("finish_at")]
        public long FinishAt { get; set; }

        /// <summary>
        /// Локализованное название
        /// </summary>
        [JsonProperty("name_i18n")]
        public string NameI18N { get; set; }

        /// <summary>
        /// Дата начала
        /// </summary>
        [JsonProperty("start_at")]
        public long StartAt { get; set; }

        /// <summary>
        /// Статус:
        /// - planned - планируется к запуску
        /// - in_progress - запущен
        /// - finished - завершен
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Информация об этапах сезона
        /// См. <see cref="SeasonInfoSteps"/>
        /// </summary>
        [JsonProperty("steps")]
        public ReadOnlyCollection<SeasonInfoSteps> Steps { get; set; }
    }
}
