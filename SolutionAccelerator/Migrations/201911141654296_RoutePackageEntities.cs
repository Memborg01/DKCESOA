namespace SolutionAccelerator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoutePackageEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Airport",
                c => new
                    {
                        AirportId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Availability = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AirportId);
            
            DropTable("dbo.Transaction");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Transaction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PacketId = c.Int(nullable: false),
                        Routes = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Airport");
        }
    }
}