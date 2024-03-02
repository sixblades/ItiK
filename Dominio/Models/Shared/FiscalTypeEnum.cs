using System.ComponentModel;

namespace Dominio.Models.Shared
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