namespace Tradic.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Translations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Words",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TranslationId = c.Int(nullable: false),
                        Text = c.String(),
                        LanguageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: true)
                .ForeignKey("dbo.Translations", t => t.TranslationId, cascadeDelete: true)
                .Index(t => t.TranslationId)
                .Index(t => t.LanguageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Words", "TranslationId", "dbo.Translations");
            DropForeignKey("dbo.Words", "LanguageId", "dbo.Languages");
            DropIndex("dbo.Words", new[] { "LanguageId" });
            DropIndex("dbo.Words", new[] { "TranslationId" });
            DropTable("dbo.Words");
            DropTable("dbo.Translations");
            DropTable("dbo.Languages");
        }
    }
}
