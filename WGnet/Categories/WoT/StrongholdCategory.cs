﻿using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using WGnet.Enums;
using WGnet.Model.WoT;
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
    }
}
