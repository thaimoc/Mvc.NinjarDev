namespace eCommerce.DAL.Data_Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnotationAndCreateStoreProcedureOnCustomersTable : DbMigration
    {
        public override void Up()
        {
            AlterTableAnnotations(
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
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "View",
                        new AnnotationValues(oldValue: null, newValue: "CustomersWhoHadTheFirstOrder|SELECT [Key],CustomerName FROM History.Customers  WHERE OrderLevel=1")
                    },
                });
            
            CreateStoredProcedure(
                "AnythingsBut_dbo.Customers_Insert",
                p => new
                    {
                        CustomerKey = p.Guid(),
                        CustomerName = p.String(maxLength: 256),
                        DateOfBirth = p.DateTime(),
                        Address = p.String(maxLength: 255),
                        Town = p.String(maxLength: 255),
                        PostCode = p.String(maxLength: 255),
                        OrderLevel = p.Boolean(),
                        DateModified = p.DateTime(),
                        DateCreated = p.DateTime(),
                        CustomerArea_FKKey = p.Guid(),
                    },
                body:
                    @"INSERT [History].[Customers]([Key], [CustomerName], [DateOfBirth], [Address], [Town], [PostCode], [OrderLevel], [DateModified], [DateCreated], [CustomerArea_FKKey])
                      VALUES (@CustomerKey, @CustomerName, @DateOfBirth, @Address, @Town, @PostCode, @OrderLevel, @DateModified, @DateCreated, @CustomerArea_FKKey)"
            );
            
            CreateStoredProcedure(
                "AnythingsBut_dbo.Customers_Update",
                p => new
                    {
                        Key = p.Guid(),
                        CustomerName = p.String(maxLength: 256),
                        DateOfBirth = p.DateTime(),
                        Address = p.String(maxLength: 255),
                        Town = p.String(maxLength: 255),
                        PostCode = p.String(maxLength: 255),
                        OrderLevel = p.Boolean(),
                        DateModified = p.DateTime(),
                        DateCreated = p.DateTime(),
                        CustomerArea_Key = p.Guid(),
                    },
                body:
                    @"UPDATE [History].[Customers]
                      SET [CustomerName] = @CustomerName, [DateOfBirth] = @DateOfBirth, [Address] = @Address, [Town] = @Town, [PostCode] = @PostCode, [OrderLevel] = @OrderLevel, [DateModified] = @DateModified, [DateCreated] = @DateCreated, [CustomerArea_FKKey] = @CustomerArea_Key
                      WHERE ([Key] = @Key)"
            );
            
            CreateStoredProcedure(
                "AnythingsBut_dbo.Customers_Delete",
                p => new
                    {
                        CustomerKey = p.Guid(),
                        CustomerArea_Key = p.Guid(),
                    },
                body:
                    @"DELETE [History].[Customers]
                      WHERE (([Key] = @CustomerKey) AND (([CustomerArea_FKKey] = @CustomerArea_Key) OR ([CustomerArea_FKKey] IS NULL AND @CustomerArea_Key IS NULL)))"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("AnythingsBut_dbo.Customers_Delete");
            DropStoredProcedure("AnythingsBut_dbo.Customers_Update");
            DropStoredProcedure("AnythingsBut_dbo.Customers_Insert");
            AlterTableAnnotations(
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
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "View",
                        new AnnotationValues(oldValue: "CustomersWhoHadTheFirstOrder|SELECT [Key],CustomerName FROM History.Customers  WHERE OrderLevel=1", newValue: null)
                    },
                });
            
        }
    }
}
