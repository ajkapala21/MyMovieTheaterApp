namespace MovieTheater.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSoldOutBoolToViewing : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Viewings", "SoldOut", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Viewings", "SoldOut");
        }
    }
}
