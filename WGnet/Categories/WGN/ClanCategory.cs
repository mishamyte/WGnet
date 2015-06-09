using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using WGnet.Enums;
using WGnet.Model.WGN;
using WGnet.Utils;

namespace WGnet.Categories.WGN
{
    /// <summary>
    /// Методы для работы с информацией о кланах
    /// </summary>
    public class ClanCategory
    {
        private readonly WgApi _wg;

        internal ClanCategory(WgApi wg)
        {
            _wg = wg;
        }

        /// <summary>
        /// Проводит поиск по кланам и сортирует их в указаном порядке
        /// </summary>
        /// <param name="search">Часть имени или тега клана по которому осуществляется поиск</param>
        /// <param name="language">Язык локализации</param>
        /// <param name="fields">Поля ответа. Поля разделяются запятыми. Вложенные поля разделяются точками. Для исключения поля используется знак «-» перед названием поля. Если параметр не указан, возвращаются все поля</param>
        /// <param name="orderBy">Сортировка</param>
        /// <param name="limit">Количество возвращаемых записей (может вернуться меньше записей, но не больше 100). Если переданный лимит превышает 100, тогда автоматически выставляется лимит в 100 (по умолчанию)</param>
        /// <param name="pageNo">Номер страницы</param>
        /// <returns>Список найденных кланов</returns>
        public ReadOnlyCollection<Clan> List(string search, LanguageField? language = null,
            string fields = null, OrderBy? orderBy = null, int? limit = null, int? pageNo = null)
        {
            var parameters = new WgParameters()
                             {
                                 {"search", search},
                                 {"fields", fields},
                                 {"limit", limit},
                                 {"page_no", pageNo},
                             };

            if (language != null)
                parameters.Add("language", Enum.GetName(typeof(LanguageField), language).ToLower());

            if (orderBy != null)
                parameters.Add("order_by", orderBy.GetEnumDescription());


            var response = _wg.Call("clans/list/", WgSection.WGN, parameters);

            var obj = JsonConvert.DeserializeObject<WgResponse<List<Clan>>>(response);

            return new ReadOnlyCollection<Clan>(obj.Data);
        }
    }
}
