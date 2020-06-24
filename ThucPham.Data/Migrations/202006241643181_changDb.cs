namespace ThucPham.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changDb : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserRoles", newName: "__mig_tmp__0");
            RenameTable(name: "dbo.Roles", newName: "UserRoles");
            RenameTable(name: "__mig_tmp__0", newName: "Roles");
            DropForeignKey("dbo.Menus", "GroupID", "dbo.MenuGroups");
            DropForeignKey("dbo.RoleGroups", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.RoleGroups", "RoleId", "dbo.UserRoles");
            DropForeignKey("dbo.UserGroups", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.UserGroups", "UserId", "dbo.Users");
            DropIndex("dbo.Menus", new[] { "GroupID" });
            DropIndex("dbo.RoleGroups", new[] { "GroupId" });
            DropIndex("dbo.RoleGroups", new[] { "RoleId" });
            DropIndex("dbo.UserGroups", new[] { "UserId" });
            DropIndex("dbo.UserGroups", new[] { "GroupId" });
            DropTable("dbo.Footers");
            DropTable("dbo.Groups");
            DropTable("dbo.MenuGroups");
            DropTable("dbo.Menus");
            DropTable("dbo.RoleGroups");
            DropTable("dbo.Slides");
            DropTable("dbo.UserGroups");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserGroups",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.GroupId });
            
            CreateTable(
                "dbo.Slides",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(maxLength: 256),
                        Image = c.String(maxLength: 256),
                        Url = c.String(maxLength: 256),
                        DisplayOrder = c.Int(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RoleGroups",
                c => new
                    {
                        GroupId = c.Int(nullable: false),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.GroupId, t.RoleId });
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        URL = c.String(nullable: false, maxLength: 256),
                        DisplayOrder = c.Int(),
                        GroupID = c.Int(nullable: false),
                        Target = c.String(maxLength: 10),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MenuGroups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        Description = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Footers",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 50),
                        Content = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.UserGroups", "GroupId");
            CreateIndex("dbo.UserGroups", "UserId");
            CreateIndex("dbo.RoleGroups", "RoleId");
            CreateIndex("dbo.RoleGroups", "GroupId");
            CreateIndex("dbo.Menus", "GroupID");
            AddForeignKey("dbo.UserGroups", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserGroups", "GroupId", "dbo.Groups", "ID", cascadeDelete: true);
            AddForeignKey("dbo.RoleGroups", "RoleId", "dbo.UserRoles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RoleGroups", "GroupId", "dbo.Groups", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Menus", "GroupID", "dbo.MenuGroups", "ID", cascadeDelete: true);
            RenameTable(name: "Roles", newName: "__mig_tmp__0");
            RenameTable(name: "dbo.UserRoles", newName: "Roles");
            RenameTable(name: "dbo.__mig_tmp__0", newName: "UserRoles");
        }
    }
}
