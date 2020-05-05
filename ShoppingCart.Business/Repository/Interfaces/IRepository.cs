﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Business.Repository.Interfaces
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        bool Add(T data);
        T GetById(int id, string name);
        List<T> GetAllById(int id, string name);
        bool Update(T data);
        bool Delete(int[] id, string name);
    }
}
