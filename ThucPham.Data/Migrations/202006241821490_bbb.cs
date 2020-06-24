namespace ThucPham.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bbb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserRoles", "Discriminator");
        }
    }
}
