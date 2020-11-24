using System;
using System.Collections.Generic;

namespace Project.Stock.Manager.Infrastructure.Model
{
    public class Customer
    {
        public Customer() { }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Active { get; set; }
        public List<Sell> Sells { get; set; }
        
    }
}
