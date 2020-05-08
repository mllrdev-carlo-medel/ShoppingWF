using ShoppingCart.Business.Entity;

namespace ShoppingCart.Business.Model
{
    public class PurchaseDetails
    {
        public PurchaseItem PurchaseItem { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }

        public PurchaseDetails(PurchaseItem purchaseItem, Item item)
        {
            PurchaseItem = purchaseItem;
            Name = item.Name;
            Price = item.Price;
        }
    }
}
