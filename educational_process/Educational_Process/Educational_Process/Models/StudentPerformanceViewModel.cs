using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Educational_Process.Models
{
    public class StudentPerformanceViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Студент")]
        public string StudentSecondName { get; set; }

        [Display(Name = "Предмет")]
        public string SubjectName { get; set; }

        [Display(Name = "Дата экзамена")]
        public DateTime ExamDate { get; set; }

        [Display(Name = "Оценка")]
        public int Mark { get; set; }
    }
}
