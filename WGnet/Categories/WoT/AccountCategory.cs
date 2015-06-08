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
        public IEnumerable<Player> List(string search, LanguageField language = LanguageField.RU, string fields = null,
            SearchType searchType = SearchType.StartsWith, int limit = 100)
        {
            WgErrors.ThrowIfNumberIsNegative(() => limit);

            var parameters = new WgParameters
                             {
                                 {"search", search},
                                 {"language", Enum.GetName(typeof (LanguageField), language).ToLower()},
                                 {"fields", fields},
                                 {"type", Enum.GetName(typeof (SearchType), searchType).ToLower()},
                                 {"limit", limit}
                             };
            var response = _wg.Call("account/list/", WgSection.WoT, parameters);

            var obj = JsonConvert.DeserializeObject<WgResponse<List<Player>>>(response);

            return obj.Data;
        }

        /// <summary>
        /// Метод возвращает информацию об игроке
        /// </summary>
        /// <param name="accountId">Идентификатор аккаунта игрока</param>
        /// <param name="accessToken">Ключ доступа к персональным данным пользователя. Имеет срок действия. Для получения ключа доступа необходимо запросить аутентификацию</param>
        /// <param name="language">Язык локализации</param>
        /// <param name="fields">Поля ответа. Поля разделяются запятыми. Вложенные поля разделяются точками. Для исключения поля используется знак «-» перед названием поля. Если параметр не указан, возвращаются все поля</param>
        /// <returns>Словарь, ключ - id пользователя, значение - информация пользователя</returns>
        public IDictionary<long, PlayerInfo> Info(long accountId, string accessToken = null,
            LanguageField language = LanguageField.RU, string fields = null)
        {
            var parameters = new WgParameters
                             {
                                 {"account_id", accountId},
                                 {"access_token", accessToken},
                                 {"language", Enum.GetName(typeof (LanguageField), language).ToLower()},
                                 {"fields", fields},
                             };

            var response = _wg.Call("account/info/", WgSection.WoT, parameters);

            var obj = JsonConvert.DeserializeObject<WgResponse<Dictionary<long, PlayerInfo>>>(response);

            return obj.Data;
        }

        /// <summary>
        /// Метод возвращает информацию об игроке
        /// </summary>
        /// <param name="accountId">Идентификаторы аккаунтов игроков</param>
        /// <param name="accessToken">Ключ доступа к персональным данным пользователя. Имеет срок действия. Для получения ключа доступа необходимо запросить аутентификацию</param>
        /// <param name="language">Язык локализации</param>
        /// <param name="fields">Поля ответа. Поля разделяются запятыми. Вложенные поля разделяются точками. Для исключения поля используется знак «-» перед названием поля. Если параметр не указан, возвращаются все поля</param>
        /// <returns>Словарь, ключ - id пользователя, значение - информация пользователя</returns>
        public IDictionary<long, PlayerInfo> Info(List<long> accountId, string accessToken = null,
            LanguageField language = LanguageField.RU, string fields = null)
        {
            var parameters = new WgParameters
                             {
                                 {"account_id", accountId.ToWgParameter()},
                                 {"access_token", accessToken},
                                 {"language", Enum.GetName(typeof (LanguageField), language).ToLower()},
                                 {"fields", fields},
                             };

            var response = _wg.Call("account/info/", WgSection.WoT, parameters);

            var obj = JsonConvert.DeserializeObject<WgResponse<Dictionary<long, PlayerInfo>>>(response);

            return obj.Data;
        }

        /// <summary>
        /// Метод возвращает информацию о технике игрока
        /// </summary>
        /// <param name="accountId">Идентификатор аккаунта игрока</param>
        /// <param name="tankId">Идентификатор(ы) техники игрока</param>
        /// <param name="accessToken">Ключ доступа к персональным данным пользователя. Имеет срок действия. Для получения ключа доступа необходимо запросить аутентификацию</param>
        /// <param name="language">Язык локализации</param>
        /// <param name="fields">Поля ответа. Поля разделяются запятыми. Вложенные поля разделяются точками. Для исключения поля используется знак «-» перед названием поля. Если параметр не указан, возвращаются все поля</param>
        /// <returns>Словарь, ключ - id пользователя, значение - список с информацией по танкам пользователя</returns>
        public IDictionary<long, List<PlayerTanks>> Tanks(long accountId, string accessToken = null, List<long> tankId = null,
            LanguageField language = LanguageField.RU, string fields = null)
        {
            var parameters = new WgParameters
                             {
                                 {"account_id", accountId},
                                 {"tank_id", tankId.ToWgParameter()},
                                 {"access_token", accessToken},
                                 {"language", Enum.GetName(typeof (LanguageField), language).ToLower()},
                                 {"fields", fields},
                             };

            var response = _wg.Call("account/tanks/", WgSection.WoT, parameters);

            var obj = JsonConvert.DeserializeObject<WgResponse<Dictionary<long, List<PlayerTanks>>>>(response);

            return obj.Data;
        }

        /// <summary>
        /// Метод возвращает информацию о технике игрока
        /// </summary>
        /// <param name="accountId">Идентификаторы аккаунтов игроков</param>
        /// <param name="tankId">Идентификатор(ы) техники игрока</param>
        /// <param name="accessToken">Ключ доступа к персональным данным пользователя. Имеет срок действия. Для получения ключа доступа необходимо запросить аутентификацию</param>
        /// <param name="language">Язык локализации</param>
        /// <param name="fields">Поля ответа. Поля разделяются запятыми. Вложенные поля разделяются точками. Для исключения поля используется знак «-» перед названием поля. Если параметр не указан, возвращаются все поля</param>
        /// <returns>Словарь, ключ - id пользователя, значение - список с информацией по танкам пользователя</returns>
        public IDictionary<long, List<PlayerTanks>> Tanks(List<long> accountId, string accessToken = null, List<long> tankId = null,
            LanguageField language = LanguageField.RU, string fields = null)
        {
            var parameters = new WgParameters
                             {
                                 {"account_id", accountId.ToWgParameter()},
                                 {"tank_id", tankId.ToWgParameter()},
                                 {"access_token", accessToken},
                                 {"language", Enum.GetName(typeof (LanguageField), language).ToLower()},
                                 {"fields", fields},
                             };

            var response = _wg.Call("account/tanks/", WgSection.WoT, parameters);

            var obj = JsonConvert.DeserializeObject<WgResponse<Dictionary<long, List<PlayerTanks>>>>(response);

            return obj.Data;
        }


        /// <summary>
        /// Метод возвращает информацию о достижениях игроков
        /// Значения поля achievements зависят от свойств достижений
        /// См. <see cref="http://ru.wargaming.net/developers/api_reference/wot/encyclopedia/achievements/"/>
        /// </summary>
        /// <param name="accountId">Идентификатор аккаунта игрока</param>
        /// <param name="language">Язык локализации</param>
        /// <param name="fields">Поля ответа. Поля разделяются запятыми. Вложенные поля разделяются точками. Для исключения поля используется знак «-» перед названием поля. Если параметр не указан, возвращаются все поля</param>
        /// <returns>Словарь, ключ - id пользователя, значение - достижения игрока</returns>
        public IDictionary<long, PlayerAchievements> Achievements(long accountId, LanguageField language = LanguageField.RU, string fields = null)
        {
            var parameters = new WgParameters()
                             {
                                 {"account_id", accountId},
                                 {"language", Enum.GetName(typeof (LanguageField), language).ToLower()},
                                 {"fields", fields},
                             };
            var response = _wg.Call("account/achievements/", WgSection.WoT, parameters);

            var obj = JsonConvert.DeserializeObject<WgResponse<Dictionary<long, PlayerAchievements>>>(response);

            return obj.Data;
        }

        /// <summary>
        /// Метод возвращает информацию о достижениях игроков
        /// Значения поля achievements зависят от свойств достижений
        /// См. <see cref="http://ru.wargaming.net/developers/api_reference/wot/encyclopedia/achievements/"/>
        /// </summary>
        /// <param name="accountId">Идентификаторы аккаунтов игрокаов</param>
        /// <param name="language">Язык локализации</param>
        /// <param name="fields">Поля ответа. Поля разделяются запятыми. Вложенные поля разделяются точками. Для исключения поля используется знак «-» перед названием поля. Если параметр не указан, возвращаются все поля</param>
        /// <returns>Словарь, ключ - id пользователя, значение - достижения игрока</returns>
        public IDictionary<long, PlayerAchievements> Achievements(List<long> accountId, LanguageField language = LanguageField.RU, string fields = null)
        {
            var parameters = new WgParameters()
                             {
                                 {"account_id", accountId.ToWgParameter()},
                                 {"language", Enum.GetName(typeof (LanguageField), language).ToLower()},
                                 {"fields", fields},
                             };
            var response = _wg.Call("account/achievements/", WgSection.WoT, parameters);

            var obj = JsonConvert.DeserializeObject<WgResponse<Dictionary<long, PlayerAchievements>>>(response);

            return obj.Data;
        }
    }
}
