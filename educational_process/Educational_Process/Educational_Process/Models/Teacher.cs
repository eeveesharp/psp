using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Educational_Process.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        public string SecondName { get; set; }

        [Display(Name = "Отчество")]
        public string ThirdName { get; set; }

        public List<Subject> Subjects { get; set; }
    }
}
