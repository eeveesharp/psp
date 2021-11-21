using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab7.Models
{
    public class Client
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string SecondName { get; set; }

        public string ThirdName { get; set; }

        public List<Card> Card { get; set; } = new List<Card>();
    }
}
