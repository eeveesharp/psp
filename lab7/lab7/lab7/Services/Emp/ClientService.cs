using lab7.Domain;
using lab7.Models;
using lab7.Services.Int;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab7.Services.Emp
{
    public class ClientService : IClientService
    {
        private readonly AppDbContext _db;

        public ClientService(AppDbContext db)
        {
            _db = db;
        }

        public void Delete(int id)
        {
            Client client = _db.Client.Where(user => user.Id == id).FirstOrDefault();
            _db.Client.Remove(client);
            _db.SaveChanges();
        }

        public void Edit(int id, Client item)
        {
            _db.Client.Update(item);
            _db.SaveChanges();
        }

        public IEnumerable<Client> GetAll()
        {
            return _db.Client.ToList();
        }

        public Client GetById(int id)
        {
            return _db.Client.Where(client => client.Id == id).FirstOrDefault();
        }

        public void Create(Client item)
        {
            _db.Client.Add(item);
            _db.SaveChanges();
        }
    }
}
