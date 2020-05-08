using System;
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
        T GetById(int id);
        List<T> GetAllWhere(T datas, string condition);
        bool Update(T data);
        bool Delete(List<T> data, string conditon);
    }
}
