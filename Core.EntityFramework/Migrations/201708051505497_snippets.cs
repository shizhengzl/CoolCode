namespace Core.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class snippets : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GeneratorSnippet",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 2147483647),
                        IsFloder = c.Boolean(nullable: false),
                        GeneratorFileName = c.String(maxLength: 2147483647),
                        GeneratorPath = c.String(maxLength: 2147483647),
                        IsMergin = c.String(maxLength: 2147483647),
                        IsEnabled = c.String(maxLength: 2147483647),
                        AutoFind = c.Boolean(nullable: false),
                        SnippetLanguageType = c.Boolean(nullable: false),
                        IsAppend = c.Boolean(nullable: false),
                        AppendLocation = c.String(maxLength: 2147483647),
                        SnippetPath = c.String(maxLength: 2147483647),
                        FatherId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GeneratorSnippet");
        }
    }
}
