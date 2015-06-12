using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace WGnet.Model.WGN.Clan
{
    /// <summary>
    /// Информация о клановых сущностях
    /// См. описание <see cref="http://ru.wargaming.net/developers/api_reference/wgn/clans/glossary/"/>
    /// </summary>
    public class ClanRoles
    {
        /// <summary>
        /// clans_roles
        /// </summary>
        [JsonProperty("clans_roles")]
        public ReadOnlyDictionary<string, string> ClansRoles { get; set; }
    }
}
