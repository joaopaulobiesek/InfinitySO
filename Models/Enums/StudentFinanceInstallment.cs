using InfinitySO.Models.Enums.Methods;

namespace InfinitySO.Models.Enums
{
    public enum StudentFinanceInstallment : int
    {
        [EnumDisplayName(DisplayName = "1 X")]
        X1 = 1,
        [EnumDisplayName(DisplayName = "2 X")]
        X2 = 2,
        [EnumDisplayName(DisplayName = "3 X")]
        X3 = 3,
        [EnumDisplayName(DisplayName = "4 X")]
        X4 = 4,
        [EnumDisplayName(DisplayName = "5 X")]
        X5 = 5,
        [EnumDisplayName(DisplayName = "6 X")]
        X6 = 6,
        [EnumDisplayName(DisplayName = "7 X")]
        X7 = 7
    }
}