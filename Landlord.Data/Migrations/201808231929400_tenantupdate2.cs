namespace Landlord.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tenantupdate2 : DbMigration
    {
        public override void Up()
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TenantList");
            DropTable("dbo.TenantCreate");
        }
    }
}
