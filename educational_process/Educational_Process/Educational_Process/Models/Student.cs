using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Educational_Process.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string ThirdName { get; set; }

        public int GroupId { get; set; }

        public Group Group { get; set; }

        public List<Group> Groups { get; set; } 

        public List<StudentPerformance> StudentPerformances { get; set; }
    }
}
