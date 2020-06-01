using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ShoppingCartWebAPI.Controllers.API.Interfaces
{
    public interface IController<T>
    {
        IHttpActionResult GetAll();
        IHttpActionResult Add(T data);
        IHttpActionResult GetById(int id);
        IHttpActionResult Find(T data);
        IHttpActionResult Update(T data);
        IHttpActionResult Delete(List<T> data);
    }
}