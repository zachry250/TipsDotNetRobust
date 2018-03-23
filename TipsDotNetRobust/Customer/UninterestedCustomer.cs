using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TipsDotNetRobust.Shop;

namespace TipsDotNetRobust.Customer
{
    public class UninterestedCustomer : ICustomer
    {
        private readonly string _name;

        public string Name { get { return _name; } }

        public UninterestedCustomer(string name)
        {
            _name = name;
        }

        public bool IsCorrectShop(IShop shop)
        {
            return false;
        }

        public string WhatToOrder()
        {
            throw new NotImplementedException();
        }
    }
}
