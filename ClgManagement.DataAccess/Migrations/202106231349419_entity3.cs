namespace ClgManagement.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class entity3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LeaveDetails", "IsApproved", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LeaveDetails", "IsApproved");
        }
    }
}
