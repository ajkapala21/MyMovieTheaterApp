
namespace MovieTheater.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedViewings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Viewings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        TheaterId = c.Byte(nullable: false),
                        TimeStart = c.DateTime(nullable: false),
                        TimeEnd = c.DateTime(nullable: false),
                        Movie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.Movie_Id, cascadeDelete: true)
                .ForeignKey("dbo.Theaters", t => t.TheaterId, cascadeDelete: true)
                .Index(t => t.TheaterId)
                .Index(t => t.Movie_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Viewings", "TheaterId", "dbo.Theaters");
            DropForeignKey("dbo.Viewings", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.Viewings", new[] { "Movie_Id" });
            DropIndex("dbo.Viewings", new[] { "TheaterId" });
            DropTable("dbo.Viewings");
        }
    }
}
