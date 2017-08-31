namespace LibHomeBudget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExpandSettings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Settings", "LimitLastTimeSet", c => c.DateTime(nullable: false));
            AddColumn("dbo.Settings", "AmountToSpend", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Settings", "AmountToSpend");
            DropColumn("dbo.Settings", "LimitLastTimeSet");
        }
    }
}
