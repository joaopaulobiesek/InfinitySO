using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfinitySO.Models.ModelsStudent
{
    public class Period
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Semester Semester { get; set; }
        public Course Course { get; set; }
        [ForeignKey("Semester")]
        public int SemesterId { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        [NotMapped]
        public ICollection<Semester> Semesters { get; set; }
        [NotMapped]
        public ICollection<Course> Courses { get; set; }

        public Period()
        {
        }

        public Period(int id, Semester semester, Course course)
        {
            Id = id;
            Semester = semester;
            Course = course;
        }
    }
}