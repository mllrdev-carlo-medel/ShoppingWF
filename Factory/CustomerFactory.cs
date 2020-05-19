using ShoppingCart.Business.Entity;
using ShoppingCart.Business.Log;
using ShoppingCart.Business.Manager;
using ShoppingCart.Business.Manager.Interfaces;
using ShoppingCart.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Factory
{
    public static class CustomerFactory
    {
        public static CustomerDetails GetCustomer(int id)
        {
            try
            {
                IManager<Customer> customerManager = new CustomerManager();
                IManager<Purchase> purchaseManager = new PurchaseManager();
                IManager<PurchaseItem> purchaseItemManager = new PurchaseItemManager();
                IManager<Item> itemManager = new ItemManager();

                CustomerDetails customer = new CustomerDetails(customerManager.GetById(id));

                Purchase conditionPurchase = new Purchase { CustomerId = id };
                PurchaseItem conditionPurchaseItem = new PurchaseItem();

                foreach (Purchase purchase in purchaseManager.GetAllWhere(conditionPurchase))
                {
                    customer.PurchaseHistory.Add(new PurchaseHistory(purchase));
                }

                foreach (PurchaseHistory purchaseHistory in customer.PurchaseHistory)
                {
                    conditionPurchaseItem.PurchaseId = purchaseHistory.Purchase.Id;

                    foreach (PurchaseItem purchaseItem in purchaseItemManager.GetAllWhere(conditionPurchaseItem))
                    {
                        purchaseHistory.PurchaseDetails.Add(new PurchaseDetails(purchaseItem, itemManager.GetById(purchaseItem.ItemId)));
                    }
                }

                return customer;
            }
            catch(Exception ex)
            {
                Logger.log.Error(ex.ToString());
                return null;
            }
        }
    }
}
