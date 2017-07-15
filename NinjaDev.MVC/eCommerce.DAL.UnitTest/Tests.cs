using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Filters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eCommerce.DAL.UnitTest
{
    [TestClass]
    public class Tests
    {
        public Tests()
        {
            Database.SetInitializer(new NullDatabaseInitializer<DataContext>());
        }

        [TestMethod]
        public void CanLogToConsole()
        {
            Action<DataContext> callback = (ctx) =>
            {
                ctx.Database.Log = Console.Write;
                ctx.Customers.FirstOrDefault();
            };
            TestInconclusive(callback);
        }

        [TestMethod]
        public void CanLogWithoutLogProperty()
        {
            Action<DataContext> callback = (ctx) => { ctx.Customers.FirstOrDefault(); };
            TestInconclusive(callback);
        }

        private void TestInconclusive(Action<DataContext> callback)
        {
            using (var context = new DataContext())
            {
                callback(context);
                Assert.Inconclusive("Check Test Output");
            }
        }

        [TestMethod]
        public void CanWitnessExecuteNonReader() 
        {
            using (var context = new DataContext())
            {
                var cust = context.Customers.FirstOrDefault();
                if (cust != null) cust.CustomerName += " Updated";
                context.SaveChanges();
                context.Database.SqlQuery<int>("SELECT COUNT([Key]) FROM adbadasdf").ToArrayAsync();
                Assert.Inconclusive("For the purpose of debugging an interceptor");
            }
        }

        [TestMethod]
        public void SuccessfullyConnectToDatabase()
        {
            using (var context = new DataContext())
            {
                //context.EnableFilter("IsNotDeletedCustomers");
                Assert.IsNotNull(context.Customers.ToList());
            }
        }
        
    }
}
