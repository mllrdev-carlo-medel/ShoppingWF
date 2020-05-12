using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Business.Entity
{
    public class Customer
    {
        public int Id { get; set; } = -1;
        public string FirstName { get; set; } = null;
        public string MiddleName { get; set; } = null;
        public string LastName { get; set; } = null;
        public string Gender { get; set; } = null;
        public string ContactNo { get; set; } = null;
        public string Email { get; set; } = null;
        public string Address { get; set; } = null;

        public Customer()
        {

        }

        public Customer(int id, string firstName, string middleName, string lastName,
                         string gender, string contactNo, string email, string address)
        {
            Id = id;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Gender = gender;
            ContactNo = contactNo;
            Email = email;
            Address = address;
        }

    }
}
