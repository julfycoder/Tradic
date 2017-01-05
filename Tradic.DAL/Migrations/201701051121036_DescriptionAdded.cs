namespace Tradic.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DescriptionAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Descriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WordId = c.Int(nullable: false),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Words", t => t.WordId, cascadeDelete: true)
                .Index(t => t.WordId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Descriptions", "WordId", "dbo.Words");
            DropIndex("dbo.Descriptions", new[] { "WordId" });
            DropTable("dbo.Descriptions");
        }
    }
}
