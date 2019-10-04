using InfinitySO.Models.Enums.Methods;

namespace InfinitySO.Models.Enums
{
    public enum StudentRegistration : int
    {
        [EnumDisplayName(DisplayName = "Não Efetuou Matrícula")]
        DidNotRegistration = 0,
        [EnumDisplayName(DisplayName = "Vestibular")]
        EntranceExam = 1,
        [EnumDisplayName(DisplayName = "Matrícula Pré-confirmada")]
        Pre_ConfirmedRegistration = 2,
        [EnumDisplayName(DisplayName = "Matrícula Ativa")]
        ActiveRegistration = 3,
        [EnumDisplayName(DisplayName = "Formando")]
        Forming = 4,
        [EnumDisplayName(DisplayName = "Desistente")]
        Quitter = 5,
        [EnumDisplayName(DisplayName = "Matrícula Trancada")]
        LockedRegistration = 6,
        [EnumDisplayName(DisplayName = "Matrícula Cancelada")]
        RegistrationCanceled = 7
    }
}