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
        public ReadOnlyCollection<GlobalwarClan> Clans(string mapId, LanguageField? language = null,
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

            var obj = JsonConvert.DeserializeObject<WgResponse<List<GlobalwarClan>>>(response);

            return new ReadOnlyCollection<GlobalwarClan>(obj.Data);
        }
           
    }
}
