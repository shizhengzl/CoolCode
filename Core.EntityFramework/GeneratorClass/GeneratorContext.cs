
using Core.EntityFramework.GeneratorClass;
using Core.EntityFramework.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;
using System.Data.SQLite.EF6;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.EntityFramework
{
    class DatabaseConfiguration : DbConfiguration
    {
        public DatabaseConfiguration()
        {
            SetProviderFactory("System.Data.SQLite", SQLiteFactory.Instance);
            SetProviderFactory("System.Data.SQLite.EF6", SQLiteProviderFactory.Instance);
            SetProviderServices("System.Data.SQLite", (DbProviderServices)SQLiteProviderFactory.Instance.GetService(typeof(DbProviderServices)));
        }
    }
    [DbConfigurationType(typeof(DatabaseConfiguration))]
    public class GeneratorContext : DbContext
    {

        public DbSet<DataBaseSetting> DataBaseSetting { get; set; }

        public DbSet<GeneratorReplace> GeneratorReplace { get; set; }

        public DbSet<GeneratorSnippet> GeneratorSnippet { get; set; }

        public DbSet<Core.UsuallyCommon.Database.Column> Column { get; set; }

        public DbSet<GeneratorSQL> GeneratorSQL { get; set; }

        public DbSet<Controls> Controls { get; set; }

        public GeneratorContext() :
            base(new SQLiteConnection()
            {
                ConnectionString =
            new SQLiteConnectionStringBuilder()
            { DataSource = "codegenerator.db", ForeignKeys = true }
            .ConnectionString
            }, true)
             //base("GeneratorContext")
        { 
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<GeneratorContext, Configuration>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.AddFromAssembly(typeof(GeneratorContext).Assembly);
        }
    }
}
