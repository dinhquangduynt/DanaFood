namespace ThucPham.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Roles", newName: "__mig_tmp__0");
            RenameTable(name: "dbo.UserRoles", newName: "Roles");
            RenameTable(name: "__mig_tmp__0", newName: "UserRoles");
        }
        
        public override void Down()
        {
            RenameTable(name: "UserRoles", newName: "__mig_tmp__0");
            RenameTable(name: "dbo.Roles", newName: "UserRoles");
            RenameTable(name: "dbo.__mig_tmp__0", newName: "Roles");
        }
    }
}
