using System.ComponentModel;

namespace WGnet.Enums
{
    public enum Region
    {
        [Description("api.worldoftanks.ru/wot/")]
        RU,
        [Description("api.worldoftanks.eu/wot/")]
        EU,
        [Description("api.worldoftanks.com/wot/")]
        NA,
        [Description("api.worldoftanks.kr/wot/")]
        KR,
        [Description("api.worldoftanks.asia/wot/")]
        ASIA,
    }
}
