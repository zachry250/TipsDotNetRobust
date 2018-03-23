using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TipsDotNetRobust.Shop;

namespace TipsDotNetRobust.Customer
{
    public interface ICustomer
    {
        string Name { get; }
        bool IsCorrectShop(IShop shop);
        string WhatToOrder();
    }
}
