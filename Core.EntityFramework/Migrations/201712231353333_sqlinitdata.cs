namespace Core.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sqlinitdata : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Column",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DataBaseName = c.String(maxLength: 2147483647),
                        TableName = c.String(maxLength: 2147483647),
                        ColumnName = c.String(maxLength: 2147483647),
                        ColumnDescription = c.String(maxLength: 2147483647),
                        IsPrimaryKey = c.Boolean(nullable: false),
                        IsIdentity = c.Boolean(nullable: false),
                        IsNullable = c.Boolean(nullable: false),
                        SQLType = c.String(maxLength: 2147483647),
                        SQLTypeLength = c.Int(nullable: false),
                        SQLDBType = c.String(maxLength: 2147483647),
                        CSharpType = c.String(maxLength: 2147483647),
                        IsForeignKey = c.Boolean(nullable: false),
                        ForeignKeyTable = c.String(maxLength: 2147483647),
                        Precision = c.Byte(nullable: false),
                        Scale = c.Byte(nullable: false),
                        DefaultValue = c.String(maxLength: 2147483647),
                        ObjectId = c.Int(nullable: false),
                        TableIndex = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
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
                        ReplaceType = c.Int(nullable: false),
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
                        IsMergin = c.Boolean(nullable: false),
                        IsEnabled = c.Boolean(nullable: false),
                        AutoFind = c.Boolean(nullable: false),
                        IsAppend = c.Boolean(nullable: false),
                        AppendLocation = c.String(maxLength: 2147483647),
                        IsSelectColumn = c.Boolean(nullable: false),
                        Context = c.String(maxLength: 2147483647),
                        ProjectName = c.String(maxLength: 2147483647),
                        FatherId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GeneratorSQL",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        SQLContext = c.String(maxLength: 2147483647),
                        Description = c.String(maxLength: 2147483647),
                    })
                .PrimaryKey(t => t.Name);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GeneratorSQL");
            DropTable("dbo.GeneratorSnippet");
            DropTable("dbo.GeneratorReplace");
            DropTable("dbo.DataBaseSetting");
            DropTable("dbo.Column");
        }
    }
}
