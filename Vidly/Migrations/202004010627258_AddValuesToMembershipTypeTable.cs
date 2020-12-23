namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddValuesToMembershipTypeTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes VALUES (1,0,0,0)");
            Sql("INSERT INTO MembershipTypes VALUES (2,30,1,10)");
            Sql("INSERT INTO MembershipTypes VALUES (3,90,3,15)");
            Sql("INSERT INTO MembershipTypes VALUES (4,300,12,20)");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM MembershipTypes WHERE Id BETWEEN 1 AND 4");
        }
    }
}
