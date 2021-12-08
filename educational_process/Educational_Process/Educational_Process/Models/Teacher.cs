using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Educational_Process.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string ThirdName { get; set; }

        public int SubjectId { get; set; }

        public Subject Subject { get; set; }

        public List<Teacher> Teachers { get; set; } = new List<Teacher>();
    }
}
