using ShoppingCart.Business.Entities;
using ShoppingCart.Business.Manager;
using ShoppingCart.Business.Manager.Interfaces;
using ShoppingCartWebAPI.Controllers.API.Interfaces;

namespace ShoppingCartWebAPI.Controllers.API
{
    public class PurchaseController : BaseController<Purchase>, IPurchaseController
    {
        public override IManager<Purchase> Manager => new PurchaseManager();
    }
}
