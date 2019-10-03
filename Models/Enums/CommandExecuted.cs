using InfinitySO.Models.Enums.Methods;

namespace InfinitySO.Models.Enums
{
    public enum CommandExecuted : int
    {
        [EnumDisplayName(DisplayName = "Não Executado")]
        NotExecuted = 0,
        [EnumDisplayName(DisplayName = "Executado")]
        Executed = 1
    }
}