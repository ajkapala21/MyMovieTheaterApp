namespace MovieTheater.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserIdToTicket : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "UserId");
        }
    }
}
