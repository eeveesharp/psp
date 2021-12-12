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
    public class StudentService:IStudentService
    {
        private readonly EducationalProcessContext _educationalProcessContext;

        public StudentService(EducationalProcessContext educationalProcessContext)
        {
            _educationalProcessContext = educationalProcessContext;
        }

        public void Delete(int id)
        {
            Student student = _educationalProcessContext.Students.Where(contract => contract.Id == id).FirstOrDefault();
            _educationalProcessContext.Students.Remove(student);
            _educationalProcessContext.SaveChanges();
        }

        public void Edit(int id, Student item)
        {
            _educationalProcessContext.Students.Update(item);
            _educationalProcessContext.SaveChanges();
        }

        public IEnumerable<Student> GetAll()
        {
            return _educationalProcessContext.Students
                .Include(x=>x.Group)
                .AsNoTracking()
                .ToList();
        }

        public Student GetById(int id)
        {
            return _educationalProcessContext.Students
                                .Include(x => x.Group)
                .AsNoTracking().Where(contract => contract.Id == id).FirstOrDefault();
        }

        public void Create(Student item)
        {
            _educationalProcessContext.Students.Add(item);
            _educationalProcessContext.SaveChanges();
        }
    }
}
