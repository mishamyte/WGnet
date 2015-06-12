using Newtonsoft.Json;

namespace WGnet.Model.WGN.Clan
{
    /// <summary>
    /// Cекретная информация клана
    /// </summary>
    public class ClanPrivate
    {
        /// <summary>
        /// Золото в казне клана
        /// </summary>
        [JsonProperty("treasury")]
        public long Treasury { get; set; }
    }
}
