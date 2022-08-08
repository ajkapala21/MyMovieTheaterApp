namespace MovieTheater.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedOwnedTicketsFromUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Tickets", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Tickets", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Tickets", "ApplicationUser_Id");
            AddForeignKey("dbo.Tickets", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
