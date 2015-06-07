using System.ComponentModel;

namespace WGnet.Enums
{
    /// <summary>
    /// Список доменов серверов WG
    /// </summary>
    public enum WgRegion
    {
        [Description("ru")]
        RU,
        [Description("eu")]
        EU,
        [Description("com")]
        NA,
        [Description("kr")]
        KR,
        [Description("asia")]
        ASIA,
    }
}
