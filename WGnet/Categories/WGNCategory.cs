using WGnet.Categories.WGN;

namespace WGnet.Categories
{
    /// <summary>
    /// API для работы с фабриками WG API, относящимся к сервисам WG
    /// </summary>
    public class WGNCategory
    {
        /// <summary>
        /// API для работы с кланами
        /// См. <see cref="ClanCategory"/>
        /// </summary>
        public ClanCategory Clan { get; private set; }

        internal WGNCategory(WgApi wg)
        {
            Clan = new ClanCategory(wg);
        }
    }
}
