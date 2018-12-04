namespace Landlord.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class propertyTenantId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Property", name: "Tenant_TenantId", newName: "TenantId");
            RenameIndex(table: "dbo.Property", name: "IX_Tenant_TenantId", newName: "IX_TenantId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Property", name: "IX_TenantId", newName: "IX_Tenant_TenantId");
            RenameColumn(table: "dbo.Property", name: "TenantId", newName: "Tenant_TenantId");
        }
    }
}
