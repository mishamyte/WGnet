using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;
using WGnet.Enums;
using WGnet.Model.WoT.Stronghold;
using WGnet.Utils;

namespace WGnet.Categories.WoT
{
    /// <summary>
    /// Методы для работы с информацией о Укрепрайонах
    /// </summary>
    public class StrongholdCategory
    {
        private readonly WgApi _wg;

        internal StrongholdCategory(WgApi wg)
        {
            _wg = wg;
        }

        /// <summary>
        /// Метод возвращает информацию об Укрепрайоне клана
        /// </summary>
        /// <param name="clanId">Идентификатор клана</param>
        /// <param name="accessToken">Ключ доступа к персональным данным пользователя. Имеет срок действия. Для получения ключа доступа необходимо запросить аутентификацию</param>
        /// <param name="language">Язык локализации</param>
        /// <param name="fields">Поля ответа. Поля разделяются запятыми. Вложенные поля разделяются точками. Для исключения поля используется знак «-» перед названием поля. Если параметр не указан, возвращаются все поля</param>
        /// <returns>Информацию о Укрепрайоне клана</returns>
        public Stronghold Info(long clanId, string accessToken = null, LanguageField? language = null, string fields = null)
        {
            var parameters = new WgParameters
                             {
                                 {"clan_id", clanId},
                                 {"access_token", accessToken},
                                 {"fields", fields},
                             };

            if (language != null)
                parameters.Add("language", Enum.GetName(typeof(LanguageField), language).ToLower());


            var response = _wg.Call("stronghold/info/", WgSection.WoT, parameters);

            var obj = JsonConvert.DeserializeObject<WgResponse<Dictionary<long, Stronghold>>>(response);

            return obj.Data.First().Value;
        }

        /// <summary>
        /// Метод возвращает информацию из энциклопедии обо всех строениях Укрепрайона
        /// </summary>
        /// <param name="language">Язык локализации</param>
        /// <param name="fields">Поля ответа. Поля разделяются запятыми. Вложенные поля разделяются точками. Для исключения поля используется знак «-» перед названием поля. Если параметр не указан, возвращаются все поля</param>
        /// <returns>Словарь, ключ - id здания, значение - информация из энциклопедии о строении</returns>
        public ReadOnlyDictionary<int, StrongholdBuildings> Buildings(LanguageField? language = null, string fields = null)
        {
            var parameters = new WgParameters
                             {
                                 {"fields", fields},
                             };

            if (language != null)
                parameters.Add("language", Enum.GetName(typeof(LanguageField), language).ToLower());


            var response = _wg.Call("stronghold/buildings/", WgSection.WoT, parameters);

            var obj = JsonConvert.DeserializeObject<WgResponse<Dictionary<int, StrongholdBuildings>>>(response);

            return new ReadOnlyDictionary<int, StrongholdBuildings>(obj.Data);
        }

        /// <summary>
        /// Метод возвращает статистику игрока по Укрепрайону текущего клана
        /// </summary>
        /// <param name="accountId">Идентификатор аккаунта игрока</param>
        /// <param name="accessToken">Ключ доступа к персональным данным пользователя. Имеет срок действия. Для получения ключа доступа необходимо запросить аутентификацию.</param>
        /// <param name="language">Язык локализации</param>
        /// <param name="fields">Поля ответа. Поля разделяются запятыми. Вложенные поля разделяются точками. Для исключения поля используется знак «-» перед названием поля. Если параметр не указан, возвращаются все поля</param>
        /// <returns>Словарь, ключ - id клана, значение - статистика игрока по Укрепрайону текущего клана</returns>
        public ReadOnlyDictionary<long, StrongholdAccountStats> AccountStats(long accountId, string accessToken = null,
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


            var response = _wg.Call("stronghold/accountstats/", WgSection.WoT, parameters);

            var obj = JsonConvert.DeserializeObject<WgResponse<Dictionary<long, StrongholdAccountStats>>>(response);

            return new ReadOnlyDictionary<long, StrongholdAccountStats>(obj.Data);
        }

        /// <summary>
        /// Метод возвращает статистику игрока по Укрепрайону текущего клана
        /// </summary>
        /// <param name="accountId">Идентификатор аккаунта игрока</param>
        /// <param name="accessToken">Ключ доступа к персональным данным пользователя. Имеет срок действия. Для получения ключа доступа необходимо запросить аутентификацию.</param>
        /// <param name="language">Язык локализации</param>
        /// <param name="fields">Поля ответа. Поля разделяются запятыми. Вложенные поля разделяются точками. Для исключения поля используется знак «-» перед названием поля. Если параметр не указан, возвращаются все поля</param>
        /// <returns>Словарь, ключ - id клана, значение - статистика игрока по Укрепрайону текущего клана</returns>
        public ReadOnlyDictionary<long, StrongholdAccountStats> AccountStats(List<long> accountId, string accessToken = null,
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


            var response = _wg.Call("stronghold/accountstats/", WgSection.WoT, parameters);

            var obj = JsonConvert.DeserializeObject<WgResponse<Dictionary<long, StrongholdAccountStats>>>(response);

            return new ReadOnlyDictionary<long, StrongholdAccountStats>(obj.Data);
        }
    }
}
