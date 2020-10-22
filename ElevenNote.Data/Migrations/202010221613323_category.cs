namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class category : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Note", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Note", "CategoryId");
            AddForeignKey("dbo.Note", "CategoryId", "dbo.Category", "CategoryId", cascadeDelete: true);
            DropColumn("dbo.Category", "CreatedUtc");
            DropColumn("dbo.Category", "ModifiedUtc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Category", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.Category", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropForeignKey("dbo.Note", "CategoryId", "dbo.Category");
            DropIndex("dbo.Note", new[] { "CategoryId" });
            DropColumn("dbo.Note", "CategoryId");
        }
    }
}
