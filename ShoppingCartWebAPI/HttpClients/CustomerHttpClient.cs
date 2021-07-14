using ShoppingCart.Business.Entities;
using ShoppingCartWebAPI.HttpClients.Interfaces;
using System.Configuration;

namespace ShoppingCartWebAPI.HttpClients
{
    public class CustomerHttpClient : BaseHttpClient<Customer>, ICustomerHttpClient
    {
        public override string Controller => "Customer";
    }
}