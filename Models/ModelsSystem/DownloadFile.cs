using InfinitySO.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfinitySO.Models.ModelsSystem
{
    public class DownloadFile
    {
        public int Id { get; set; }
        public TypeFile TypeFile { get; set; }
        public CommandExecuted CommandExecuted { get; set; }
        public string NameFile { get; set; }
        public int PageNumbers { get; set; }
        public long Size { get; set; }
        public DateTime DateUpload { get; set; }
        public string Path { get; set; }

        public DownloadFile()
        {
        }

        public DownloadFile(int id, TypeFile typeFile, CommandExecuted commandExecuted, string nameFile, int pageNumbers, long size, DateTime dateUpload, string path)
        {
            Id = id;
            TypeFile = typeFile;
            CommandExecuted = commandExecuted;
            NameFile = nameFile;
            PageNumbers = pageNumbers;
            Size = size;
            DateUpload = dateUpload;
            Path = path;
        }
    }
}