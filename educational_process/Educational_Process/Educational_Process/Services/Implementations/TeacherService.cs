using Educational_Process.Domain;
using Educational_Process.Models;
using Educational_Process.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Educational_Process.Services.Implementations
{
    public class TeacherService:ITeacherService
    {
        private readonly EducationalProcessContext _educationalProcessContext;

        public TeacherService(EducationalProcessContext educationalProcessContext)
        {
            _educationalProcessContext = educationalProcessContext;
        }

        public void Delete(int id)
        {
            Teacher teacher = _educationalProcessContext.Teachers.Where(contract => contract.Id == id).FirstOrDefault();
            _educationalProcessContext.Teachers.Remove(teacher);
            _educationalProcessContext.SaveChanges();
        }

        public void Edit(int id, Teacher item)
        {
            _educationalProcessContext.Teachers.Update(item);
            _educationalProcessContext.SaveChanges();
        }

        public IEnumerable<Teacher> GetAll()
        {
            return _educationalProcessContext.Teachers.ToList();
        }

        public Teacher GetById(int id)
        {
            return _educationalProcessContext.Teachers.Where(contract => contract.Id == id).FirstOrDefault();
        }

        public void Create(Teacher item)
        {
            _educationalProcessContext.Teachers.Add(item);
            _educationalProcessContext.SaveChanges();
        }
    }
}
