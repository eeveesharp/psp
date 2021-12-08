using Educational_Process.Services.Implementations;
using Educational_Process.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Educational_Process
{
    public static class Di
    {
        public static void IoC(this IServiceCollection services)
        {
            services.AddTransient<IGroupService, GroupService>();
            services.AddTransient<IStudentPerformanceService, StudentPerformanceService>();
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<ISubjectService, SubjectService>();
            services.AddTransient<ITeacherService, TeacherService>();
        }
    }
}
