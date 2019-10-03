using InfinitySO.Models.Enums.Methods;

namespace InfinitySO.Models.Enums
{
    public enum TypeFile : int
    {
        [EnumDisplayName(DisplayName = "Excel System")]
        System_xlsx = 0,
        [EnumDisplayName(DisplayName = "Excel 2010 -")]
        xls = 1,
        [EnumDisplayName(DisplayName = "Excel 2013 +")]
        xlsx = 2,
        [EnumDisplayName(DisplayName = "Imagem Jpeg")]
        jpeg = 3,
        [EnumDisplayName(DisplayName = "Imagem Jpg")]
        jpg = 4,
        [EnumDisplayName(DisplayName = "Imagem Png")]
        png = 5,
        [EnumDisplayName(DisplayName = "Imagem Bmp")]
        bmp = 6,
        [EnumDisplayName(DisplayName = "Imagem Pdf")]
        pdf = 7,
        [EnumDisplayName(DisplayName = "Texto")]
        txt = 8
    }
}