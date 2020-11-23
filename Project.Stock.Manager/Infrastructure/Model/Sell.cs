using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Stock.Manager.Infrastructure.Model
{
    public class Sell
    {
        public Sell() { }
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public Customer Customer { get; set; }
        public Guid CustomerId { get; set; }
    }
}
