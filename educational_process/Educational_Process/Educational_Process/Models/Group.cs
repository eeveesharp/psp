using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Educational_Process.Models
{
    public class Group
    {
        public int Id { get; set; }

        [Display(Name = "Название группы")]
        public string Name { get; set; }
    }
}
