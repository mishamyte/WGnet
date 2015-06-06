using WGnet.Categories.WoT;

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

        internal WoTCategory(WgApi wg)
        {
            Account = new AccountCategory(wg);
        }
    }
}
