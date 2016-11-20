namespace OpendeurdagAppWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Campus",
                c => new
                    {
                        CampusId = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                        Adres = c.String(),
                        Foto = c.String(),
                    })
                .PrimaryKey(t => t.CampusId);
            
            CreateTable(
                "dbo.Gebouws",
                c => new
                    {
                        GebouwId = c.Int(nullable: false, identity: true),
                        Campus_Id = c.Int(nullable: false),
                        Naam = c.String(),
                    })
                .PrimaryKey(t => t.GebouwId)
                .ForeignKey("dbo.Campus", t => t.Campus_Id, cascadeDelete: true)
                .Index(t => t.Campus_Id);
            
            CreateTable(
                "dbo.Richtings",
                c => new
                    {
                        RichtingId = c.Int(nullable: false, identity: true),
                        Omschrijving = c.String(),
                        Campus_Id = c.Int(nullable: false),
                        Naam = c.String(),
                    })
                .PrimaryKey(t => t.RichtingId)
                .ForeignKey("dbo.Campus", t => t.Campus_Id, cascadeDelete: true)
                .Index(t => t.Campus_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Richtings", "Campus_Id", "dbo.Campus");
            DropForeignKey("dbo.Gebouws", "Campus_Id", "dbo.Campus");
            DropIndex("dbo.Richtings", new[] { "Campus_Id" });
            DropIndex("dbo.Gebouws", new[] { "Campus_Id" });
            DropTable("dbo.Richtings");
            DropTable("dbo.Gebouws");
            DropTable("dbo.Campus");
        }
    }
}
