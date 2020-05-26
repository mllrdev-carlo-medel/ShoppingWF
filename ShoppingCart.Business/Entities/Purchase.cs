using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Business.Entities
{
    public class Purchase
    {
        public int Id { get; set; } = -1;
        public int CustomerId { get; set; } = -1;
        public string Status { get; set; } = null;
        public string Date { get; set; } = null;
        public float Total { get; set; } = -1;

        public Purchase()
        {

        }

        public Purchase(int id, int customerId, string status, string date, float total)
        {
            Id = id;
            CustomerId = customerId;
            Status = status;
            Date = date;
            Total = total;
        }
    }
}
