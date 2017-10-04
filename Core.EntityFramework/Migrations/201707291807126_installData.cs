namespace Core.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class installData : DbMigration
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
            
           
        }
        
        public override void Down()
        {
            
        }
    }
}
