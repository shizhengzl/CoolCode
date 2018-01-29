namespace Work.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameResults",
                c => new
                    {
                        OrderNumber = c.String(nullable: false, maxLength: 128),
                        InvestTime = c.DateTime(),
                        JuHao = c.String(maxLength: 2147483647),
                        ChangCi = c.String(maxLength: 2147483647),
                        GameType = c.String(maxLength: 2147483647),
                        Result = c.String(maxLength: 2147483647),
                        InvestMoney = c.Decimal(precision: 18, scale: 2),
                        ValidMoney = c.Decimal(precision: 18, scale: 2),
                        WinMoney = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Remark = c.String(maxLength: 2147483647),
                    })
                .PrimaryKey(t => t.OrderNumber);
            
            CreateTable(
                "dbo.Urls",
                c => new
                    {
                        Name = c.Int(nullable: false),
                        Url = c.String(maxLength: 2147483647),
                    })
                .PrimaryKey(t => t.Name);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Urls");
            DropTable("dbo.GameResults");
        }
    }
}
