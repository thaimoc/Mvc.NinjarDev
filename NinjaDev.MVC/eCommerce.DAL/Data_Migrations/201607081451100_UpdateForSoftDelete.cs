namespace eCommerce.DAL.Data_Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateForSoftDelete : DbMigration
    {
        public override void Up()
        {
            AddColumn("History.Customers", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("History.Orders", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("History.Products", "IsDeleted", c => c.Boolean(nullable: false));
            AlterStoredProcedure(
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
                        IsDeleted = p.Boolean(),
                        CustomerArea_FKKey = p.Guid(),
                    },
                body:
                    @"INSERT [History].[Customers]([Key], [CustomerName], [DateOfBirth], [Address], [Town], [PostCode], [OrderLevel], [DateModified], [DateCreated], [IsDeleted], [CustomerArea_FKKey])
                      VALUES (@CustomerKey, @CustomerName, @DateOfBirth, @Address, @Town, @PostCode, @OrderLevel, @DateModified, @DateCreated, @IsDeleted, @CustomerArea_FKKey)"
            );
            
            AlterStoredProcedure(
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
                        IsDeleted = p.Boolean(),
                        CustomerArea_Key = p.Guid(),
                    },
                body:
                    @"UPDATE [History].[Customers]
                      SET [CustomerName] = @CustomerName, [DateOfBirth] = @DateOfBirth, [Address] = @Address, [Town] = @Town, [PostCode] = @PostCode, [OrderLevel] = @OrderLevel, [DateModified] = @DateModified, [DateCreated] = @DateCreated, [IsDeleted] = @IsDeleted, [CustomerArea_FKKey] = @CustomerArea_Key
                      WHERE ([Key] = @Key)"
            );
            
        }
        
        public override void Down()
        {
            DropColumn("History.Products", "IsDeleted");
            DropColumn("History.Orders", "IsDeleted");
            DropColumn("History.Customers", "IsDeleted");
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
