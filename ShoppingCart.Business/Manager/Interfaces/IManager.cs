using System.Collections.Generic;

namespace ShoppingCart.Business.Manager.Interfaces
{
    public interface IManager<T>
    {
        List<T> GetAll();
        int Add(T data);
        T GetById(int id);
        List<T> GetAllWhere(T data);
        bool Update(T data);
        bool Delete(List<T> data);
    }
}
