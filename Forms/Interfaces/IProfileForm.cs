using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Forms.Interfaces
{
    public interface IProfileForm : IForm
    {
        void LoadData();
        void EnableNewPurchaseButton(bool value);
    }
}
