namespace MovieTheater.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTheater : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Theaters",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        SeatWidth = c.Byte(nullable: false),
                        SeatHeight = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Theaters");
        }
    }
}
