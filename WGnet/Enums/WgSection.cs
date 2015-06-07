using System.ComponentModel;

namespace WGnet.Enums
{
    /// <summary>
    /// Список адресов серверов WG API
    /// </summary>
    public enum WgSection
    {
        [Description("api.worldoftanks.")]
        WoT,
        [Description("api.worldofwarplanes.")]
        WoWP,
        [Description("api.wotblitz.")]
        WoTB,
        [Description("api.worldoftanks.")]
        WGN,
    }
}
