using InfinitySO.Models.Enums.Methods;

namespace InfinitySO.Models.Enums
{
    public enum Presence : int
    {
        [EnumDisplayName(DisplayName = "Falta")]
        Absence = 0,
        [EnumDisplayName(DisplayName = "Presente")]
        Present = 1,
        [EnumDisplayName(DisplayName = "Falta Justificada")]
        JustifiedAbsence = 2
    }
}
