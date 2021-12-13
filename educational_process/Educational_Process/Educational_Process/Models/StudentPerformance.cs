using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Educational_Process.Models
{
    public class StudentPerformance
    {
        public int Id { get; set; }

        [Display(Name = "Студент")]
        public int StudentId { get; set; }

        public Student Student { get; set; }

        [Display(Name = "Предмет")]
        public int SubjectId { get; set; }

        public Subject Subject { get; set; }

        [Display(Name = "Дата экзамена")]
        public DateTime ExamDate { get; set; }

        [Display(Name = "Оценка")]
        public int Mark { get; set; }
    }
}
