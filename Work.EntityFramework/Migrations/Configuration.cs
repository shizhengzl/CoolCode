namespace Work.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.SQLite.EF6.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Work.EntityFramework.WorkEntityFramework>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
            SetSqlGenerator("System.Data.SQLite", new SQLiteMigrationSqlGenerator());
        }

        protected override void Seed(Work.EntityFramework.WorkEntityFramework context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            // BaseAddress/ipl/app/member/game/Game.php?gtype=3001&name=bac/bac.swf&lang=cn&HALLID=3820176&GameType=3001&GameCode=36&HTML5=Y&Client=2&VerID=SessionID

            context.urls.Add(new Urls() {  Name = UrlEnum.BaseAddress, Url = "http://www.vip090.com" });

            context.urls.Add(new Urls() { Name = UrlEnum.BaiJiaLe, Url = "BaseAddress/ipl/app/member/game/Game.php?gtype=3001&name=bac/bac.swf&lang=cn&HALLID=3820176&GameType=3001&GameCode=36&HTML5=Y&Client=2&VerID=SESSION_ID" });

            context.urls.Add(new Urls() { Name = UrlEnum.SeearchResult, Url = "BaseAddress/ipl/portal.php/game/betrecord_search/kind3?BarID=1&GameKind=3&date_start={0}&date_end={1}&GameType=-1&State=-1&Limit={2}&Sort=DESC&sid=SESSION_ID&lang=cn" });

            context.SaveChanges();
        }
    }
}
