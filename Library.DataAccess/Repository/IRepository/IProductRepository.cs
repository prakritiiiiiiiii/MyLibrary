﻿using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Repository.IRepository
{
    public interface IProductRepository : IRepository<Models.Product>
    {
       void Save();
       void Update(Models.Product obj);


    }
}