using ShoppingCart.Business.Entities;
using ShoppingCart.Business.Manager;
using ShoppingCart.Business.Manager.Interfaces;
using ShoppingCartWebAPI.Controllers.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShoppingCartWebAPI.Controllers.API
{
    public class CustomerController : BaseController<Customer>, ICustomerController
    {
        public override IManager<Customer> Manager => new CustomerManager();
    }
}
