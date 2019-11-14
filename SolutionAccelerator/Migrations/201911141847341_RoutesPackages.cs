namespace SolutionAccelerator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoutesPackages : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Packet");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Packet",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
