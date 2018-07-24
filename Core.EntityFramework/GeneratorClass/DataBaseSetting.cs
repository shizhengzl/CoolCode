using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.EntityFramework
{
    public class DataBaseSetting
    {
        [Key]
        public string Address { get; set; }

        public string Account { get; set; }

        public string Password { get; set; }

        public AuthenticationType AuthenticationType { get; set; }

        public bool IsRemeber { get; set; }

        public DateTime LastModifyTime { get; set; }

        public string DataBase { get; set; }

    } 

    public enum AuthenticationType
    {
        AccountPassword = 0 ,
        Windows = 1
    }


    public enum ReplaceVariable
    {
        NameSpace = 0,
        DataBaseName  = 1,
        TableName = 2,
        ColumnName = 3,
        CSharpType = 4,
        SQLType = 5,
        SQLDBType = 6,
        ColumnDescription = 7,
        Starts = 8,
        Ends = 9,
        Length=10,
        Keys = 11,
        Delimiter = 12,
        Where = 13
    }

    public enum CSharpDataType
    {
        String,
        Sbyte,
        Short,
        Int,
        Long,
        Byte,
        Ushort,
        Uint,
        Ulong,
        Float,
        Double,
        Bool,
        Char,
        Decimal,
        Object
    }
}
