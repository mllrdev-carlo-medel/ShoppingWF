using ShoppingCart.Business.Entities;

namespace ShoppingCart.Business.Model
{
    public class PurchaseDetails
    {
        public PurchaseItem PurchaseItem { get; set; }
        public string Name { get; set; }

        public PurchaseDetails(PurchaseItem purchaseItem, Item item)
        {
            PurchaseItem = purchaseItem;
            Name = item.Name;
        }
    }
}
