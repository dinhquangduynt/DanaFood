namespace ThucPham.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeDb : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SupportOnlines", "Title", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SupportOnlines", "Title", c => c.String(nullable: false, maxLength: 200));
        }
    }
}
