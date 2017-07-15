using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using eCommerce.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eCommerce.DAL.UnitTest
{
    [TestClass]
    public class InitializerTest
    {
        [TestMethod]
        public void CanUseDropCreateAlwaysWithInitializer()
        {
            Database.SetInitializer(new DataInitializer());
            using (var context = new DataContext())
            {
                context.Customers.ToList();
            }

            Assert.Inconclusive("Check test output for logging info");
        }

        [TestMethod]
        public void CanDeleteInitializer()
        {
            using (var context = new DataContext())
            {
                var cus = context.Customers.FirstOrDefault(customer => customer.Key.ToString() == "48EBA18A-F8C9-4687-BF11-0A74C9F96A8F");

                context.Customers.Remove(cus);
            }

            Assert.Inconclusive("Check test output for logging info");
        }

        

    }
}
