using InfinitySO.Models.ModelsStudent;
using InfinitySO.Models.ModelsSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfinitySO.Models.ViewModels
{
    public class ImportDataFormViewModel
    {
        public DownloadFile DownloadFile { get; set; }
        public ICollection<Period> Periods { get; set; }
        public ICollection<DownloadFile> DownloadFiles { get; set; }
    }
}
