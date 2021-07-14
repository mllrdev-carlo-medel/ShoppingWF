using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartWebAPI.HttpClients.Interfaces
{
    public interface IHttpClients<T> where T : class
    {
        int Add(T data);
        bool Delete(List<T> data);
        List<T> GetAll();
        List<T> Find(T data);
        T GetById(int id);
        bool Update(T data);
    }
}