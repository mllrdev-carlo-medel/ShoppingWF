using ShoppingCart.Business.Entity;

namespace ShoppingCart.Business.Model
{
    public class PurchaseDetails
    {
        public PurchaseItem PurchaseItem { get; set; }
        public Item Item { get; set; }

        public PurchaseDetails(PurchaseItem purchaseItem, Item item)
        {
            PurchaseItem = purchaseItem;
            Item = item;
        }
    }
}
