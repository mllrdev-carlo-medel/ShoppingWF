using ShoppingCart.Business.Repository.Interfaces;
using ShoppingCart.Business.Entities;

namespace ShoppingCart.Business.Repository
{
    public class PurchaseItemRepository : BaseRepository<PurchaseItem>, IPurchaseItemRepository
    {
        public override string Table => "PurchaseItem";
    }
}
