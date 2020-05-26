using System;
using ShoppingCart.Business.Entities;
using ShoppingCart.Business.Repository.Interfaces;

namespace ShoppingCart.Business.Repository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public override string Table => "Customer";
    }
}
