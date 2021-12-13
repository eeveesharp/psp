using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Educational_Process.Models
{
    public class Subject
    {
        public int Id { get; set; }

        [Display(Name = "Название ")]
        public string Name { get; set; }

        [Display(Name = "Преподаватель")]
        public int? TeacherId { get; set; }

        public Teacher Teacher { get; set; }

        public List<StudentPerformance> StudentPerformances { get; set; }
    }
}
