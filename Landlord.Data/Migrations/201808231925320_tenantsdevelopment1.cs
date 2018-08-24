namespace Landlord.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tenantsdevelopment1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tenant",
                c => new
                    {
                        TenantId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        DateMovedIn = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.TenantId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tenant");
        }
    }
}
