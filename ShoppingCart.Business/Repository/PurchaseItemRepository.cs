using ShoppingCart.Business.Repository.Interfaces;
using ShoppingCart.Business.Entity;

namespace ShoppingCart.Business.Repository
{
    public class PurchaseItemRepository : BaseRepository<PurchaseItem>, IPurchaseItemRepository
    {
        public override string Table => "PurchaseItem";
    }
}
