using Educational_Process.Domain;
using Educational_Process.Models;
using Educational_Process.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Educational_Process.Services.Implementations
{
    public class GroupService:IGroupService
    {
        private readonly EducationalProcessContext _educationalProcessContext;

        public GroupService(EducationalProcessContext educationalProcessContext)
        {
            _educationalProcessContext = educationalProcessContext;
        }

        public void Delete(int id)
        {
            Group group = _educationalProcessContext.Groups.Where(contract => contract.Id == id).FirstOrDefault();
            _educationalProcessContext.Groups.Remove(group);
            _educationalProcessContext.SaveChanges();
        }

        public void Edit(int id, Group item)
        {
            _educationalProcessContext.Groups.Update(item);
            _educationalProcessContext.SaveChanges();
        }

        public IEnumerable<Group> GetAll()
        {
            return _educationalProcessContext.Groups.ToList();
        }

        public Group GetById(int id)
        {
            return _educationalProcessContext.Groups.Where(contract => contract.Id == id).FirstOrDefault();
        }

        public void Create(Group item)
        {
            _educationalProcessContext.Groups.Add(item);
            _educationalProcessContext.SaveChanges();
        }
    }
}
