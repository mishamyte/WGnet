using Newtonsoft.Json;

namespace WGnet.Model
{
    public class Player
    {
        [JsonProperty("account_id")]
        public long AccountId { get; set; } 

        [JsonProperty("nickname")]
        public string NickName { get; set; }
    }
}
