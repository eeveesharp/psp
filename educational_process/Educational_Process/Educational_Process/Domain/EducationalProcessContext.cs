using Educational_Process.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Educational_Process.Domain
{
    public class EducationalProcessContext:DbContext
    {
        public EducationalProcessContext(DbContextOptions<EducationalProcessContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<StudentPerformance> StudentPerformances { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Teacher> Teachers { get; set; }
    }
}
