namespace eCommerce.DAL.Data_Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "AnythingsBut_dbo.Customerareas",
                c => new
                    {
                        Key = c.Guid(nullable: false),
                        Name = c.String(maxLength: 255),
                        DateModified = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Key);
            
            CreateTable(
                "History.Customers",
                c => new
                    {
                        Key = c.Guid(nullable: false),
                        CustomerName = c.String(nullable: false, maxLength: 256),
                        DateOfBirth = c.DateTime(nullable: false),
                        Address = c.String(maxLength: 255),
                        Town = c.String(maxLength: 255),
                        PostCode = c.String(maxLength: 255),
                        OrderLevel = c.Boolean(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        CustomerArea_FKKey = c.Guid(),
                    })
                .PrimaryKey(t => t.Key)
                .ForeignKey("AnythingsBut_dbo.Customerareas", t => t.CustomerArea_FKKey)
                .Index(t => t.CustomerName, name: "Idx_History.Customers.Customer_Name")
                .Index(t => t.CustomerArea_FKKey, name: "IX_CustomerArea_Key");
            
            CreateTable(
                "AnythingsBut_dbo.Persones",
                c => new
                    {
                        Key = c.Guid(nullable: false),
                        Name = c.String(maxLength: 255),
                        BirthDate = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Key)
                .ForeignKey("History.Customers", t => t.Key)
                .Index(t => t.Key)
                .Index(t => t.Name, name: "PersonName");
            
            CreateTable(
                "History.OrderItems",
                c => new
                    {
                        Key = c.Guid(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderKey = c.Guid(nullable: false),
                        ProductKey = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Key)
                .ForeignKey("History.Orders", t => t.OrderKey, cascadeDelete: true)
                .ForeignKey("History.Products", t => t.ProductKey, cascadeDelete: true)
                .Index(t => t.OrderKey)
                .Index(t => t.ProductKey);
            
            CreateTable(
                "History.Orders",
                c => new
                    {
                        Key = c.Guid(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        CustomerKey = c.Guid(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Key)
                .ForeignKey("History.Customers", t => t.CustomerKey, cascadeDelete: true)
                .Index(t => t.CustomerKey);
            
            CreateTable(
                "History.Products",
                c => new
                    {
                        Key = c.Guid(nullable: false),
                        Description = c.String(maxLength: 4000),
                        ImageUrl = c.String(maxLength: 255),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateModified = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Key);
            
        }
        
        public override void Down()
        {
            DropForeignKey("History.OrderItems", "ProductKey", "History.Products");
            DropForeignKey("History.OrderItems", "OrderKey", "History.Orders");
            DropForeignKey("History.Orders", "CustomerKey", "History.Customers");
            DropForeignKey("History.Customers", "CustomerArea_FKKey", "AnythingsBut_dbo.Customerareas");
            DropForeignKey("AnythingsBut_dbo.Persones", "Key", "History.Customers");
            DropIndex("History.Orders", new[] { "CustomerKey" });
            DropIndex("History.OrderItems", new[] { "ProductKey" });
            DropIndex("History.OrderItems", new[] { "OrderKey" });
            DropIndex("AnythingsBut_dbo.Persones", "PersonName");
            DropIndex("AnythingsBut_dbo.Persones", new[] { "Key" });
            DropIndex("History.Customers", "IX_CustomerArea_Key");
            DropIndex("History.Customers", "Idx_History.Customers.Customer_Name");
            DropTable("History.Products");
            DropTable("History.Orders");
            DropTable("History.OrderItems");
            DropTable("AnythingsBut_dbo.Persones");
            DropTable("History.Customers");
            DropTable("AnythingsBut_dbo.Customerareas");
        }
    }
}
