using WGnet.Categories.WoT;
using WGnet.Model.WoT;

namespace WGnet.Categories
{
    /// <summary>
    /// API для работы с фабриками WG API, относящимся к WoT
    /// </summary>
    public class WoTCategory
    {
        /// <summary>
        /// API для работы с игроками
        /// См. <see cref="AccountCategory"/>
        /// </summary>
        public AccountCategory Account { get; private set; }
        /// <summary>
        /// API для работы с Укрепрайонами
        /// См. <see cref="StrongholdCategory"/>
        /// </summary>
        public StrongholdCategory Stronghold { get; private set; }

        internal WoTCategory(WgApi wg)
        {
            Account = new AccountCategory(wg);
            Stronghold = new StrongholdCategory(wg);
        }
    }
}
