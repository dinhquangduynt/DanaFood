namespace ThucPham.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Tags", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Tags");
            DropColumn("dbo.Products", "Quantity");
        }
    }
}
