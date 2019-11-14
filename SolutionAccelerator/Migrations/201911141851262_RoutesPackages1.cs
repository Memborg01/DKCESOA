namespace SolutionAccelerator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoutesPackages1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Route",
                c => new
                    {
                        RouteID = c.Int(nullable: false, identity: true),
                        Time = c.Int(nullable: false),
                        DestinationA_AirportId = c.Int(),
                        DestinationB_AirportId = c.Int(),
                        PacketPrice_PacketPriceID = c.Int(),
                    })
                .PrimaryKey(t => t.RouteID)
                .ForeignKey("dbo.Airport", t => t.DestinationA_AirportId)
                .ForeignKey("dbo.Airport", t => t.DestinationB_AirportId)
                .ForeignKey("dbo.PacketPrice", t => t.PacketPrice_PacketPriceID)
                .Index(t => t.DestinationA_AirportId)
                .Index(t => t.DestinationB_AirportId)
                .Index(t => t.PacketPrice_PacketPriceID);
            
            CreateTable(
                "dbo.PacketPrice",
                c => new
                    {
                        PacketPriceID = c.Int(nullable: false, identity: true),
                        Price_PriceID = c.Int(),
                        Weight_WeightID = c.Int(),
                    })
                .PrimaryKey(t => t.PacketPriceID)
                .ForeignKey("dbo.Price", t => t.Price_PriceID)
                .ForeignKey("dbo.Weight", t => t.Weight_WeightID)
                .Index(t => t.Price_PriceID)
                .Index(t => t.Weight_WeightID);
            
            CreateTable(
                "dbo.Price",
                c => new
                    {
                        PriceID = c.Int(nullable: false, identity: true),
                        Currency = c.String(),
                        Amount = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.PriceID);
            
            CreateTable(
                "dbo.Weight",
                c => new
                    {
                        WeightID = c.Int(nullable: false, identity: true),
                        Min = c.Single(nullable: false),
                        Max = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.WeightID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Route", "PacketPrice_PacketPriceID", "dbo.PacketPrice");
            DropForeignKey("dbo.PacketPrice", "Weight_WeightID", "dbo.Weight");
            DropForeignKey("dbo.PacketPrice", "Price_PriceID", "dbo.Price");
            DropForeignKey("dbo.Route", "DestinationB_AirportId", "dbo.Airport");
            DropForeignKey("dbo.Route", "DestinationA_AirportId", "dbo.Airport");
            DropIndex("dbo.PacketPrice", new[] { "Weight_WeightID" });
            DropIndex("dbo.PacketPrice", new[] { "Price_PriceID" });
            DropIndex("dbo.Route", new[] { "PacketPrice_PacketPriceID" });
            DropIndex("dbo.Route", new[] { "DestinationB_AirportId" });
            DropIndex("dbo.Route", new[] { "DestinationA_AirportId" });
            DropTable("dbo.Weight");
            DropTable("dbo.Price");
            DropTable("dbo.PacketPrice");
            DropTable("dbo.Route");
        }
    }
}
