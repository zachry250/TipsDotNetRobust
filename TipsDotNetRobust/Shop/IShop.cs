using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TipsDotNetRobust.Customer;

namespace TipsDotNetRobust.Shop
{
    public interface IShop
    {
        void CostumerArrives(ICustomer customer);
    }
}
