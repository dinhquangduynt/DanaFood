namespace ThucPham.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "TotalMoney", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "TotalMoney");
        }
    }
}
