namespace MovieTheater.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class needed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Viewings", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.Viewings", new[] { "Movie_Id" });
            AlterColumn("dbo.Viewings", "Movie_Id", c => c.Int());
            CreateIndex("dbo.Viewings", "Movie_Id");
            AddForeignKey("dbo.Viewings", "Movie_Id", "dbo.Movies", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Viewings", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.Viewings", new[] { "Movie_Id" });
            AlterColumn("dbo.Viewings", "Movie_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Viewings", "Movie_Id");
            AddForeignKey("dbo.Viewings", "Movie_Id", "dbo.Movies", "Id", cascadeDelete: true);
        }
    }
}
