namespace MovieTheater.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedTheaterSeatings : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.TheaterSeatings");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TheaterSeatings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
        }
    }
}
