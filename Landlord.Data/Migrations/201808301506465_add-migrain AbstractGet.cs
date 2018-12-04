namespace Landlord.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigrainAbstractGet : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Property", "Longitude", c => c.String());
            AddColumn("dbo.Property", "Latitude", c => c.String());
            DropColumn("dbo.Property", "LocationGeoData");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Property", "LocationGeoData", c => c.String());
            DropColumn("dbo.Property", "Latitude");
            DropColumn("dbo.Property", "Longitude");
        }
    }
}
