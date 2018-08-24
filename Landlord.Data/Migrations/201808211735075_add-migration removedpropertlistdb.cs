namespace Landlord.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigrationremovedpropertlistdb : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.PropertyList");
        }
        
        public override void Down()
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
    }
}
