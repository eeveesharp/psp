using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Educational_Process.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        public string SecondName { get; set; }

        [Display(Name = "Отчество")]
        public string ThirdName { get; set; }

        [Display(Name = "Группа")]
        public int GroupId { get; set; }

        public Group Group { get; set; }

        public List<Group> Groups { get; set; } 

        public List<StudentPerformance> StudentPerformances { get; set; }
    }
}
