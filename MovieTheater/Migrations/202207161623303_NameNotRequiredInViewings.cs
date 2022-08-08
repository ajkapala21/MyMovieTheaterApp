namespace MovieTheater.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameNotRequiredInViewings : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Viewings", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Viewings", "Name", c => c.String(nullable: false));
        }
    }
}
