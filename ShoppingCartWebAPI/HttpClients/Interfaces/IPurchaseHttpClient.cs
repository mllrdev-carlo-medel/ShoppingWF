using ShoppingCart.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartWebAPI.HttpClients.Interfaces
{
    public interface IPurchaseHttpClient : IHttpClients<Purchase>
    {
    }
}