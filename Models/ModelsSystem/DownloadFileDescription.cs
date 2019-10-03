using InfinitySO.Models.Enums;
using InfinitySO.Models.ModelsStudent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfinitySO.Models.ModelsSystem
{
    public class DownloadFileDescription
    {
        public int Id { get; set; }
        public CommandExecuted CommandExecuted { get; set; }
        public DownloadFile DownloadFile { get; set; }
        public Period Period { get; set; }
        public int DownloadFileId { get; set; }
        public int PeriodId { get; set; }
        public int PageNumber { get; set; }
        public string NamePage { get; set; }
        public string Description { get; set; }

        public DownloadFileDescription()
        {
        }

        public DownloadFileDescription(int id, CommandExecuted commandExecuted, DownloadFile downloadFile, Period period, int downloadFileId, int periodId, int pageNumber, string namePage, string description)
        {
            Id = id;
            CommandExecuted = commandExecuted;
            DownloadFile = downloadFile;
            Period = period;
            DownloadFileId = downloadFileId;
            PeriodId = periodId;
            PageNumber = pageNumber;
            NamePage = namePage;
            Description = description;
        }
    }
}