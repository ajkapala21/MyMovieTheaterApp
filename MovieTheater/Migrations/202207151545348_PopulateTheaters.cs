namespace MovieTheater.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateTheaters : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Theaters (Id, Name, SeatWidth, SeatHeight) VALUES (1, 'Theater One', 6, 8)");
            Sql("INSERT INTO Theaters (Id, Name, SeatWidth, SeatHeight) VALUES (2, 'Theater Two', 6, 8)");
            Sql("INSERT INTO Theaters (Id, Name, SeatWidth, SeatHeight) VALUES (3, 'Theater Three', 8, 10)");
            Sql("INSERT INTO Theaters (Id, Name, SeatWidth, SeatHeight) VALUES (4, 'Theater Four', 6, 6)");
        }
        
        public override void Down()
        {
        }
    }
}
