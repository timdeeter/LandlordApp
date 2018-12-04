namespace Landlord.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jsonConvert : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Property", "LocationGeoData", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Property", "LocationGeoData");
        }
    }
}
