using Antlr.Runtime;
using Magic.Framework.OQL;
using Magic.Framework.OQL.Expressions;
using Magic.Framework.OQL.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UsuallyCommon
{
    public class SQLParser
    {
        public OQLParser parser { get; set; }
        public OQLParser.start_return statements { get; set; }

        public SQLParser(string Sql)
        {
            OQLLexer lex = new OQLLexer(new CaseInsensitiveStringStream(Sql));
            CommonTokenStream tokens = new CommonTokenStream(lex);
            parser = new OQLParser(tokens);
            parser.TreeAdaptor = new TreeFactory();
            statements = parser.start();
        }

        public List<Column> GetColumns()
        {
            List<Column> Columns = new List<Column>();
            List<Magic.Framework.OQL.Expression> column = GetSQLSelect();
            foreach (Expression epx in column)
            {
                Columns.Add((Column)epx);
            }
            return Columns;
        }

        public List<Table> GetTables()
        {
            List<Table> Tables = new List<Table>();
            List<Magic.Framework.OQL.Expression> table = GetSQLTable();
            foreach (Expression epx in table)
            {
                Table tab = (Table)epx;
                if (Tables.Where(x => x.TableName == tab.TableName).Count() > 0)
                    continue;
                Tables.Add(tab);
            }
            return Tables;
        }

        public List<Identifier> GetWheres()
        {
            List<Identifier> Wheres = new List<Identifier>();
            List<Magic.Framework.OQL.Expression> where = GetSQLWhere();
            foreach (Expression epx in where)
            {
                Wheres.Add((Identifier)epx);
            }
            return Wheres;
        }

        private List<Magic.Framework.OQL.Expression> GetSQLWhere()
        {
            List<Magic.Framework.OQL.Expression> list = statements.tree.GetChild(0)._children.ToList();
            List<Magic.Framework.OQL.Expression> listWhere = new List<Magic.Framework.OQL.Expression>();
            var where = list.Where(x => x.Text.ToLower().Trim() == "where").FirstOrDefault();
            GetChildNode(where == null ? null : where._children.ToList(), 87, ref listWhere);
            return listWhere;
        }

        private List<Magic.Framework.OQL.Expression> GetSQLTable()
        {
            List<Magic.Framework.OQL.Expression> list = statements.tree.GetChild(0)._children.ToList();
            List<Magic.Framework.OQL.Expression> listTable = new List<Magic.Framework.OQL.Expression>();
            GetChildNode(list, 113, ref listTable);
            return listTable;
        }

        private List<Magic.Framework.OQL.Expression> GetSQLSelect()
        {
            List<Magic.Framework.OQL.Expression> list = statements.tree.GetChild(0)._children.ToList();
            List<Magic.Framework.OQL.Expression> listSelect = new List<Magic.Framework.OQL.Expression>();
            var select = list.Where(x => x.Text.ToLower().Trim() == "select").FirstOrDefault();
            GetChildNode(select == null ? null : select._children.ToList(), 115, ref listSelect);
            return listSelect;
        }

        private void GetChildNode(List<Magic.Framework.OQL.Expression> list, int result, ref List<Magic.Framework.OQL.Expression> lstr)
        {
            if (list == null)
                return;
            foreach (Magic.Framework.OQL.Expression li in list)
            {
                if (li.Type == result)
                    lstr.Add(li);
                if (li._children != null)
                    GetChildNode(li._children.ToList(), result, ref lstr);
            }
        }

        public List<string> GetMyTables()
        {
            var tables = GetTables();
            List<string> list = new List<string>();

            foreach (var item in tables)
            {
                list.Add(item.TableName);
            }

            return list;
        }

        public void GetMyColumns(List<UsuallyCommon.Database.Column> columns)
        {
            var tables = GetTables();
            List<Magic.Framework.OQL.Expressions.Column> mgiicColumns = GetColumns();
            foreach (Magic.Framework.OQL.Expressions.Column col in mgiicColumns)
            {
                string tableName = col.TableName.ToStringExtension();
                string columnName = col.ColumnName.ToStringExtension();
                string AliasName = col.AliasName.ToStringExtension();

                var first = tables.Where(x => x.TableName.Replace(".dbo","") == tableName || x.AliasName.Replace(".dbo", "") == tableName).FirstOrDefault();

                if (first != null)
                {
                    tableName = first.TableName.Replace(".dbo", ""); 
                }


                SQLColumnStatus status = GetStatus(tableName, columnName);
                foreach (var th in columns)
                {
                    switch (status)
                    {
                        case SQLColumnStatus.TabNullColNull:
                        case SQLColumnStatus.TabColNull:
                            if (!string.IsNullOrEmpty(AliasName))
                                th.ColumnName = AliasName;
                            th.IsSelect = true;
                            break;
                        case SQLColumnStatus.TabNullCol:
                            if(th.ColumnName.ToUpper() == col.ColumnName.ToUpper())
                            { 
                            if (!string.IsNullOrEmpty(AliasName))
                                    th.ColumnName = AliasName;
                                th.IsSelect = true;
                            }
                            break; 
                        
                        case SQLColumnStatus.TabCol:
                            if (th.TableName.ToUpper() == tableName.ToUpper() && th.ColumnName.ToUpper() == col.ColumnName.ToUpper())
                            {
                                if (!string.IsNullOrEmpty(AliasName))
                                    th.ColumnName = AliasName;
                                th.IsSelect = true;
                            }
                            break;
                    }
                }
            }
        }

        public SQLColumnStatus GetStatus(string tableName, string columnName)
        {
            SQLColumnStatus status = SQLColumnStatus.TabCol;
            if (string.IsNullOrEmpty(tableName) && string.IsNullOrEmpty(columnName))
                status = SQLColumnStatus.TabNullColNull;
            if (!string.IsNullOrEmpty(tableName) && string.IsNullOrEmpty(columnName))
                status = SQLColumnStatus.TabColNull;
            if (string.IsNullOrEmpty(tableName) && !string.IsNullOrEmpty(columnName))
                status = SQLColumnStatus.TabNullCol;
            if (!string.IsNullOrEmpty(tableName) && !string.IsNullOrEmpty(columnName))
                status = SQLColumnStatus.TabCol;
            return status;
        }
    }

    public enum SQLColumnStatus
    {
        // 只有*
        TabNullColNull = 0,

        // 只有表.*
        TabColNull = 1,

        // 只有列
        TabNullCol = 2,

        // 有表也有列
        TabCol = 3
    }
}
