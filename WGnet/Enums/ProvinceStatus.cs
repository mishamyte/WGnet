using System.ComponentModel;

namespace WGnet.Enums
{
    /// <summary>
    /// Идентификатор статуса мятежа в провинции
    /// </summary>
    public enum ProvinceStatus
    {
        [Description("normal")]
        Normal,
        [Description("start")]
        Start,
        [Description("mutiny")]
        Mutiny,
        [Description("delayed_mutiny")]
        DelayedMutiny,
    }
}
