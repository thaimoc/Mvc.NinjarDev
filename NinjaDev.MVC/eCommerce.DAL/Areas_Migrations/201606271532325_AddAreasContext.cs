namespace eCommerce.DAL.Areas_Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAreasContext : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Customeres", newName: "Customers");
            MoveTable(name: "dbo.Customerareas", newSchema: "AnythingsBut_dbo");
            MoveTable(name: "dbo.Customers", newSchema: "History");
            MoveTable(name: "dbo.Persones", newSchema: "AnythingsBut_dbo");
        }
        
        public override void Down()
        {
            MoveTable(name: "AnythingsBut_dbo.Persones", newSchema: "dbo");
            MoveTable(name: "History.Customers", newSchema: "dbo");
            MoveTable(name: "AnythingsBut_dbo.Customerareas", newSchema: "dbo");
            RenameTable(name: "dbo.Customers", newName: "Customeres");
        }
    }
}
