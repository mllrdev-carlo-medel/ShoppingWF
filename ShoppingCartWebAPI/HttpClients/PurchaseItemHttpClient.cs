using ShoppingCart.Business.Entities;
using ShoppingCartWebAPI.HttpClients.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ShoppingCartWebAPI.HttpClients
{
    public class PurchaseItemHttpClient : BaseHttpClient<PurchaseItem>, IPurchaseItemHttpClient
    {
        public override string Controller => "PurchaseItem";
    }
}