namespace SolutionAccelerator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class APIDbChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PacketPrice", "Price_PriceID", "dbo.Price");
            DropForeignKey("dbo.PacketPrice", "Weight_WeightID", "dbo.Weight");
            DropIndex("dbo.PacketPrice", new[] { "Price_PriceID" });
            DropIndex("dbo.PacketPrice", new[] { "Weight_WeightID" });
            AddColumn("dbo.PacketPrice", "Price_Currency", c => c.String());
            AddColumn("dbo.PacketPrice", "Price_Amount", c => c.Single(nullable: false));
            AddColumn("dbo.PacketPrice", "Weight_Min", c => c.Single(nullable: false));
            AddColumn("dbo.PacketPrice", "Weight_Max", c => c.Single(nullable: false));
            AlterColumn("dbo.Route", "Time", c => c.DateTime(nullable: false));
            DropColumn("dbo.PacketPrice", "Price_PriceID");
            DropColumn("dbo.PacketPrice", "Weight_WeightID");
            DropTable("dbo.Price");
            DropTable("dbo.Weight");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Weight",
                c => new
                    {
                        WeightID = c.Int(nullable: false, identity: true),
                        Min = c.Single(nullable: false),
                        Max = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.WeightID);
            
            CreateTable(
                "dbo.Price",
                c => new
                    {
                        PriceID = c.Int(nullable: false, identity: true),
                        Currency = c.String(),
                        Amount = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.PriceID);
            
            AddColumn("dbo.PacketPrice", "Weight_WeightID", c => c.Int());
            AddColumn("dbo.PacketPrice", "Price_PriceID", c => c.Int());
            AlterColumn("dbo.Route", "Time", c => c.Int(nullable: false));
            DropColumn("dbo.PacketPrice", "Weight_Max");
            DropColumn("dbo.PacketPrice", "Weight_Min");
            DropColumn("dbo.PacketPrice", "Price_Amount");
            DropColumn("dbo.PacketPrice", "Price_Currency");
            CreateIndex("dbo.PacketPrice", "Weight_WeightID");
            CreateIndex("dbo.PacketPrice", "Price_PriceID");
            AddForeignKey("dbo.PacketPrice", "Weight_WeightID", "dbo.Weight", "WeightID");
            AddForeignKey("dbo.PacketPrice", "Price_PriceID", "dbo.Price", "PriceID");
        }
    }
}
