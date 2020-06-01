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
    public class ItemController : BaseController<Item>, IItemController
    {
        public override IManager<Item> Manager => new ItemManager();
    }
}
