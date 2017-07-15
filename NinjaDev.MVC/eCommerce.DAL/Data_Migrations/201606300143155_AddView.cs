namespace eCommerce.DAL.Data_Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddView : DbMigration
    {
        public override void Up()
        {
            //this.OperationCreateView(
            //    "Top5BestOrderCustomers",
            //    @" SELECT TOP (5) MIN(History.Customers.CustomerName) as Name, COUNT(History.Orders.[Key]) as OrderCount FROM	History.Customers  INNER JOIN  History.Orders  ON History.Customers.[Key] = History.Orders.CustomerKey GROUP BY History.Customers.[Key] ORDER BY OrderCount DESC "
            //    );
        }

        public override void Down()
        {
            //this.OperationRemoveView("Top5BestOrderCustomers");
        }
    }
}
