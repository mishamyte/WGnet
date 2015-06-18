using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using WGnet.Enums;
using WGnet.Model.WoT.Globalwar;
using WGnet.Utils;

namespace WGnet.Categories.WoT
{
    /// <summary>
    /// Методы для работы с информацией о "Мировой войне"
    /// </summary>
    public class GlobalwarCategory
    {
        private readonly WgApi _wg;

        internal GlobalwarCategory(WgApi wg)
        {
            _wg = wg;
        }

        /// <summary>
        /// Метод возвращает список кланов, участвующих в «Мировой войне»
        /// </summary>
        /// <param name="mapId">Идентификатор Глобальной карты</param>
        /// <param name="language">Язык локализации</param>
        /// <param name="fields">Поля ответа. Поля разделяются запятыми. Вложенные поля разделяются точками. Для исключения поля используется знак «-» перед названием поля. Если параметр не указан, возвращаются все поля</param>
        /// <param name="limit">Количество возвращаемых записей (может вернуться меньше записей, но не больше 100). Если переданный лимит превышает 100, тогда автоматически выставляется лимит в 100 (по умолчанию).</param>
        /// <param name="pageNo">Номер страницы результатов</param>
        /// <returns>Список информации про кланы в контексте "Мировой войны"</returns>
        public ReadOnlyCollection<GlobalwarClans> Clans(string mapId, LanguageField? language = null,
            string fields = null, int? limit = null, int? pageNo = null)
        {
            var parameters = new WgParameters
                             {
                                 {"map_id", mapId},
                                 {"fields", fields},
                                 {"limit", limit},
                                 {"page_no", pageNo},
                             };

            if (language != null)
                parameters.Add("language", Enum.GetName(typeof(LanguageField), language).ToLower());

            var response = _wg.Call("globalwar/clans/", WgSection.WoT, parameters);

            var obj = JsonConvert.DeserializeObject<WgResponse<List<GlobalwarClans>>>(response);

            return new ReadOnlyCollection<GlobalwarClans>(obj.Data);
        }

        /// <summary>
        /// Метод возвращает информацию обо всех картах на Глобальной карте. Для каждой карты доступна информация о последнем сезоне.
        /// </summary>
        /// <param name="language">Язык локализации</param>
        /// <param name="fields">Поля ответа. Поля разделяются запятыми. Вложенные поля разделяются точками. Для исключения поля используется знак «-» перед названием поля. Если параметр не указан, возвращаются все поля</param>
        /// <returns>Список информации о картах</returns>
        public ReadOnlyCollection<GlobalwarMaps> Maps(LanguageField? language = null, string fields = null)
        {
            var parameters = new WgParameters
                             {
                                 {"fields", fields},
                             };

            if (language != null)
                parameters.Add("language", Enum.GetName(typeof(LanguageField), language).ToLower());

            var response = _wg.Call("globalwar/maps/", WgSection.WoT, parameters);

            var obj = JsonConvert.DeserializeObject<WgResponse<List<GlobalwarMaps>>>(response);

            return new ReadOnlyCollection<GlobalwarMaps>(obj.Data);
        }

        /// <summary>
        /// Метод возвращает список провинций на Глобальной карте
        /// </summary>
        /// <param name="mapId">Идентификатор Глобальной карты</param>
        /// <param name="provinceId">Идентификатор провинции</param>
        /// <param name="regionId">Идентификатор региона</param>
        /// <param name="status">Идентификатор статуса мятежа в провинции</param>
        /// <param name="language">Язык локализации</param>
        /// <param name="fields">Поля ответа. Поля разделяются запятыми. Вложенные поля разделяются точками. Для исключения поля используется знак «-» перед названием поля. Если параметр не указан, возвращаются все поля</param>
        /// <returns>Словарь - ключ - id провинции, значение - информация про провинцию</returns>
        public ReadOnlyDictionary<string, GlobalWarProvinces> Provinces(string mapId, List<string> provinceId = null,
            List<string> regionId = null, ProvinceStatus? status = null, LanguageField? language = null,
            string fields = null)
        {
            var parameters = new WgParameters
                             {
                                 {"map_id", mapId},
                                 {"province_id", provinceId.ToWgParameter()},
                                 {"region_id", regionId.ToWgParameter()},
                                 {"fields", fields},
                             };

            if (language != null)
                parameters.Add("language", Enum.GetName(typeof(LanguageField), language).ToLower());

            if (status != null)
                parameters.Add("status", status.GetEnumDescription());

            var response = _wg.Call("globalwar/provinces/", WgSection.WoT, parameters);

            var obj = JsonConvert.DeserializeObject<WgResponse<Dictionary<string, GlobalWarProvinces>>>(response);

            return new ReadOnlyDictionary<string, GlobalWarProvinces>(obj.Data);
        }

        /// <summary>
        /// Метод возвращает список турниров на выбранной Глобальной карте
        /// </summary>
        /// <param name="mapId">Идентификатор Глобальной карты</param>
        /// <param name="provinceId">Идентификатор провинции</param>
        /// <param name="language">Язык локализации</param>
        /// <param name="fields">Поля ответа. Поля разделяются запятыми. Вложенные поля разделяются точками. Для исключения поля используется знак «-» перед названием поля. Если параметр не указан, возвращаются все поля</param>
        /// <returns>Список турниров на Глобальной карте</returns>
        public ReadOnlyCollection<GlobalwarTournaments> Tournaments(string mapId, string provinceId,
            LanguageField? language = null, string fields = null)
        {
            var parameters = new WgParameters
                             {
                                 {"map_id", mapId},
                                 {"province_id", provinceId},
                                 {"fields", fields},
                             };

            if (language != null)
                parameters.Add("language", Enum.GetName(typeof(LanguageField), language).ToLower());

            var response = _wg.Call("globalwar/tournaments/", WgSection.WoT, parameters);

            var obj = JsonConvert.DeserializeObject<WgResponse<List<GlobalwarTournaments>>>(response);

            return new ReadOnlyCollection<GlobalwarTournaments>(obj.Data);

        }

        /// <summary>
        /// Метод возвращает список турниров на выбранной Глобальной карте
        /// </summary>
        /// <param name="mapId">Идентификатор Глобальной карты</param>
        /// <param name="provinceId">Список идентификаторов провинций. Можно передавать до 10 провинций.</param>
        /// <param name="language">Язык локализации</param>
        /// <param name="fields">Поля ответа. Поля разделяются запятыми. Вложенные поля разделяются точками. Для исключения поля используется знак «-» перед названием поля. Если параметр не указан, возвращаются все поля</param>
        /// <returns>Список турниров на Глобальной карте</returns>
        public ReadOnlyCollection<GlobalwarTournaments> Tournaments(string mapId, List<string> provinceId,
            LanguageField? language = null, string fields = null)
        {
            var parameters = new WgParameters
                             {
                                 {"map_id", mapId},
                                 {"province_id", provinceId.ToWgParameter()},
                                 {"fields", fields},
                             };

            if (language != null)
                parameters.Add("language", Enum.GetName(typeof(LanguageField), language).ToLower());

            var response = _wg.Call("globalwar/tournaments/", WgSection.WoT, parameters);

            var obj = JsonConvert.DeserializeObject<WgResponse<List<GlobalwarTournaments>>>(response);

            return new ReadOnlyCollection<GlobalwarTournaments>(obj.Data);

        }
    }
}
