using InfinitySO.Models.Enums.Methods;

namespace InfinitySO.Models.Enums
{
    public enum LowPatrimony : int
    {
        [EnumDisplayName(DisplayName = "Manutenção")]
        Maintenance = 0,
        [EnumDisplayName(DisplayName = "Danificado")]
        Damaged = 1,
        [EnumDisplayName(DisplayName = "Troca de Local")]
        ChangeLocation = 2
    }
}