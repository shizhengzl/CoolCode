namespace Core.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class variables : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GeneratorReplace");
        }
    }
}
