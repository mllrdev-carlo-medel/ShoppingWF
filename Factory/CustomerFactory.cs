using ShoppingCart.Business.Entities;
using ShoppingCart.Business.Log;
using ShoppingCart.Business.Manager;
using ShoppingCart.Business.Manager.Interfaces;
using ShoppingCart.Business.Model;
using ShoppingCart.Constants;
using ShoppingCartWebAPI.HttpClients;
using ShoppingCartWebAPI.HttpClients.Interfaces;
using System;

namespace ShoppingCart.Factory
{
    public static class CustomerFactory
    {
        public static CustomerDetails GetCustomer(int id)
        {
            try
            {
                IHttpClients<Customer> customerClient = new CustomerHttpClient();
                IHttpClients<Purchase> purchaseClient = new PurchaseHttpClient();
                IHttpClients<PurchaseItem> purchaseItemClient = new PurchaseItemHttpClient();
                IHttpClients<Item> itemClient = new ItemHttpClient();

                CustomerDetails customer = new CustomerDetails(customerClient.GetById(id));

                Purchase conditionPurchase = new Purchase { CustomerId = id };
                PurchaseItem conditionPurchaseItem = new PurchaseItem();

                foreach (Purchase purchase in purchaseClient.Find(conditionPurchase))
                {
                    customer.PurchaseHistory.Add(new PurchaseHistory(purchase));
                }

                foreach (PurchaseHistory purchaseHistory in customer.PurchaseHistory)
                {
                    conditionPurchaseItem.PurchaseId = purchaseHistory.Purchase.Id;

                    foreach (PurchaseItem purchaseItem in purchaseItemClient.Find(conditionPurchaseItem))
                    {
                        if (purchaseHistory.Purchase.Status == ProfileStringConstants.PENDING)
                        {
                            Item item = itemClient.GetById(purchaseItem.ItemId);
                            purchaseItem.Price = item.Price;
                            purchaseItem.SubTotal = purchaseItem.Quantity * item.Price;
                            purchaseItemClient.Update(purchaseItem);
                            purchaseHistory.PurchaseDetails.Add(new PurchaseDetails(purchaseItem, item));
                        }
                        else
                        {
                            purchaseHistory.PurchaseDetails.Add(new PurchaseDetails(purchaseItem, itemClient.GetById(purchaseItem.ItemId)));
                        }
                    }
                }

                return customer;
            }
            catch(Exception ex)
            {
                Console.WriteLine("cmedel error");
                Logger.log.Error(ex.ToString());
                return null;
            }
        }
    }
}
