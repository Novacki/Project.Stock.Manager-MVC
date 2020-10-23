using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Stock.Manager.Infrastructure.Model
{
    public class Batch
    {
        public Batch() { }
        public int Id { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public Provider Provider { get; set; }
        public int ProviderId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
