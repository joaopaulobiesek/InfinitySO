using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
using InfinitySO.Models.Enums;
using InfinitySO.Models.ModelsAdministration;

namespace InfinitySO.Models.ModelsStudent
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public MainBoard MainBoard { get; set; }
        public Period Period { get; set; }
        [ForeignKey("MainBoard")]
        [Required(ErrorMessage = "{0} Required")]
        [Display(Name = "Nome do aluno")]
        public int MainBoardId { get; set; }
        [ForeignKey("Period")]
        [Required(ErrorMessage = "{0} Required")]
        [Display(Name = "Periodo")]
        public int PeriodId { get; set; }
        [Required(ErrorMessage = "{0} Required")]
        [Display(Name = "EAD")]
        public string EAD { get; set; }
        [Required(ErrorMessage = "{0} Required")]
        [Display(Name = "Dia da semana")]
        public DayOfWeek Week { get; set; }
        [Required(ErrorMessage = "{0} Required")]
        [Display(Name = "Numero do periodo")]
        public string NumberPeriod { get; set; }
        [Display(Name = "Status da matricula")]
        public StudentRegistration StudentRegistration { get; set; }

        [NotMapped]
        public ICollection<MainBoard> MainBoards { get; set; }
        [NotMapped]
        public ICollection<Period> Periods { get; set; }

        public Student()
        {
        }

        public Student(int id, MainBoard mainBoard, Period period, string eAD, DayOfWeek week, string numberPeriod, StudentRegistration studentRegistration)
        {
            Id = id;
            MainBoard = mainBoard;
            Period = period;
            EAD = eAD;
            Week = week;
            NumberPeriod = numberPeriod;
            StudentRegistration = studentRegistration;
        }
    }
}