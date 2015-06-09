using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ReadOnlyCollection<Player> List(string search, LanguageField? language = null, string fields = null,
            SearchType? searchType = null, int? limit = null)
        {
            WgErrors.ThrowIfNumberIsNegative(() => limit);

            var parameters = new WgParameters
                             {
                                 {"search", search},
                                 {"fields", fields},
                                 {"limit", limit}
                             };

            if (language != null)
                parameters.Add("language",Enum.GetName(typeof (LanguageField), language).ToLower());

            if(searchType != null)
                parameters.Add("type", Enum.GetName(typeof(SearchType), searchType).ToLower());


            var response = _wg.Call("account/list/", WgSection.WoT, parameters);

            var obj = JsonConvert.DeserializeObject<WgResponse<List<Player>>>(response);

            return new ReadOnlyCollection<Player>(obj.Data);
        }

        /// <summary>
        /// Метод возвращает информацию об игроке
        /// </summary>
        /// <param name="accountId">Идентификатор аккаунта игрока</param>
        /// <param name="accessToken">Ключ доступа к персональным данным пользователя. Имеет срок действия. Для получения ключа доступа необходимо запросить аутентификацию</param>
        /// <param name="language">Язык локализации</param>
        /// <param name="fields">Поля ответа. Поля разделяются запятыми. Вложенные поля разделяются точками. Для исключения поля используется знак «-» перед названием поля. Если параметр не указан, возвращаются все поля</param>
        /// <returns>Словарь, ключ - id пользователя, значение - информация пользователя</returns>
        public ReadOnlyDictionary<long, PlayerInfo> Info(long accountId, string accessToken = null,
            LanguageField? language = null, string fields = null)
        {
            var parameters = new WgParameters
                             {
                                 {"account_id", accountId},
                                 {"access_token", accessToken},
                                 {"fields", fields},
                             };

            if (language != null)
                parameters.Add("language", Enum.GetName(typeof(LanguageField), language).ToLower());


            var response = _wg.Call("account/info/", WgSection.WoT, parameters);

            var obj = JsonConvert.DeserializeObject<WgResponse<Dictionary<long, PlayerInfo>>>(response);

            return new ReadOnlyDictionary<long, PlayerInfo>(obj.Data);
        }

        /// <summary>
        /// Метод возвращает информацию об игроке
        /// </summary>
        /// <param name="accountId">Идентификаторы аккаунтов игроков</param>
        /// <param name="accessToken">Ключ доступа к персональным данным пользователя. Имеет срок действия. Для получения ключа доступа необходимо запросить аутентификацию</param>
        /// <param name="language">Язык локализации</param>
        /// <param name="fields">Поля ответа. Поля разделяются запятыми. Вложенные поля разделяются точками. Для исключения поля используется знак «-» перед названием поля. Если параметр не указан, возвращаются все поля</param>
        /// <returns>Словарь, ключ - id пользователя, значение - информация пользователя</returns>
        public ReadOnlyDictionary<long, PlayerInfo> Info(List<long> accountId, string accessToken = null,
            LanguageField? language = null, string fields = null)
        {
            var parameters = new WgParameters
                             {
                                 {"account_id", accountId.ToWgParameter()},
                                 {"access_token", accessToken},
                                 {"fields", fields},
                             };

            if (language != null)
                parameters.Add("language", Enum.GetName(typeof(LanguageField), language).ToLower());


            var response = _wg.Call("account/info/", WgSection.WoT, parameters);

            var obj = JsonConvert.DeserializeObject<WgResponse<Dictionary<long, PlayerInfo>>>(response);

            return new ReadOnlyDictionary<long, PlayerInfo>(obj.Data);
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
        public ReadOnlyDictionary<long, List<PlayerTanks>> Tanks(long accountId, string accessToken = null, List<long> tankId = null,
            LanguageField? language = null, string fields = null)
        {
            var parameters = new WgParameters
                             {
                                 {"account_id", accountId},
                                 {"tank_id", tankId.ToWgParameter()},
                                 {"access_token", accessToken},
                                 {"fields", fields},
                             };


            if (language != null)
                parameters.Add("language", Enum.GetName(typeof(LanguageField), language).ToLower());


            var response = _wg.Call("account/tanks/", WgSection.WoT, parameters);

            var obj = JsonConvert.DeserializeObject<WgResponse<Dictionary<long, List<PlayerTanks>>>>(response);

            return new ReadOnlyDictionary<long, List<PlayerTanks>>(obj.Data);
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
        public ReadOnlyDictionary<long, List<PlayerTanks>> Tanks(List<long> accountId, string accessToken = null, List<long> tankId = null,
            LanguageField? language = null, string fields = null)
        {
            var parameters = new WgParameters
                             {
                                 {"account_id", accountId.ToWgParameter()},
                                 {"tank_id", tankId.ToWgParameter()},
                                 {"access_token", accessToken},
                                 {"fields", fields},
                             };

            if (language != null)
                parameters.Add("language", Enum.GetName(typeof(LanguageField), language).ToLower());


            var response = _wg.Call("account/tanks/", WgSection.WoT, parameters);

            var obj = JsonConvert.DeserializeObject<WgResponse<Dictionary<long, List<PlayerTanks>>>>(response);

            return new ReadOnlyDictionary<long, List<PlayerTanks>>(obj.Data);
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
        public ReadOnlyDictionary<long, PlayerAchievements> Achievements(long accountId, LanguageField? language = null, string fields = null)
        {
            var parameters = new WgParameters()
                             {
                                 {"account_id", accountId},
                                 {"fields", fields},
                             };

            if (language != null)
                parameters.Add("language", Enum.GetName(typeof(LanguageField), language).ToLower());


            var response = _wg.Call("account/achievements/", WgSection.WoT, parameters);

            var obj = JsonConvert.DeserializeObject<WgResponse<Dictionary<long, PlayerAchievements>>>(response);

            return new ReadOnlyDictionary<long, PlayerAchievements>(obj.Data);
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
        public ReadOnlyDictionary<long, PlayerAchievements> Achievements(List<long> accountId, LanguageField? language = null, string fields = null)
        {
            var parameters = new WgParameters()
                             {
                                 {"account_id", accountId.ToWgParameter()},
                                 {"fields", fields},
                             };

            if (language != null)
                parameters.Add("language", Enum.GetName(typeof(LanguageField), language).ToLower());


            var response = _wg.Call("account/achievements/", WgSection.WoT, parameters);

            var obj = JsonConvert.DeserializeObject<WgResponse<Dictionary<long, PlayerAchievements>>>(response);

            return new ReadOnlyDictionary<long, PlayerAchievements>(obj.Data);
        }
    }
}
