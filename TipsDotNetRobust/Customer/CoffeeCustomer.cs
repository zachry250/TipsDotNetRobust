using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TipsDotNetRobust.Shop;

namespace TipsDotNetRobust.Customer
{
    public class CoffeeCustomer : ICustomer
    {
        private readonly int _desidecisionTime;
        private readonly string _name;
        private readonly string _whatToOrder;

        DateTime? _askedFirstTime = null;

        public string Name { get { return _name; } }

        public CoffeeCustomer(string name, int desidecisionTime, string whatToOrder)
        {
            _name = name;
            _desidecisionTime = desidecisionTime;
            _whatToOrder = whatToOrder;
        }

        public bool IsCorrectShop(IShop shop)
        {
            return shop is CoffeeShop;
        }

        public string WhatToOrder()
        {
            if(_askedFirstTime == null)
            {
                _askedFirstTime = DateTime.Now;
            }
            if(DateTime.Now.Subtract(_askedFirstTime.Value).TotalSeconds > _desidecisionTime)
            {
                return _whatToOrder;
            }
            else
            {
                throw new Exception("Im not ready yet! Need more time.");
            }
        }
    }
}
