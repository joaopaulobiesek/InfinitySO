using InfinitySO.Models.Enums;
using InfinitySO.Models.ModelsStudent;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfinitySO.Models.ModelsSystem
{
    public class DownloadFile
    {
        public int Id { get; set; }
        public TypeFile TypeFile { get; set; }
        public CommandExecuted CommandExecuted { get; set; }
        public Period Period { get; set; }
        public string Name { get; set; }
        public string NameFile { get; set; }
        public int PageNumbers { get; set; }
        public long Size { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Column(TypeName = "date")]
        public DateTime DateUpload { get; set; }
        public string Path { get; set; }

        public DownloadFile()
        {
        }

        public DownloadFile(int id, TypeFile typeFile, CommandExecuted commandExecuted, Period period, string name, string nameFile, int pageNumbers, long size, DateTime dateUpload, string path)
        {
            Id = id;
            TypeFile = typeFile;
            CommandExecuted = commandExecuted;
            Period = period;
            Name = name;
            NameFile = nameFile;
            PageNumbers = pageNumbers;
            Size = size;
            DateUpload = dateUpload;
            Path = path;
        }
    }
}