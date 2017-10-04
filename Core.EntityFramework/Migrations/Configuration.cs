namespace Core.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.SQLite.EF6.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Core.EntityFramework.GeneratorContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
            SetSqlGenerator("System.Data.SQLite", new SQLiteMigrationSqlGenerator());
        }

        protected override void Seed(GeneratorContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.GeneratorReplace.RemoveRange(context.GeneratorReplace.ToList());
            context.GeneratorSnippet.RemoveRange(context.GeneratorSnippet.ToList());

            context.GeneratorReplace.Add(new GeneratorClass.GeneratorReplace() { ReplaceName = "DataBaseName" , ReplaceDeclare = "@DataBaseName" , UserDeclare = false });
            context.GeneratorReplace.Add(new GeneratorClass.GeneratorReplace() { ReplaceName = "DataTableName", ReplaceDeclare = "@DataTableName", UserDeclare = false });
            context.GeneratorReplace.Add(new GeneratorClass.GeneratorReplace() { ReplaceName = "ColumnName", ReplaceDeclare = "@ColumnName", UserDeclare = false });
            context.GeneratorReplace.Add(new GeneratorClass.GeneratorReplace() { ReplaceName = "ColumnType", ReplaceDeclare = "@ColumnType", UserDeclare = false });
            context.GeneratorReplace.Add(new GeneratorClass.GeneratorReplace() { ReplaceName = "SQLType", ReplaceDeclare = "@SQLType", UserDeclare = false });
            context.GeneratorReplace.Add(new GeneratorClass.GeneratorReplace() { ReplaceName = "DBType", ReplaceDeclare = "@DBType", UserDeclare = false });
            context.GeneratorReplace.Add(new GeneratorClass.GeneratorReplace() { ReplaceName = "ColumnDescription", ReplaceDeclare = "@ColumnDescription", UserDeclare = false });

            context.GeneratorSnippet.Add(new GeneratorClass.GeneratorSnippet() {  IsFloder = false,Name ="Ä£°æ"});

            context.SaveChanges();
        }
    }
}
