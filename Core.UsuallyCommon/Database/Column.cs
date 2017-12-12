using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UsuallyCommon.Database
{
    public class Column
    { 
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }

        
        /// <summary>
        /// 列名
        /// </summary> 
        public string ColumnName { get; set; }

        /// <summary>
        /// 列描述
        /// </summary>
        public string ColumnDescription { get; set; }

        /// <summary>
        /// 是否是主键
        /// </summary>
        public bool IsPrimaryKey { get; set; }

        /// <summary>
        /// 是否自增
        /// </summary>
        public bool IsIdentity { get; set; }

        /// <summary>
        /// 是否可空
        /// </summary>
        public bool IsNullable { get; set; }

        /// <summary>
        /// SQL 类型
        /// </summary>
        public string SQLType { get; set; }

        /// <summary>
        /// SQL 长度
        /// </summary>
        public int SQLTypeLength { get; set; }

        /// <summary>
        /// SQL DB 类型
        /// </summary>
        public string SQLDBType { get; set; }

        /// <summary>
        /// CSharp 类型
        /// </summary>
        public string CSharpType { get; set; }

        /// <summary>
        /// 是否有外键
        /// </summary>
        public bool IsForeignKey { get; set; }

        /// <summary>
        /// 外键表名
        /// </summary>
        public string ForeignKeyTable { get; set; }

        /// <summary>
        /// 小数总个数
        /// </summary>
        public byte Precision { get; set; }

        /// <summary>
        /// 小数位数
        /// </summary>
        public byte Scale { get; set; }

        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultValue { get; set; }


        /// <summary>
        /// 自增
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        ///  表对象
        /// </summary>
        public int ObjectId { get; set; }

        /// <summary>
        /// 位置
        /// </summary>
        public int TableIndex { get; set; }

    }
}
