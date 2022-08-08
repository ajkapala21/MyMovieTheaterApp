namespace MovieTheater.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class neededv2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Viewings", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.Viewings", new[] { "Movie_Id" });
            RenameColumn(table: "dbo.Viewings", name: "Movie_Id", newName: "MovieId");
            AlterColumn("dbo.Viewings", "MovieId", c => c.Int(nullable: false));
            CreateIndex("dbo.Viewings", "MovieId");
            AddForeignKey("dbo.Viewings", "MovieId", "dbo.Movies", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Viewings", "MovieId", "dbo.Movies");
            DropIndex("dbo.Viewings", new[] { "MovieId" });
            AlterColumn("dbo.Viewings", "MovieId", c => c.Int());
            RenameColumn(table: "dbo.Viewings", name: "MovieId", newName: "Movie_Id");
            CreateIndex("dbo.Viewings", "Movie_Id");
            AddForeignKey("dbo.Viewings", "Movie_Id", "dbo.Movies", "Id");
        }
    }
}
