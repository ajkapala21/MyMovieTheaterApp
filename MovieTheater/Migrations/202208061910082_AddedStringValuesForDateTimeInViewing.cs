namespace MovieTheater.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStringValuesForDateTimeInViewing : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Viewings", "TimeStartOutput", c => c.String());
            AddColumn("dbo.Viewings", "TimeEndOutput", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Viewings", "TimeEndOutput");
            DropColumn("dbo.Viewings", "TimeStartOutput");
        }
    }
}
