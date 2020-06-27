namespace ThucPham.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeSupportDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SupportOnlines", "Title", c => c.String(nullable: false, maxLength: 200));
            AddColumn("dbo.SupportOnlines", "Content", c => c.String(maxLength: 500));
            AlterColumn("dbo.SupportOnlines", "Name", c => c.String(maxLength: 100));
            DropColumn("dbo.SupportOnlines", "Department");
            DropColumn("dbo.SupportOnlines", "Mobile");
            DropColumn("dbo.SupportOnlines", "Status");
            DropColumn("dbo.SupportOnlines", "DisplayOrder");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SupportOnlines", "DisplayOrder", c => c.Int());
            AddColumn("dbo.SupportOnlines", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.SupportOnlines", "Mobile", c => c.String(maxLength: 50));
            AddColumn("dbo.SupportOnlines", "Department", c => c.String(maxLength: 50));
            AlterColumn("dbo.SupportOnlines", "Name", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.SupportOnlines", "Content");
            DropColumn("dbo.SupportOnlines", "Title");
        }
    }
}
