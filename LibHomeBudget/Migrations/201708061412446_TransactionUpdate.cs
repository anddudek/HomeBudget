namespace LibHomeBudget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "Date");
        }
    }
}
