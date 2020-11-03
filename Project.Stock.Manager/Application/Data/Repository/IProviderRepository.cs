﻿using Project.Stock.Manager.Infrastructure.Data.Repository;
using Project.Stock.Manager.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Stock.Manager.Application.Data.Repository
{
    public interface IProviderRepository : IRepository<Provider>
    {
    }
}
