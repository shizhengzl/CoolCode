namespace Core.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.SQLite.EF6.Migrations;
    using System.Linq;
    using UsuallyCommon;
    internal sealed class Configuration : DbMigrationsConfiguration<Core.EntityFramework.GeneratorContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            //SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());

            AutomaticMigrationDataLossAllowed = false;
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
            if (context.Controls.Count() != 0)
            {
                return;
            }
            if (context.Controls.Count() == 0)
            {
                context.Controls.RemoveRange(context.Controls.ToList());

                context.Controls.Add(new GeneratorClass.Controls() { Name = "bigint" });
                context.Controls.Add(new GeneratorClass.Controls() { Name = "binary" });
                context.Controls.Add(new GeneratorClass.Controls() { Name = "bit" });
                context.Controls.Add(new GeneratorClass.Controls() { Name = "char" });
                context.Controls.Add(new GeneratorClass.Controls() { Name = "date" });
                context.Controls.Add(new GeneratorClass.Controls() { Name = "datetime" });
                context.Controls.Add(new GeneratorClass.Controls() { Name = "datetime2" });
                context.Controls.Add(new GeneratorClass.Controls() { Name = "datetimeoffset" });
                context.Controls.Add(new GeneratorClass.Controls() { Name = "decimal" });
                context.Controls.Add(new GeneratorClass.Controls() { Name = "float" });
                context.Controls.Add(new GeneratorClass.Controls() { Name = "geography" });
                context.Controls.Add(new GeneratorClass.Controls() { Name = "geometry" });
                context.Controls.Add(new GeneratorClass.Controls() { Name = "hierarchyid" });
                context.Controls.Add(new GeneratorClass.Controls() { Name = "image" });
                context.Controls.Add(new GeneratorClass.Controls() { Name = "int" });
                context.Controls.Add(new GeneratorClass.Controls() { Name = "money" });
                context.Controls.Add(new GeneratorClass.Controls() { Name = "nchar" });
                context.Controls.Add(new GeneratorClass.Controls() { Name = "ntext" });
                context.Controls.Add(new GeneratorClass.Controls() { Name = "numeric" });
                context.Controls.Add(new GeneratorClass.Controls() { Name = "nvarchar" });
                context.Controls.Add(new GeneratorClass.Controls() { Name = "real" });
                context.Controls.Add(new GeneratorClass.Controls() { Name = "smalldatetime" });
                context.Controls.Add(new GeneratorClass.Controls() { Name = "smallint" });
                context.Controls.Add(new GeneratorClass.Controls() { Name = "smallmoney" });
                context.Controls.Add(new GeneratorClass.Controls() { Name = "sql_variant" });
                context.Controls.Add(new GeneratorClass.Controls() { Name = "sysname" });
                context.Controls.Add(new GeneratorClass.Controls() { Name = "text" });
                context.Controls.Add(new GeneratorClass.Controls() { Name = "time" });
                context.Controls.Add(new GeneratorClass.Controls() { Name = "timestamp" });
                context.Controls.Add(new GeneratorClass.Controls() { Name = "tinyint" });
                context.Controls.Add(new GeneratorClass.Controls() { Name = "uniqueidentifier" });
                context.Controls.Add(new GeneratorClass.Controls() { Name = "varbinary" });
                context.Controls.Add(new GeneratorClass.Controls() { Name = "varchar" });
                context.Controls.Add(new GeneratorClass.Controls() { Name = "xml" });

            }

            context.GeneratorReplace.RemoveRange(context.GeneratorReplace.ToList());
            context.GeneratorSnippet.RemoveRange(context.GeneratorSnippet.ToList());
            context.GeneratorSQL.RemoveRange(context.GeneratorSQL.ToList());

            Extensions.EnumToList<CSharpDataType>().ForEach(x =>
            context.GeneratorReplace.Add(new GeneratorClass.GeneratorReplace() { ReplaceName = x, ReplaceDeclare = "@" + x, UserDeclare = false, ReplaceType = GeneratorClass.ReplaceType.CsharpType }));

            Extensions.EnumToList<CSharpDataType>().ForEach(x =>
           context.GeneratorReplace.Add(new GeneratorClass.GeneratorReplace() { ReplaceName = "!" + x, ReplaceDeclare = "@!" + x, UserDeclare = false, ReplaceType = GeneratorClass.ReplaceType.CsharpType }));


            context.GeneratorReplace.Add(new GeneratorClass.GeneratorReplace() { ReplaceName = ReplaceVariable.Controls.ToString(), ReplaceDeclare = "@" + ReplaceVariable.Controls.ToString(), UserDeclare = false, ReplaceType = GeneratorClass.ReplaceType.Snippet });
            context.GeneratorReplace.Add(new GeneratorClass.GeneratorReplace() { ReplaceName = ReplaceVariable.NameSpace.ToString(), ReplaceDeclare = "@" + ReplaceVariable.NameSpace.ToString(), UserDeclare = false, ReplaceType = GeneratorClass.ReplaceType.Snippet });
            context.GeneratorReplace.Add(new GeneratorClass.GeneratorReplace() { ReplaceName = ReplaceVariable.DataBaseName.ToString(), ReplaceDeclare = "@" + ReplaceVariable.DataBaseName.ToString(), UserDeclare = false, ReplaceType = GeneratorClass.ReplaceType.Snippet });
            context.GeneratorReplace.Add(new GeneratorClass.GeneratorReplace() { ReplaceName = ReplaceVariable.TableName.ToString(), ReplaceDeclare = "@" + ReplaceVariable.TableName.ToString(), UserDeclare = false, ReplaceType = GeneratorClass.ReplaceType.Snippet });
            context.GeneratorReplace.Add(new GeneratorClass.GeneratorReplace() { ReplaceName = ReplaceVariable.ColumnName.ToString(), ReplaceDeclare = "@" + ReplaceVariable.ColumnName.ToString(), UserDeclare = false, ReplaceType = GeneratorClass.ReplaceType.Snippet });
            context.GeneratorReplace.Add(new GeneratorClass.GeneratorReplace() { ReplaceName = ReplaceVariable.CSharpType.ToString(), ReplaceDeclare = "@" + ReplaceVariable.CSharpType.ToString(), UserDeclare = false, ReplaceType = GeneratorClass.ReplaceType.Snippet });
            context.GeneratorReplace.Add(new GeneratorClass.GeneratorReplace() { ReplaceName = ReplaceVariable.SQLType.ToString(), ReplaceDeclare = "@" + ReplaceVariable.SQLType.ToString(), UserDeclare = false, ReplaceType = GeneratorClass.ReplaceType.Snippet });
            context.GeneratorReplace.Add(new GeneratorClass.GeneratorReplace() { ReplaceName = ReplaceVariable.SQLDBType.ToString(), ReplaceDeclare = "@" + ReplaceVariable.SQLDBType.ToString(), UserDeclare = false, ReplaceType = GeneratorClass.ReplaceType.Snippet });

            context.GeneratorReplace.Add(new GeneratorClass.GeneratorReplace() { ReplaceName = ReplaceVariable.Length.ToString(), ReplaceDeclare = "@" + ReplaceVariable.Length.ToString(), UserDeclare = false, ReplaceType = GeneratorClass.ReplaceType.Snippet });
            context.GeneratorReplace.Add(new GeneratorClass.GeneratorReplace() { ReplaceName = ReplaceVariable.Keys.ToString(), ReplaceDeclare = "@" + ReplaceVariable.Keys.ToString(), UserDeclare = false, ReplaceType = GeneratorClass.ReplaceType.Snippet });
            context.GeneratorReplace.Add(new GeneratorClass.GeneratorReplace() { ReplaceName = ReplaceVariable.Delimiter.ToString(), ReplaceDeclare = "@" + ReplaceVariable.Delimiter.ToString(), UserDeclare = false, ReplaceType = GeneratorClass.ReplaceType.Snippet });
            context.GeneratorReplace.Add(new GeneratorClass.GeneratorReplace() { ReplaceName = ReplaceVariable.Where.ToString(), ReplaceDeclare = "@" + ReplaceVariable.Where.ToString(), UserDeclare = false, ReplaceType = GeneratorClass.ReplaceType.Snippet });

            context.GeneratorReplace.Add(new GeneratorClass.GeneratorReplace() { ReplaceName = ReplaceVariable.ColumnDescription.ToString(), ReplaceDeclare = "@" + ReplaceVariable.ColumnDescription.ToString(), UserDeclare = false, ReplaceType = GeneratorClass.ReplaceType.Snippet });
            context.GeneratorReplace.Add(new GeneratorClass.GeneratorReplace() { ReplaceName = ReplaceVariable.Starts.ToString(), ReplaceDeclare = "<%!", UserDeclare = false, ReplaceType = GeneratorClass.ReplaceType.Brackets });
            context.GeneratorReplace.Add(new GeneratorClass.GeneratorReplace() { ReplaceName = ReplaceVariable.Ends.ToString(), ReplaceDeclare = "!%>", UserDeclare = false, ReplaceType = GeneratorClass.ReplaceType.Brackets });

            context.GeneratorSnippet.Add(new GeneratorClass.GeneratorSnippet() { IsFloder = false, Name = "Example", IsEnabled = true, IsSelectColumn = false, Context = @"using System; 
namespace @NameSpace
{
        public class @TableName
        {
			<%! @String  public const int Max@ColumnNameLength = @Length;
		    !%>

			<%! @!String public @CSharpType @ColumnName { get; set; }
			!%> 

			<%! @String  
			[MaxLength(Max@ColumnNameLength)]
			public @CSharpType @ColumnName { get; set; }
			!%> 
     }
}" });
            context.GeneratorSQL.Add(new GeneratorClass.GeneratorSQL() {Name = SQLString.GetDB.ToStringExtension(), SQLContext= @"  DECLARE @TABLESQL VARCHAR(MAX) = 'SELECT ''@DataBase'' as DataBaseName,Name COLLATE Chinese_PRC_CI_AS as TableName,Type from [@DataBase].sys.objects where TYPE IN (''U'',''V'',''P'')'
DECLARE @RESULT VARCHAR(MAX) = ''

SELECT @RESULT = @RESULT + CASE WHEN @RESULT = '' 
THEN   REPLACE(@TABLESQL,'@DataBase',NAME) + CHAR(13)
ELSE  ' UNION ALL ' +  REPLACE(@TABLESQL,'@DataBase',NAME) + CHAR(13) END
FROM sys.databases
PRINT @RESULT
SELECT Name as DataBaseName FROM   sys.databases
EXEC (@RESULT)" });
            context.GeneratorSQL.Add(new GeneratorClass.GeneratorSQL() { Name = SQLString.Columns.ToStringExtension(), SQLContext = @" use [{0}]
       DECLARE @databaseName VARCHAR(100)= '{0}'
      DECLARE @tableName VARCHAR(100)= '{1}'
      DECLARE @table TABLE
      (
      ID INT IDENTITY(1, 1) ,
      DataBaseName Varchar(200),
      ObjectId INT ,
      TableName VARCHAR(100),
      ColumnName VARCHAR(200) ,
      ColumnDescription NVARCHAR(200) ,
      IsPrimaryKey BIT DEFAULT 0 ,
      IsIdentity BIT ,
      IsNullable BIT ,
      TableIndex INT ,
      SQLType VARCHAR(100) ,
      Length INT ,
      SQLDBType VARCHAR(100) DEFAULT '' ,
      CSharpType VARCHAR(100) DEFAULT '' ,
      IsForeignKey BIT DEFAULT 0 ,
      ForeignKeyTable VARCHAR(100) DEFAULT '',
      Precision tinyint,
      Scale tinyint,
      DefaultValue VARCHAR(1000) DEFAULT '',
      IsSelect BIT DEFAULT 1,
      SearchColumn BIT DEFAULT 1,
      EidtColumn BIT DEFAULT 1,
      ListColumn BIT DEFAULT 1,
      Valid VARCHAR(1000) DEFAULT '',
      Control VARCHAR(1000) DEFAULT ''
      )

      INSERT  INTO @table
      ( 
      DataBaseName,
      ObjectId ,
      TableName,
      ColumnName ,
      ColumnDESCRIPTION ,
      IsIdentity ,
      IsNullable ,
      TableIndex ,
      SQLType ,
      Length,
      Precision,
      Scale
      )
      SELECT @databaseName, cl.object_id ,@tableName,
      cl.name AS ColumnName ,
      ISNULL(CONVERT(VARCHAR(200), ep.value), '') AS Descripiton ,
      cl.is_identity AS IsIdentity ,
      cl.is_nullable AS IsAableNull ,
      cl.column_id AS TableIndex ,
      tp.name AS SQLType ,
      (case when tp.name = 'nvarchar' then cl.max_length/2 else cl.max_length end) AS Length,cl.Precision,cl.scale
      FROM    sys.columns cl
      LEFT JOIN sys.extended_properties ep ON cl.column_id = ep.minor_id
      AND cl.object_id = ep.major_id
      LEFT JOIN sys.types tp ON cl.system_type_id = tp.system_type_id
      AND cl.user_type_id = tp.user_type_id
      WHERE   cl.object_id = OBJECT_ID(@tableName)


      DECLARE @primaryKeyTable TABLE
      (
      ID INT IDENTITY(1, 1) ,
      ObjectId INT ,
      ColumnName VARCHAR(100) ,
      PrimaryKeyName VARCHAR(100)
      )
      INSERT  INTO @primaryKeyTable
      SELECT  cl.object_id AS ObjectId ,
      cl.name AS ColumnName ,
      kc.name AS PrimaryName
      FROM    sys.key_constraints kc
      LEFT JOIN sys.index_columns ic ON kc.parent_object_id = ic.object_id
      LEFT JOIN sys.columns cl ON ic.column_id = cl.column_id
      AND ic.object_id = cl.object_id
      WHERE   kc.type = 'PK'
      AND kc.parent_object_id = OBJECT_ID(@tableName)

      UPDATE  @table
      SET     IsPrimaryKey = 1
      FROM    @table a ,
      @primaryKeyTable b
      WHERE   a.ColumnName = b.ColumnName


      UPDATE  @table
      SET     CSharpType = ( CASE WHEN SQLType = 'bigint' THEN 'Int64'
      WHEN SQLType = 'binary' THEN 'Object'
      WHEN SQLType = 'bit' THEN 'Boolean'
      WHEN SQLType = 'char' THEN 'String'
      WHEN SQLType = 'datetime' THEN 'DateTime'
      WHEN SQLType = 'date' THEN 'DateTime'
      WHEN SQLType = 'decimal' THEN 'Decimal'
      WHEN SQLType = 'float' THEN 'Double'
      WHEN SQLType = 'image' THEN 'Byte'
      WHEN SQLType = 'int' THEN 'Int32'
      WHEN SQLType = 'money' THEN 'Decimal'
      WHEN SQLType = 'nchar' THEN 'String'
      WHEN SQLType = 'ntext' THEN 'String'
      WHEN SQLType = 'numeric' THEN 'Decimal'
      WHEN SQLType = 'nvarchar' THEN 'String'
      WHEN SQLType = 'real' THEN 'Single'
      WHEN SQLType = 'smalldatetime' THEN 'DateTime'
      WHEN SQLType = 'smallint' THEN 'Int16'
      WHEN SQLType = 'smallmoney' THEN 'Decimal'
      WHEN SQLType = 'text' THEN 'String'
      WHEN SQLType = 'timestamp' THEN 'Byte'
      WHEN SQLType = 'tinyint' THEN 'Byte'
      WHEN SQLType = 'uniqueidentifier'
      THEN 'Guid'
      WHEN SQLType = 'varbinary' THEN 'Byte'
      WHEN SQLType = 'varchar' THEN 'String'
      WHEN SQLType = 'xml' THEN 'String'
      WHEN SQLType = 'sql_variant' THEN 'Object'
      END )


      UPDATE  @table
      SET     SQLDBType = ( CASE WHEN SQLType = 'int' THEN 'SqlDbType.Int'
      WHEN SQLType = 'varchar'
      THEN 'SqlDbType.VarChar'
      WHEN SQLType = 'bit' THEN 'SqlDbType.Bit'
      WHEN SQLType = 'datetime'
      THEN 'SqlDbType.DateTime'
      WHEN SQLType = 'date'
      THEN 'SqlDbType.Date'
      WHEN SQLType = 'decimal'
      THEN 'SqlDbType.Decimal'
      WHEN SQLType = 'float' THEN 'SqlDbType.Float'
      WHEN SQLType = 'image' THEN 'SqlDbType.Image'
      WHEN SQLType = 'money' THEN 'SqlDbType.Money'
      WHEN SQLType = 'ntext' THEN 'SqlDbType.NText'
      WHEN SQLType = 'nvarchar'
      THEN 'SqlDbType.NVarChar'
      WHEN SQLType = 'smalldatetime'
      THEN 'SqlDbType.SmallDateTime'
      WHEN SQLType = 'smallint'
      THEN 'SqlDbType.SmallInt'
      WHEN SQLType = 'text' THEN 'SqlDbType.Text'
      WHEN SQLType = 'bigint' THEN 'SqlDbType.BigInt'
      WHEN SQLType = 'binary' THEN 'SqlDbType.Binary'
      WHEN SQLType = 'char' THEN 'SqlDbType.Char'
      WHEN SQLType = 'nchar' THEN 'SqlDbType.NChar'
      WHEN SQLType = 'numeric'
      THEN 'SqlDbType.Decimal'
      WHEN SQLType = 'real' THEN 'SqlDbType.Real'
      WHEN SQLType = 'smallmoney'
      THEN 'SqlDbType.SmallMoney'
      WHEN SQLType = 'sql_variant'
      THEN 'SqlDbType.Variant'
      WHEN SQLType = 'timestamp'
      THEN 'SqlDbType.Timestamp'
      WHEN SQLType = 'tinyint'
      THEN 'SqlDbType.TinyInt'
      WHEN SQLType = 'uniqueidentifier'
      THEN 'SqlDbType.UniqueIdentifier'
      WHEN SQLType = 'varbinary'
      THEN 'SqlDbType.VarBinary'
      WHEN SQLType = 'xml' THEN 'SqlDbType.Xml'
      END )
      -- Ä¬ÈÏÖµ
      UPDATE a SET DefaultValue = b.DefaultValue FROM @table a,(
      SELECT  SO.id AS Object_Id, SO.NAME AS TableName, SC.NAME AS ColumnName, SM.TEXT AS DefaultValue
      FROM sys.sysobjects SO INNER JOIN sys.syscolumns SC ON SO.id = SC.id
      LEFT JOIN sys.syscomments SM ON SC.cdefault = SM.id
      WHERE SO.xtype = 'U'   AND  sm.text IS NOT NULL
      AND so.NAME = @tableName) b WHERE a.objectid = b.Object_Id AND a.ColumnName = b.ColumnName

 
      SELECT  *
      FROM    @table order by TableIndex" });

            context.SaveChanges();
        }
    }
}
