using ShoppingCart.Business.Entities;
using ShoppingCart.Business.Repository.Interfaces;

namespace ShoppingCart.Business.Repository
{
    public class ItemRepository : BaseRepository<Item>, IItemRepository
    {
        public override string Table => "Item";
    }
}
