﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Stock.Manager.Infrastructure.Model
{
    public class Product
    {
        public Product() { }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mark { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public bool Active { get; set; }
        public Lot Lot { get; set; }
    }
}