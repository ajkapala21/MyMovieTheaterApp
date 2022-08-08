namespace MovieTheater.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTickets : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SeatName = c.String(nullable: false),
                        ViewingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Viewings", t => t.ViewingId, cascadeDelete: true)
                .Index(t => t.ViewingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "ViewingId", "dbo.Viewings");
            DropIndex("dbo.Tickets", new[] { "ViewingId" });
            DropTable("dbo.Tickets");
        }
    }
}
