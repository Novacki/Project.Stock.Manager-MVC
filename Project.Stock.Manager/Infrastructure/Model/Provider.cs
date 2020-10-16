﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Stock.Manager.Infrastructure.Model
{
    public class Provider
    {
        public Provider() { }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int Cnpj { get; set; }
        public bool Active { get; set; }
        public Lot Lot { get; set; }
    }
}
