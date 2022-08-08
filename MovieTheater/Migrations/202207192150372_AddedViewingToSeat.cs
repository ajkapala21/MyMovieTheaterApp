namespace MovieTheater.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedViewingToSeat : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Seats", "ViewingId", c => c.Int(nullable: false));
            CreateIndex("dbo.Seats", "ViewingId");
            AddForeignKey("dbo.Seats", "ViewingId", "dbo.Viewings", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Seats", "ViewingId", "dbo.Viewings");
            DropIndex("dbo.Seats", new[] { "ViewingId" });
            DropColumn("dbo.Seats", "ViewingId");
        }
    }
}
