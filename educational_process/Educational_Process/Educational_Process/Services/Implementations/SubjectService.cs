using Educational_Process.Domain;
using Educational_Process.Models;
using Educational_Process.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Educational_Process.Services.Implementations
{
    public class SubjectService:ISubjectService
    {
        private readonly EducationalProcessContext _educationalProcessContext;

        public SubjectService(EducationalProcessContext educationalProcessContext)
        {
            _educationalProcessContext = educationalProcessContext;
        }

        public void Delete(int id)
        {
            Subject subject = _educationalProcessContext.Subjects.Where(contract => contract.Id == id).FirstOrDefault();
            _educationalProcessContext.Subjects.Remove(subject);
            _educationalProcessContext.SaveChanges();
        }

        public void Edit(int id, Subject item)
        {
            _educationalProcessContext.Subjects.Update(item);
            _educationalProcessContext.SaveChanges();
        }

        public IEnumerable<Subject> GetAll()
        {
            return _educationalProcessContext.Subjects.ToList();
        }

        public Subject GetById(int id)
        {
            return _educationalProcessContext.Subjects.Where(contract => contract.Id == id).FirstOrDefault();
        }

        public void Create(Subject item)
        {
            _educationalProcessContext.Subjects.Add(item);
            _educationalProcessContext.SaveChanges();
        }
    }
}
