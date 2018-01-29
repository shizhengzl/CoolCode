using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.UsuallyCommon
{
    public partial class Extensions
    {
        public static string ToStringExtension(this object obj)
        {
            string result = string.Empty;
            if (obj != null)
                result = obj.ToString();
            return result;
        }


        public static Int32 ToInt32(this object obj)
        {
            Int32 result = 0;
            if (obj == null)
                return result;
            bool isparse = Int32.TryParse(obj.ToStringExtension(),out result);
            return result;
        }
        public static DateTime ToDateTime(this object obj)
        {
            DateTime result = DateTime.MinValue;
            if (obj != null)
                DateTime.TryParse(obj.ToString(), out result);
            return result;
        }
        public static Decimal ToDecimal(this object obj)
        {
            Decimal result = Decimal.MaxValue;
            if (obj != null)
                Decimal.TryParse(obj.ToStringExtension(), out result);
            return result;
        }

        // 获取文件扩展名
        public static string GetFileExtension(this object obj)
        {
            if (obj == null || string.IsNullOrEmpty(obj.ToStringExtension()))
                return string.Empty;
            if (File.Exists(obj.ToStringExtension()))
                return Path.GetExtension(obj.ToStringExtension());
            else
                return obj.ToStringExtension().LastIndexOf(".") > 0 ? obj.ToStringExtension().Substring(obj.ToStringExtension().LastIndexOf('.')) : string.Empty;
        }


        // 获取文件名
        public static string GetFileName(this object obj)
        {
            if (obj == null || string.IsNullOrEmpty(obj.ToStringExtension()))
                return string.Empty;
            if (File.Exists(obj.ToStringExtension()))
                return Path.GetFileNameWithoutExtension(obj.ToStringExtension());
            else
            {
                int index = obj.ToStringExtension().LastIndexOf('/');
                index = index < 0 ? obj.ToStringExtension().LastIndexOf('\\') + 1 : index;
                return (index < 0) ? obj.ToStringExtension().Replace(obj.GetFileExtension(), string.Empty) : obj.ToStringExtension().Substring(index).Replace(obj.GetFileExtension(), string.Empty);
            }
        }

        // 获取文件目录
        public static string GetFileDirectory(this object obj)
        {
            if (obj == null || string.IsNullOrEmpty(obj.ToStringExtension()))
                return string.Empty;
            string result = obj.ToStringExtension().Replace(obj.GetFileName() + obj.GetFileExtension(), string.Empty);
            return (result.Length > 0 ? result.Substring(0, result.Length - 1) : string.Empty);
        }

        // 获取文件的第一个目录
        public static string GetFileFirstDirectory(this object obj)
        {
            string fileDirectory = obj.GetFileDirectory();
            int index = fileDirectory.LastIndexOf('/');
            index = index < 0 ? fileDirectory.LastIndexOf('\\') + 1 : index;
            return index < 0 ? fileDirectory : fileDirectory.Substring(index);
        }


       
    }
}
