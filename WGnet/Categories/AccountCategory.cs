using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using WGnet.Enums;
using WGnet.Model;
using WGnet.Utils;

namespace WGnet.Categories
{
    public class AccountCategory
    {
        private readonly WgApi _wg;

        internal AccountCategory(WgApi wg)
        {
            _wg = wg;
        }

        public IEnumerable<Player> List(string search, LanguageField language = LanguageField.RU, string fields = null, SearchType searchType = SearchType.StartsWith, int limit = 100)
        {
            var parameters = new WgParameters
                             {
                                 {"search", search},
                                 {"language", Enum.GetName(typeof(LanguageField), language).ToLower()},
                                 {"fields",fields},
                                 {"type", Enum.GetName(typeof(SearchType), searchType).ToLower()}, 
                                 {"limit", limit}
                             };
            var response = _wg.Call("account/list/", parameters);

            var obj = JsonConvert.DeserializeObject<WgResponse<List<Player>>>(response);

            return obj.Data;
        }
    }
}
