namespace ThucPham.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldOnFeedbackTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Feedbacks", "Title", c => c.String(maxLength: 200));
            AddColumn("dbo.Feedbacks", "EmailContent", c => c.String(maxLength: 500));
            AddColumn("dbo.OrderDetails", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.OrderDetails", "ProductName", c => c.String());
            AlterColumn("dbo.Feedbacks", "Status", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Feedbacks", "Status", c => c.Boolean(nullable: false));
            DropColumn("dbo.OrderDetails", "ProductName");
            DropColumn("dbo.OrderDetails", "Price");
            DropColumn("dbo.Feedbacks", "EmailContent");
            DropColumn("dbo.Feedbacks", "Title");
        }
    }
}
