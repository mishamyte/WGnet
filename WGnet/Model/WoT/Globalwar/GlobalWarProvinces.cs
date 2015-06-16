using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace WGnet.Model.WoT.Globalwar
{
    /// <summary>
    /// Информация о провинции на Глобальной карте
    /// См. описание <see cref="http://ru.wargaming.net/developers/api_reference/wot/globalwar/provinces/"/>
    /// </summary>
    public class GlobalWarProvinces
    {
        /// <summary>
        /// Локализованное название карты
        /// </summary>
        [JsonProperty("arena_i18n")]
        public string ArenaI18N { get; set; }

        /// <summary>
        /// Идентификатор карты
        /// </summary>
        [JsonProperty("arena_id")]
        public string ArenaId { get; set; }

        /// <summary>
        /// Владелец провинции
        /// </summary>
        [JsonProperty("clan_id")]
        public long? ClanId { get; set; }

        /// <summary>
        /// Соседние провинции
        /// </summary>
        [JsonProperty("neighbors")]
        public ReadOnlyCollection<string> Neighbors { get; set; } 

        /// <summary>
        /// Основной регион
        /// </summary>
        [JsonProperty("primary_region")]
        public string PrimaryRegion { get; set; }

        /// <summary>
        /// Прайм-тайм
        /// </summary>
        [JsonProperty("prime_time")]
        public int PrimeTime { get; set; }

        /// <summary>
        /// Название провинции
        /// </summary>
        [JsonProperty("province_i18n")]
        public string ProvinceI18N { get; set; }

        /// <summary>
        /// Идентификатор провинции
        /// </summary>
        [JsonProperty("province_id")]
        public string ProvinceId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("revenue")]
        public int Revenue { get; set; }

        /// <summary>
        /// Идентификатор статуса мятежа в провинции. 
        /// Допустимые значения: 
        /// - normal
        /// - start 
        /// - mutiny 
        /// - delayed_mutiny
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Дата обновления информации о провинциях на карте
        /// </summary>
        [JsonProperty("updated_at")]
        public long UpdatedAt { get; set; }

        /// <summary>
        /// Максимальный уровень техники
        /// </summary>
        [JsonProperty("vehicle_max_level")]
        public int VehicleMaxLevel { get; set; }

        /// <summary>
        /// Регионы
        /// См. <see cref="GlobalWarProvincesRegions"/>
        /// </summary>
        [JsonProperty("regions")]
        public ReadOnlyDictionary<string, GlobalWarProvincesRegions> Regions { get; set; } 
    }
}
