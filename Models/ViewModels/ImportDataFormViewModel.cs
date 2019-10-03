using InfinitySO.Models.ModelsStudent;
using InfinitySO.Models.ModelsSystem;
using System.Collections.Generic;

namespace InfinitySO.Models.ViewModels
{
    public class ImportDataFormViewModel
    {
        public DownloadFile DownloadFile { get; set; }
        public DownloadFileDescription DownloadFileDescription { get; set; }
        public string stringDownloadFileDescriptions { get; set; }
        public ICollection<Period> Periods { get; set; }
        public ICollection<DownloadFile> DownloadFiles { get; set; }
        public ICollection<DownloadFileDescription> DownloadFileDescriptions { get; set; }
    }
}