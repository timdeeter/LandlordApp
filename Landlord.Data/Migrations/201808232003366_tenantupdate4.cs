namespace Landlord.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tenantupdate4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TenantList",
                c => new
                    {
                        TenantId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.TenantId);
            
            AddColumn("dbo.Property", "Tenant_TenantId", c => c.Int());
            AddColumn("dbo.PropertyCreate", "Tenant_TenantId", c => c.Int());
            CreateIndex("dbo.Property", "Tenant_TenantId");
            CreateIndex("dbo.PropertyCreate", "Tenant_TenantId");
            AddForeignKey("dbo.Property", "Tenant_TenantId", "dbo.Tenant", "TenantId");
            AddForeignKey("dbo.PropertyCreate", "Tenant_TenantId", "dbo.TenantList", "TenantId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PropertyCreate", "Tenant_TenantId", "dbo.TenantList");
            DropForeignKey("dbo.Property", "Tenant_TenantId", "dbo.Tenant");
            DropIndex("dbo.PropertyCreate", new[] { "Tenant_TenantId" });
            DropIndex("dbo.Property", new[] { "Tenant_TenantId" });
            DropColumn("dbo.PropertyCreate", "Tenant_TenantId");
            DropColumn("dbo.Property", "Tenant_TenantId");
            DropTable("dbo.TenantList");
        }
    }
}
