using log4net;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TipsDotNetRobust.Customer;

namespace TipsDotNetRobust.Shop
{
    public class CoffeeShop : IShop
    {
        private readonly ILog _log;

        public CoffeeShop(ILog log)
        {
            _log = log;
        }

        public void CostumerArrives(ICustomer customer)
        {
            if (customer.IsCorrectShop(this))
            {
                _log.InfoFormat("New coffee customer: '{0}' arrived!", customer.Name);

                string whatToBuy = string.Empty;

                Policy.
                    Handle<Exception>().
                    WaitAndRetry(
                        5,
                        retryAttemp => TimeSpan.FromSeconds(5),
                        (exception, retryCount, context) =>
                    {
                        _log.Info(exception.Message);
                    }).
                    Execute(() =>
                    {
                        _log.InfoFormat("Asking customer: '{0}' what to order", customer.Name);
                        whatToBuy = customer.WhatToOrder();
                    });

                _log.InfoFormat("Customer: '{0}' wanted to order '{1}'", customer.Name, whatToBuy);
            }
            else
            {
                _log.InfoFormat("Customer: '{0}' is leaving, not interested!", customer.Name);
            }
        }
    }
}
