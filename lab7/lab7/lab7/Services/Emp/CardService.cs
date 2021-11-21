using lab7.Domain;
using lab7.Models;
using lab7.Services.Int;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab7.Services.Emp
{
    public class CardService : ICardService
    {
        private readonly AppDbContext _db;

        public CardService(AppDbContext db)
        {
            _db = db;
        }

        public void Delete(int id)
        {
            Card card = _db.Card.Where(card => card.Id == id).FirstOrDefault();
            _db.Card.Remove(card);
            _db.SaveChanges();
        }

        public void Edit(int id, Card item)
        {
            _db.Card.Update(item);
            _db.SaveChanges();
        }

        public IEnumerable<Card> GetAll()
        {
            return _db.Card.ToList();
        }

        public Card GetById(int id)
        {
            return _db.Card.Where(card => card.Id == id).FirstOrDefault();
        }

        public void Create(Card item)
        {
            _db.Card.Add(item);
            _db.SaveChanges();
        }
    }
}
