using InfinitySO.Models.Enums.Methods;

namespace InfinitySO.Models.Enums
{
    public enum BilletPay : int
    {
        [EnumDisplayName(DisplayName = "Não Pago")]
        NotPaid = 0,
        [EnumDisplayName(DisplayName = "Pago")]
        Paid = 1,
        [EnumDisplayName(DisplayName = "Vencido")]
        OverDue = 2,
        [EnumDisplayName(DisplayName = "Desacordo")]
        Disagreement = 3
    }
}