namespace Landlord.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class propertylistfix : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PropertyList",
                c => new
                    {
                        PropertyId = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        DateClaimed = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.PropertyId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PropertyList");
        }
    }
}
