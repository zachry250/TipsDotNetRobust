using Autofac;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TipsDotNetRobust.Customer;
using TipsDotNetRobust.Shop;

namespace TipsDotNetRobust
{
    public class Bootstrapper
    {
        public static Runner RegisterDependenciesForRunner()
        {
            var builder = new ContainerBuilder();

            //Register dependencies here!
            builder.Register(c => LogManager.GetLogger(typeof(Runner))).As<ILog>();
            builder.RegisterType<Runner>();
            builder.RegisterType<CoffeeShop>().As<IShop>();
            builder.RegisterInstance(new CoffeeCustomer("Alice the quick", 5, "regular coffee and a small cookie")).As<ICustomer>();
            builder.RegisterInstance(new UninterestedCustomer("Daniel the roamer")).As<ICustomer>();
            builder.RegisterInstance(new CoffeeCustomer("Adam the slow", 40, "regular coffee and a big cookie")).As<ICustomer>();

            var container = builder.Build();
            var runner = container.Resolve<Runner>();
            return runner;
        }
    }
}
