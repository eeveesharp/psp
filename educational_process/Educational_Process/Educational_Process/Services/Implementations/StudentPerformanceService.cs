using Educational_Process.Domain;
using Educational_Process.Models;
using Educational_Process.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Educational_Process.Services.Implementations
{
    public class StudentPerformanceService : IStudentPerformanceService
    {
        private readonly EducationalProcessContext _educationalProcessContext;

        public StudentPerformanceService(EducationalProcessContext educationalProcessContext)
        {
            _educationalProcessContext = educationalProcessContext;
        }

        public void Delete(int id)
        {
            StudentPerformance studentPerformance = _educationalProcessContext.StudentPerformances.Where(contract => contract.Id == id).FirstOrDefault();
            _educationalProcessContext.StudentPerformances.Remove(studentPerformance);
            _educationalProcessContext.SaveChanges();
        }

        public void Edit(int id, StudentPerformance item)
        {
            _educationalProcessContext.StudentPerformances.Update(item);
            _educationalProcessContext.SaveChanges();
        }

        public IEnumerable<StudentPerformance> GetAll()
        {
            return _educationalProcessContext.StudentPerformances
                .Include(x => x.Student)
                .Include(x => x.Subject)
                .Include(x => x.Student.Group)
                .AsNoTracking()
                .ToList();
        }

        public StudentPerformance GetById(int id)
        {
            return _educationalProcessContext.StudentPerformances
                .Include(x => x.Student)
                .Include(x => x.Subject)
                .Include(x => x.Student.Group)
                .AsNoTracking()
                .Where(contract => contract.Id == id)
                .FirstOrDefault();
        }

        public void Create(StudentPerformance item)
        {
            _educationalProcessContext.StudentPerformances.Add(item);
            _educationalProcessContext.SaveChanges();
        }
    }
}
