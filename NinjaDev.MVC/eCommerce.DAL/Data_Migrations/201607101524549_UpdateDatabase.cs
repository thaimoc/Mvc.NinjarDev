namespace eCommerce.DAL.Data_Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
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
                        IsDeleted = c.Boolean(nullable: false),
                        CustomerArea_FKKey = c.Guid(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "globalFilter_IsNotDeletedCustomers",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.Filters.FilterDefinition")
                    },
                });
            
        }
        
        public override void Down()
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
                        IsDeleted = c.Boolean(nullable: false),
                        CustomerArea_FKKey = c.Guid(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "globalFilter_IsNotDeletedCustomers",
                        new AnnotationValues(oldValue: "EntityFramework.Filters.FilterDefinition", newValue: null)
                    },
                });
            
        }
    }
}
