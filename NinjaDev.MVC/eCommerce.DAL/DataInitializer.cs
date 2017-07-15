using System;
using System.Data.Entity;
using eCommerce.Classes;

namespace eCommerce.DAL
{
    public class DataInitializer : DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            CustomerArea area = new CustomerArea {Key = new Guid(0x73646976, 0x0000, 0x0010, 0x80, 0x00, 0x00, 0xAA, 0x00, 0x38, 0x9B, 0x71), Name = "Pasitic Asian"};
            Customer cus = new Customer
            {
                Key = new Guid(0x48eba18e, 0xf8c9, 0x4687, 0xbf, 0x11, 0x0a, 0x74, 0xc9, 0xf9, 0x6a, 0x8f),
                CustomerName = "John Doe",
                DateOfBirth = new DateTime(1990, 02, 08),
                Address = "25 Oasinton street, Singapre City, Singapore",
                Town = "Singapore",
                PostCode = "+56",
                OrderLevel = false
            };
            cus = new Customer { Key = new Guid(0x48eba18a, 0xf8c9, 0x4687, 0xbf, 0x11, 0x0a, 0x74, 0xc9, 0xf9, 0x6a, 0x8f), CustomerName = "John Papa", DateOfBirth = new DateTime(1990, 02, 08), Address = "25 Oasinton street, Singapre City, Singapore", Town = "Singapore", PostCode = "+56", OrderLevel = true };
            area.Customers.Add(cus);
            cus = new Customer { Key = new Guid(0x48eba18b, 0xf8c9, 0x4687, 0xbf, 0x11, 0x0a, 0x74, 0xc9, 0xf9, 0x6a, 0x8f), CustomerName = "John Smith", DateOfBirth = new DateTime(1990, 02, 08), Address = "25 Oasinton street, Singapre City, Singapore", Town = "Singapore", PostCode = "+56", OrderLevel = true };
            area.Customers.Add(cus);
            cus = new Customer { Key = new Guid(0x48eba18c, 0xf8c9, 0x4687, 0xbf, 0x11, 0x0a, 0x74, 0xc9, 0xf9, 0x6a, 0x8f), CustomerName = "Adam Smith", DateOfBirth = new DateTime(1990, 02, 08), Address = "25 Oasinton street, Singapre City, Singapore", Town = "Singapore", PostCode = "+56", OrderLevel = true };


            area.Customers.Add(cus);
            context.CustomerAreas.Add(area);


            area = new CustomerArea { Key = new Guid(0x73646977, 0x0000, 0x0010, 0x80, 0x00, 0x00, 0xAA, 0x00, 0x38, 0x9B, 0x71), Name = "North America" };
            cus = new Customer { Key = new Guid(0x48eba18d, 0xf8c9, 0x4687, 0xbf, 0x11, 0x0a, 0x74, 0xc9, 0xf9, 0x6a, 0x8f), CustomerName = "John Doe", DateOfBirth = new DateTime(1990, 02, 08), Address = "25 Oasinton street, Singapre City, Singapore", Town = "Singapore", PostCode = "+56", OrderLevel = false };
            cus = new Customer { Key = new Guid(0x48eba18f, 0xf8c9, 0x4687, 0xbf, 0x11, 0x0a, 0x74, 0xc9, 0xf9, 0x6a, 0x8f), CustomerName = "John Papa", DateOfBirth = new DateTime(1990, 02, 08), Address = "25 Oasinton street, Singapre City, Singapore", Town = "Singapore", PostCode = "+56", OrderLevel = true };
            area.Customers.Add(cus);
            cus = new Customer { Key = new Guid(0x48eba19a, 0xf8c9, 0x4687, 0xbf, 0x11, 0x0a, 0x74, 0xc9, 0xf9, 0x6a, 0x8f), CustomerName = "John Smith", DateOfBirth = new DateTime(1990, 02, 08), Address = "25 Oasinton street, Singapre City, Singapore", Town = "Singapore", PostCode = "+56", OrderLevel = true };
            area.Customers.Add(cus);
            cus = new Customer { Key = new Guid(0x48eba19b, 0xf8c9, 0x4687, 0xbf, 0x11, 0x0a, 0x74, 0xc9, 0xf9, 0x6a, 0x8f), CustomerName = "Adam Smith", DateOfBirth = new DateTime(1990, 02, 08), Address = "25 Oasinton street, Singapre City, Singapore", Town = "Singapore", PostCode = "+56", OrderLevel = true };

            area.Customers.Add(cus);
            context.CustomerAreas.Add(area);

            base.Seed(context);
        }
    }
}