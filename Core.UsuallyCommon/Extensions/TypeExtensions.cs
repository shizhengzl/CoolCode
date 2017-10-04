using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}
