using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Helper
{
    public static class GenerateID
    {
        public static int GetGeneratedID()
        {
            Guid guid = Guid.NewGuid();
            return Math.Abs(guid.GetHashCode());
        }
    }
}