using Project.Stock.Manager.Infrastructure.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Stock.Manager.Infrastructure.Model
{
    public class User
    {
        public User() { }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public StatusUser Status { get; set; }
        public Account Account { get; set; }
        public Guid AccountId { get; set; }
        public bool Active  { get; set; }
    }
}
