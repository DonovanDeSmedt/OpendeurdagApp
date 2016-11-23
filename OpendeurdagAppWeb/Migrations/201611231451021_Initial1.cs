namespace OpendeurdagAppWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewsFeedItems",
                c => new
                    {
                        NewsFeedItemId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Inhoud = c.String(),
                        Tag = c.String(),
                        Datum = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.NewsFeedItemId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NewsFeedItems");
        }
    }
}
