namespace Landlord.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Property", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Property", "OwnerId");
        }
    }
}
