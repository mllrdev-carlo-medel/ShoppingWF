using ShoppingCart.Business.Entities;
using ShoppingCartWebAPI.HttpClients.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ShoppingCartWebAPI.HttpClients
{
    public class PurchaseHttpClient : BaseHttpClient<Purchase>, IPurchaseHttpClient
    {
        public override string Controller => "Purchase";
    }
}