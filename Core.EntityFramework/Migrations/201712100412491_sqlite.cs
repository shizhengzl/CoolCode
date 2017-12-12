namespace Core.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sqlite : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DataBaseSetting",
                c => new
                    {
                        Address = c.String(nullable: false, maxLength: 128),
                        Account = c.String(maxLength: 2147483647),
                        Password = c.String(maxLength: 2147483647),
                        AuthenticationType = c.Int(nullable: false),
                        IsRemeber = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Address);
            
            CreateTable(
                "dbo.GeneratorReplace",
                c => new
                    {
                        ReplaceName = c.String(nullable: false, maxLength: 128),
                        ReplaceDeclare = c.String(maxLength: 2147483647),
                        Operation = c.String(maxLength: 2147483647),
                        UserDeclare = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ReplaceName);
            
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
                        IsAppend = c.Boolean(nullable: false),
                        AppendLocation = c.String(maxLength: 2147483647),
                        Context = c.String(maxLength: 2147483647),
                        FatherId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GeneratorSnippet");
            DropTable("dbo.GeneratorReplace");
            DropTable("dbo.DataBaseSetting");
        }
    }
}
