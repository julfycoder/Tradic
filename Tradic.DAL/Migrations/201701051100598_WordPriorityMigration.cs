namespace Tradic.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WordPriorityMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Words", "Priority", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Words", "Priority");
        }
    }
}
