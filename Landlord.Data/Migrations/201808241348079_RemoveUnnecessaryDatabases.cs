namespace Landlord.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveUnnecessaryDatabases : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PropertyCreate", "Tenant_TenantId", "dbo.TenantList");
            DropIndex("dbo.PropertyCreate", new[] { "Tenant_TenantId" });
            //DropTable("dbo.PropertyCreate");
            //DropTable("dbo.TenantList");
            //DropTable("dbo.TenantCreate");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TenantCreate",
                c => new
                    {
                        FirstName = c.String(nullable: false, maxLength: 128),
                        LastName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.FirstName);
            
            CreateTable(
                "dbo.TenantList",
                c => new
                    {
                        TenantId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.TenantId);
            
            CreateTable(
                "dbo.PropertyCreate",
                c => new
                    {
                        Address = c.String(nullable: false, maxLength: 128),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        ApartmentNumber = c.Int(nullable: false),
                        Rent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tenant_TenantId = c.Int(),
                    })
                .PrimaryKey(t => t.Address);
            
            CreateIndex("dbo.PropertyCreate", "Tenant_TenantId");
            AddForeignKey("dbo.PropertyCreate", "Tenant_TenantId", "dbo.TenantList", "TenantId");
        }
    }
}
