using System.Collections.Generic;
using Newtonsoft.Json;

namespace WGnet.Model.WGN
{
    /// <summary>
    /// Информация об эмблемах клана в играх и на клановом портале
    /// </summary>
    public class ClanEmblems
    {
        /// <summary>
        /// Список ссылок на эмблемы 195x195 px
        /// </summary>
        [JsonProperty("x195")]
        public Dictionary<string, string> X195 { get; set; }

        /// <summary>
        /// Список ссылок на эмблемы 24x24 px
        /// </summary>
        [JsonProperty("x24")]
        public Dictionary<string, string> X24 { get; set; }

        /// <summary>
        /// Список ссылок на эмблемы 256x256 px
        /// </summary>
        [JsonProperty("x256")]
        public Dictionary<string, string> X256 { get; set; }

        /// <summary>
        /// Список ссылок на эмблемы 32x32 px
        /// </summary>
        [JsonProperty("x32")]
        public Dictionary<string, string> X32 { get; set; }

        /// <summary>
        /// Список ссылок на эмблемы 64x64 px
        /// </summary>
        [JsonProperty("x64")]
        public Dictionary<string, string> X64 { get; set; }
    }
}
