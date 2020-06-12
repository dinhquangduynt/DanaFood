namespace ThucPham.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateabc : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserClaims", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserLogins", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Roles", "UserId", "dbo.Users");
            DropForeignKey("dbo.Roles", "IdentityRole_Id", "dbo.UserRoles");
            DropIndex("dbo.UserClaims", new[] { "User_Id" });
            DropIndex("dbo.UserLogins", new[] { "User_Id" });
            DropIndex("dbo.Roles", new[] { "UserId" });
            DropIndex("dbo.Roles", new[] { "IdentityRole_Id" });
            CreateTable(
                "dbo.IdentityUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        FullName = c.String(maxLength: 256),
                        Address = c.String(maxLength: 256),
                        BirthDay = c.DateTime(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Roles", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Menus", "GroupID", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderDetails", "OrderID", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderDetails", "ProductID", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "CustomerId", c => c.String(maxLength: 128));
            AlterColumn("dbo.UserClaims", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.UserClaims", "User_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.UserLogins", "User_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Products", "CategoryID", c => c.Int(nullable: false));
            AlterColumn("dbo.Posts", "CategoryID", c => c.Int(nullable: false));
            AlterColumn("dbo.PostTags", "PostID", c => c.Int(nullable: false));
            AlterColumn("dbo.PostTags", "TagID", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.ProductTags", "ProductID", c => c.Int(nullable: false));
            AlterColumn("dbo.ProductTags", "TagID", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.RoleGroups", "GroupId", c => c.Int(nullable: false));
            AlterColumn("dbo.RoleGroups", "RoleId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.UserGroups", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.UserGroups", "GroupId", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.UserClaims");
            AddPrimaryKey("dbo.UserClaims", "Id");
            CreateIndex("dbo.UserClaims", "User_Id");
            CreateIndex("dbo.UserLogins", "User_Id");
            CreateIndex("dbo.Roles", "RoleId");
            CreateIndex("dbo.Roles", "UserId");
            AddForeignKey("dbo.UserClaims", "User_Id", "dbo.IdentityUsers", "Id");
            AddForeignKey("dbo.UserLogins", "User_Id", "dbo.IdentityUsers", "Id");
            AddForeignKey("dbo.Roles", "RoleId", "dbo.UserRoles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Roles", "UserId", "dbo.IdentityUsers", "Id", cascadeDelete: true);
            DropColumn("dbo.Roles", "IdentityRole_Id");
            DropColumn("dbo.UserClaims", "UserId");
            //DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(maxLength: 256),
                        Address = c.String(maxLength: 256),
                        BirthDay = c.DateTime(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.UserClaims", "UserId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Roles", "IdentityRole_Id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Roles", "UserId", "dbo.IdentityUsers");
            DropForeignKey("dbo.Roles", "RoleId", "dbo.UserRoles");
            DropForeignKey("dbo.UserLogins", "User_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.UserClaims", "User_Id", "dbo.IdentityUsers");
            DropIndex("dbo.Roles", new[] { "UserId" });
            DropIndex("dbo.Roles", new[] { "RoleId" });
            DropIndex("dbo.UserLogins", new[] { "User_Id" });
            DropIndex("dbo.UserClaims", new[] { "User_Id" });
            DropPrimaryKey("dbo.UserClaims");
            AddPrimaryKey("dbo.UserClaims", "UserId");
            AlterColumn("dbo.UserGroups", "GroupId", c => c.Int(nullable: false));
            AlterColumn("dbo.UserGroups", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.RoleGroups", "RoleId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.RoleGroups", "GroupId", c => c.Int(nullable: false));
            AlterColumn("dbo.ProductTags", "TagID", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.ProductTags", "ProductID", c => c.Int(nullable: false));
            AlterColumn("dbo.PostTags", "TagID", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.PostTags", "PostID", c => c.Int(nullable: false));
            AlterColumn("dbo.Posts", "CategoryID", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "CategoryID", c => c.Int(nullable: false));
            AlterColumn("dbo.UserLogins", "User_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.UserClaims", "User_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.UserClaims", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "CustomerId", c => c.String(maxLength: 128));
            AlterColumn("dbo.OrderDetails", "ProductID", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderDetails", "OrderID", c => c.Int(nullable: false));
            AlterColumn("dbo.Menus", "GroupID", c => c.Int(nullable: false));
            AlterColumn("dbo.Roles", "UserId", c => c.String(nullable: false, maxLength: 128));
            DropTable("dbo.IdentityUsers");
            CreateIndex("dbo.Roles", "IdentityRole_Id");
            CreateIndex("dbo.Roles", "UserId");
            CreateIndex("dbo.UserLogins", "User_Id");
            CreateIndex("dbo.UserClaims", "User_Id");
            AddForeignKey("dbo.Roles", "IdentityRole_Id", "dbo.UserRoles", "Id");
            AddForeignKey("dbo.Roles", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserLogins", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.UserClaims", "User_Id", "dbo.Users", "Id");
        }
    }
}
