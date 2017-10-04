using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UsuallyCommon
{
    #region 枚举 扩展 
    /// <summary>
    /// 枚举 扩展
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// 把集合转成DataTable
        /// </summary>
        public static DataTable EnumToDataTable<T>(this IEnumerable<T> enumerable)
        {
            var dataTable = new DataTable();
            foreach (PropertyDescriptor pd in TypeDescriptor.GetProperties(typeof(T)))
            {
                dataTable.Columns.Add(pd.Name, pd.PropertyType);
            }
            foreach (T item in enumerable)
            {
                var Row = dataTable.NewRow();

                foreach (PropertyDescriptor dp in TypeDescriptor.GetProperties(typeof(T)))
                {
                    Row[dp.Name] = dp.GetValue(item);
                }
                dataTable.Rows.Add(Row);
            }
            return dataTable;
        }

        /// <summary>
        /// 枚举转字典
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static Dictionary<string, string> EnumToDictionary(this Type enumType)
        {
            Dictionary<string, string> list = new Dictionary<string, string>();
            foreach (int i in Enum.GetValues(enumType))
            {
                list.Add(i.ToString(), Enum.GetName(enumType, i));
            }
            return list;
        }

        /// <summary>
        /// 获取枚举描述
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum value)
        {
            System.Reflection.FieldInfo field = value.GetType().GetField(value.ToString());

            System.ComponentModel.DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(System.ComponentModel.DescriptionAttribute)) as System.ComponentModel.DescriptionAttribute;

            return attribute == null ? value.ToString() : attribute.Description;
        }

        public static T EnumParse<T>(string value) where T : struct
        {
            return EnumParse<T>(value, false);
        }

        public static T EnumParse<T>(string value, bool ignoreCase) where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enum type.");
            }

            var result = (T)Enum.Parse(typeof(T), value, ignoreCase);
            return result;
        }

        public static T ToEnum<T>(this string value) where T : struct
        {
            return EnumParse<T>(value);
        }

        public static T ToEnum<T>(this string value, bool ignoreCase) where T : struct
        {
            return EnumParse<T>(value, ignoreCase);
        }
    }
    #endregion

}
