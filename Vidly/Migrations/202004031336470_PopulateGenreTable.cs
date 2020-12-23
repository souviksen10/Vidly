namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Name) VALUES ('COMEDY'),('ACTION'),('FAMILY'),('ROMANCE'),('HORROR')");
        }

        public override void Down()
        {
            Sql("DELETE FROM Genres WHERE Id BETWEEN 1 AND 5");
        }
    }
}
