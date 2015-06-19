using Newtonsoft.Json;

namespace WGnet.Model.WoT.Globalwar
{
    /// <summary>
    /// Cекретная информация клана
    /// </summary>
    public class GlobalwarBattlesPrivate
    {
        /// <summary>
        /// Количество фишек
        /// </summary>
        [JsonProperty("chips")]
        public int Chips { get; set; }
    }
}
