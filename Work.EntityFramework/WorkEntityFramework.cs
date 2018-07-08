namespace Work.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Core.Common;
    using System.Data.SQLite;
    using System.Data.SQLite.EF6;
    using System.Linq;
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
    public class WorkEntityFramework : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“WorkEntityFramework”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“Work.EntityFramework.WorkEntityFramework”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“WorkEntityFramework”
        //连接字符串。
        public WorkEntityFramework()
            : base(new SQLiteConnection()
            {
                ConnectionString =  new SQLiteConnectionStringBuilder()
                 { DataSource = "Cache\\Cookies", ForeignKeys = true }
        .ConnectionString
            }, true)
        //    : base("name=WorkEntityFramework")
        {
        }

        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<cookies> cookies { get; set; }
        public virtual DbSet<meta> meta { get; set; }

        public virtual DbSet<Urls> urls { get; set; }

        public virtual DbSet<GameResult> gameresult { get; set; }
    }
}