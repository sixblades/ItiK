using System.ComponentModel;

namespace Domain.Models.Shared
{
    public enum FiscalTypeEnum
    {
        [Description("NIF")]
        NIF,

        [Description("NIE")]
        NIE,

        [Description("CIF")]
        CIF
    }
}