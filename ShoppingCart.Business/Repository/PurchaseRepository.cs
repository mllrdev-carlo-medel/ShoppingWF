using System;
using ShoppingCart.Business.Entities;
using ShoppingCart.Business.Repository.Interfaces;

namespace ShoppingCart.Business.Repository
{
    public class PurchaseRepository : BaseRepository<Purchase>, IPurchaseRepository
    {
        public override string Table => "Purchase";
    }
}
