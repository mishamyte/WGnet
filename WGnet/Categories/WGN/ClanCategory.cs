using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using WGnet.Enums;
using WGnet.Model.WGN.Clan;
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

        /// <summary>
        /// Метод возвращает полную информацию о клане
        /// </summary>
        /// <param name="clanId">Идентификатор клана</param>
        /// <param name="accessToken">Ключ доступа к персональным данным пользователя. Имеет срок действия. Для получения ключа доступа необходимо запросить аутентификацию</param>
        /// <param name="language">Язык локализации</param>
        /// <param name="fields">Поля ответа. Поля разделяются запятыми. Вложенные поля разделяются точками. Для исключения поля используется знак «-» перед названием поля. Если параметр не указан, возвращаются все поля</param>
        /// <returns>Словарь, ключ - id клана, значение - информация о клане</returns>
        public ReadOnlyDictionary<long, ClanInfo> Info(long clanId, string accessToken = null,
            LanguageField? language = null, string fields = null)
        {
            var parameters = new WgParameters
                             {
                                 {"clan_id", clanId},
                                 {"access_token", accessToken},
                                 {"fields", fields},
                             };

            if (language != null)
                parameters.Add("language", Enum.GetName(typeof(LanguageField), language).ToLower());


            var response = _wg.Call("clans/info/", WgSection.WGN, parameters);

            var obj = JsonConvert.DeserializeObject<WgResponse<Dictionary<long, ClanInfo>>>(response);

            return new ReadOnlyDictionary<long, ClanInfo>(obj.Data);
        }

        /// <summary>
        /// Метод возвращает полную информацию о кланах
        /// </summary>
        /// <param name="clanId">Идентификаторы кланов</param>
        /// <param name="accessToken">Ключ доступа к персональным данным пользователя. Имеет срок действия. Для получения ключа доступа необходимо запросить аутентификацию</param>
        /// <param name="language">Язык локализации</param>
        /// <param name="fields">Поля ответа. Поля разделяются запятыми. Вложенные поля разделяются точками. Для исключения поля используется знак «-» перед названием поля. Если параметр не указан, возвращаются все поля</param>
        /// <returns>Словарь, ключ - id клана, значение - информация о клане</returns>
        public ReadOnlyDictionary<long, ClanInfo> Info(List<long> clanId, string accessToken = null,
            LanguageField? language = null, string fields = null)
        {
            var parameters = new WgParameters
                             {
                                 {"clan_id", clanId.ToWgParameter()},
                                 {"access_token", accessToken},
                                 {"fields", fields},
                             };

            if (language != null)
                parameters.Add("language", Enum.GetName(typeof(LanguageField), language).ToLower());


            var response = _wg.Call("clans/info/", WgSection.WGN, parameters);

            var obj = JsonConvert.DeserializeObject<WgResponse<Dictionary<long, ClanInfo>>>(response);

            return new ReadOnlyDictionary<long, ClanInfo>(obj.Data);
        }

        /// <summary>
        /// Метод возвращает информацию об игроке и краткую информацию о клане, в котором он состоит
        /// </summary>
        /// <param name="accountId">Идентификатор игрока</param>
        /// <param name="language">Язык локализации</param>
        /// <param name="fields">Поля ответа. Поля разделяются запятыми. Вложенные поля разделяются точками. Для исключения поля используется знак «-» перед названием поля. Если параметр не указан, возвращаются все поля</param>
        /// <returns>Словарь, ключ - id игрока, значение - информация о игроке в рамках клана</returns>
        public ReadOnlyDictionary<long, ClanMembersInfo> MembersInfo(long accountId, LanguageField? language = null,
            string fields = null)
        {
            var parameters = new WgParameters
                             {
                                 {"account_id", accountId},
                                 {"fields", fields},
                             };

            if (language != null)
                parameters.Add("language", Enum.GetName(typeof(LanguageField), language).ToLower());


            var response = _wg.Call("clans/membersinfo/", WgSection.WGN, parameters);

            var obj = JsonConvert.DeserializeObject<WgResponse<Dictionary<long, ClanMembersInfo>>>(response);

            return new ReadOnlyDictionary<long, ClanMembersInfo>(obj.Data);
        }

        /// <summary>
        /// Метод возвращает информацию об игроках и краткую информацию о кланах, в которых они состоят
        /// </summary>
        /// <param name="accountId">Идентификаторы игроков</param>
        /// <param name="language">Язык локализации</param>
        /// <param name="fields">Поля ответа. Поля разделяются запятыми. Вложенные поля разделяются точками. Для исключения поля используется знак «-» перед названием поля. Если параметр не указан, возвращаются все поля</param>
        /// <returns>Словарь, ключ - id игрока, значение - информация о игроке в рамках клана</returns>
        public ReadOnlyDictionary<long, ClanMembersInfo> MembersInfo(List<long> accountId, LanguageField? language = null,
            string fields = null)
        {
            var parameters = new WgParameters
                             {
                                 {"account_id", accountId.ToWgParameter()},
                                 {"fields", fields},
                             };

            if (language != null)
                parameters.Add("language", Enum.GetName(typeof(LanguageField), language).ToLower());


            var response = _wg.Call("clans/membersinfo/", WgSection.WGN, parameters);

            var obj = JsonConvert.DeserializeObject<WgResponse<Dictionary<long, ClanMembersInfo>>>(response);

            return new ReadOnlyDictionary<long, ClanMembersInfo>(obj.Data);
        }

        /// <summary>
        /// Метод возвращает информацию о клановых сущностях
        /// </summary>
        /// <param name="language">Язык локализации</param>
        /// <param name="fields">Поля ответа. Поля разделяются запятыми. Вложенные поля разделяются точками. Для исключения поля используется знак «-» перед названием поля. Если параметр не указан, возвращаются все поля</param>
        /// <returns>Возможные должности игроков в клане</returns>
        public ClanRoles Glossary(LanguageField? language = null, string fields = null)
        {
            var parameters = new WgParameters
                             {
                                 {"fields", fields},
                             };

            if (language != null)
                parameters.Add("language", Enum.GetName(typeof(LanguageField), language).ToLower());


            var response = _wg.Call("clans/glossary/", WgSection.WGN, parameters);

            var obj = JsonConvert.DeserializeObject<WgResponse<ClanRoles>>(response);

            return obj.Data;
        }

    }
}
