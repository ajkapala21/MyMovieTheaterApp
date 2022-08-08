namespace MovieTheater.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTheaterSeatings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TheaterSeatings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TheaterSeatings");
        }
    }
}
