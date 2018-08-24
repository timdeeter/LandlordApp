namespace Landlord.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tenantupdate3 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.TenantList");
        }
        
        public override void Down()
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
            
        }
    }
}
