using System;
using System.Collections.Generic;
using System.Linq;
using eCommerce.Classes;

namespace eCommerce.DAL
{
    public class DataBaseHelpers
    {
        public static void NewDbWithSeed()
        {
            using (var context = new DataContext())
            {
                if(context.Customers.Any()) return;

                context.Customers.Add(new Customer
                {
                    CustomerName = "John Doe",
                    DateOfBirth = new DateTime(1990, 12, 25),
                    Address = "58/7 LodAngerless",
                    Town = "OHIO",
                    PostCode = "+56",
                    Products = new EnumerableQuery<Product>(new List<Product>())
                });

                context.Customers.Add(new Customer
                {
                    CustomerName = "Viladime Konoxop",
                    DateOfBirth = new DateTime(1990, 12, 25),
                    Address = "5/7 LodAngerless",
                    Town = "Michigan",
                    PostCode = "+56",
                    Products = new EnumerableQuery<Product>(new List<Product>())
                });

                context.Customers.Add(new Customer
                {
                    CustomerName = "Ju Jong",
                    DateOfBirth = new DateTime(1990, 12, 25),
                    Address = "3 LodAngerless",
                    Town = "Oronto",
                    PostCode = "+56",
                    Products = new EnumerableQuery<Product>(new List<Product>())
                });


                context.Products.Add(new Product
                {
                    Customers = new EnumerableQuery<Customer>(new List<Customer>()),
                    Description = "Fast Food, Humberger cake for everybody.",
                    ImageUrl = "Ignore it",
                    Price = 1.99M
                });

                context.Products.Add(new Product
                {
                    Customers = new EnumerableQuery<Customer>(new List<Customer>()),
                    Description = "Fast Food, Stanbug Coffee cake for everybody.",
                    ImageUrl = "Ignore it",
                    Price = 1.99M
                });

                context.Products.Add(new Product
                {
                    Customers = new EnumerableQuery<Customer>(new List<Customer>()),
                    Description = "Fast Food, Japanese Susi cake for everybody.",
                    ImageUrl = "Ignore it",
                    Price = 1.99M
                });


                context.SaveChangesAsync();

                context.Database.ExecuteSqlCommand(
                    @"CREATE PROCEDURE GetOldCustomers
                    AS  SELECT * FROM Customers WHERE DateOfBirth<='1/1/1980'");

                context.Database.ExecuteSqlCommand(
                   @"CREATE PROCEDURE DeleteCustomerViaId
                     @Id int
                     AS
                     DELETE from Customers Where Id = @id
                     RETURN @@rowcount");
            }
        }
    }
}