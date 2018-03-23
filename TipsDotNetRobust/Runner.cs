using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TipsDotNetRobust.Customer;
using TipsDotNetRobust.Shop;

namespace TipsDotNetRobust
{
    public class Runner
    {
        public Runner(ILog log, IShop shop, IEnumerable<ICustomer> customers)
        {

            log.Info("Coffee shop started!");
            foreach (var customer in customers)
            {
                try
                {
                    shop.CostumerArrives(customer);
                }
                catch (Exception ex)
                {
                    log.ErrorFormat(ex.Message);
                }
            }

        }
    }
}
