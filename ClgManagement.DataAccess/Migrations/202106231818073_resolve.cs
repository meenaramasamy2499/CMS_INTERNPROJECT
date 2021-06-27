namespace ClgManagement.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class resolve : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IssueReports", "IsResolved", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.IssueReports", "IsResolved");
        }
    }
}
