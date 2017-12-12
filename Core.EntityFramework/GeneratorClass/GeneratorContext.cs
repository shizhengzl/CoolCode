
using Core.EntityFramework.GeneratorClass;
using Core.EntityFramework.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.EntityFramework
{
    public class GeneratorContext : DbContext
    {

        public DbSet<DataBaseSetting> DataBaseSetting { get; set; }

        public DbSet<GeneratorReplace> GeneratorReplace { get; set; }

        public DbSet<GeneratorSnippet> GeneratorSnippet { get; set; }

        public DbSet<Core.UsuallyCommon.Database.Column> Column { get; set; }

        public DbSet<GeneratorSQL> GeneratorSQL { get; set; }

        public GeneratorContext() : base("GeneratorContext")
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
