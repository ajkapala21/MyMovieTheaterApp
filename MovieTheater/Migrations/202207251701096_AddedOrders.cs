namespace MovieTheater.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOrders : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Seats", "Order_Id", c => c.Int());
            CreateIndex("dbo.Seats", "Order_Id");
            AddForeignKey("dbo.Seats", "Order_Id", "dbo.Orders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Seats", "Order_Id", "dbo.Orders");
            DropIndex("dbo.Seats", new[] { "Order_Id" });
            DropColumn("dbo.Seats", "Order_Id");
            DropTable("dbo.Orders");
        }
    }
}
