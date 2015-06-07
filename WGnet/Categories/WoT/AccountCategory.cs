using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using WGnet.Enums;
using WGnet.Model.WoT;
using WGnet.Utils;

namespace WGnet.Categories.WoT
{
    /// <summary>
    /// Методы для работы с информацией о игроках
    /// </summary>
    public class AccountCategory
    {
        private readonly WgApi _wg;

        internal AccountCategory(WgApi wg)
        {
            _wg = wg;
        }

        /// <summary>
        /// Метод возвращает часть списка игроков, отфильтрованную по первым символам имени и отсортированную по алфавиту
        /// </summary>
        /// <param name="search">Строка поиска по имени игрока. Вид поиска и минимальная длина строки поиска зависят от параметра searchType. Максимальная длина: 24 символа</param>
        /// <param name="language">Язык локализации</param>
        /// <param name="fields">Поля ответа. Поля разделяются запятыми. Вложенные поля разделяются точками. Для исключения поля используется знак «-» перед названием поля. Если параметр не указан, возвращаются все поля</param>
        /// <param name="searchType">Тип поиска. Определяет минимальную длину строки поиска и вид поиска. По умолчанию используется значение startswith</param>
        /// <param name="limit">Количество возвращаемых записей (может вернуться меньше записей, но не больше 100). Если переданный лимит превышает 100, тогда автоматически выставляется лимит в None (по умолчанию)</param>
        /// <returns>Список найденных игроков</returns>
        public IEnumerable<Player> List(string search, LanguageField language = LanguageField.RU, string fields = null, SearchType searchType = SearchType.StartsWith, int limit = 100)
        {
            WgErrors.ThrowIfNumberIsNegative(() => limit);

            var parameters = new WgParameters
                             {
                                 {"search", search},
                                 {"language", Enum.GetName(typeof(LanguageField), language).ToLower()},
                                 {"fields",fields},
                                 {"type", Enum.GetName(typeof(SearchType), searchType).ToLower()}, 
                                 {"limit", limit}
                             };
            var response = _wg.Call("account/list/", WgSection.WoT, parameters);

            var obj = JsonConvert.DeserializeObject<WgResponse<List<Player>>>(response);

            return obj.Data;
        }

        /// <summary>
        /// Метод возвращает информацию об игроке
        /// </summary>
        /// <param name="accountId">Идентификатор(ы) аккаунта(ов) игрока(ов)</param>
        /// <param name="accessToken">Ключ доступа к персональным данным пользователя. Имеет срок действия. Для получения ключа доступа необходимо запросить аутентификацию</param>
        /// <param name="language">Язык локализации</param>
        /// <param name="fields">Поля ответа. Поля разделяются запятыми. Вложенные поля разделяются точками. Для исключения поля используется знак «-» перед названием поля. Если параметр не указан, возвращаются все поля</param>
        /// <returns>Словарь, ключ - id пользователя, значение - информация пользователя</returns>
        public IDictionary<int, PlayerInfo> Info(List<long> accountId, string accessToken = null, LanguageField language = LanguageField.RU, string fields = null)
        {
            var builder = new StringBuilder();
            foreach (var l in accountId)
            {
                if (l.Equals(accountId.Last())) builder.Append(l);
                else builder.AppendFormat("{0},", l);
            }
            var parameters = new WgParameters
                             {
                                 {"account_id", builder.ToString()},
                                 {"access_token", accessToken},
                                 {"language", Enum.GetName(typeof(LanguageField), language).ToLower()},
                                 {"fields",fields},
                             };

            var response = _wg.Call("account/info/", WgSection.WoT, parameters);

            var obj = JsonConvert.DeserializeObject<WgResponse<Dictionary<int, PlayerInfo>>>(response);

            return obj.Data;
        }      
    }
}
