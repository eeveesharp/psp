using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Educational_Process.Models
{
    public class StudentPerformanceViewModel
    {
        public int Id { get; set; }

        public string StudentSecondName { get; set; }

        public string SubjectName { get; set; }

        public DateTime ExamDate { get; set; }

        public int Mark { get; set; }
    }
}
