namespace SolutionAccelerator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PacketModel : DbMigration
    {
        public override void Up()
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
        
        public override void Down()
        {
            DropTable("dbo.Packet");
        }
    }
}
