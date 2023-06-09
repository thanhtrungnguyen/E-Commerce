﻿using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstractions
{
    public interface IProductRepository : IGenereicRepository<Product>
    {
        Task<Product>? GetProductDetailById(int id);
    }
}
