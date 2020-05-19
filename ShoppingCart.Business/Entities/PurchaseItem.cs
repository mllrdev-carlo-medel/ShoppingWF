using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Business.Entity
{
    public class PurchaseItem
    {
        public int Id { get; set; } = -1;
        public int PurchaseId { get; set; } = -1;
        public int ItemId { get; set; } = -1;
        public float Price { get; set; } = -1;
        public int Quantity { get; set; } = -1;
        public float SubTotal { get; set; } = -1;

        public PurchaseItem()
        {

        }

        public PurchaseItem(int id, int purchaseId, int itemId, float price, int quantity, float subtotal)
        {
            Id = id;
            PurchaseId = purchaseId;
            ItemId = itemId;
            Price = price;
            Quantity = quantity;
            SubTotal = subtotal;
        }
    }
}
