using InfinitySO.Models.Enums.Methods;

namespace InfinitySO.Models.Enums
{
    public enum StudentRegistration : int
    {
        [EnumDisplayName(DisplayName = "Vestibular")]
        EntranceExam = 0,
        [EnumDisplayName(DisplayName = "Matrícula Pré-confirmada")]
        Pre_ConfirmedRegistration = 1,
        [EnumDisplayName(DisplayName = "Matrícula Ativa")]
        ActiveRegistration = 2,
        [EnumDisplayName(DisplayName = "Formando")]
        Forming = 3,
        [EnumDisplayName(DisplayName = "Desistente")]
        Quitter = 4,
        [EnumDisplayName(DisplayName = "Matrícula Trancada")]
        LockedRegistration = 5,
        [EnumDisplayName(DisplayName = "Matrícula Cancelada")]
        RegistrationCanceled = 6
    }
}