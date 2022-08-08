namespace MovieTheater.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImagePathToMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "ImagePath");
        }
    }
}
