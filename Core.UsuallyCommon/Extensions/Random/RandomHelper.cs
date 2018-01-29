using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UsuallyCommon
{
    public class RandomHelper
    {
        public static bool RandomBool()
        {
            bool result = false;
            result = RamdoInt32() % 2 == 0;
            return result;
        }

        public static Int32 RamdoInt32(Int32 max = 9)
        {
            Random rd = new Random(Guid.NewGuid().GetHashCode());
            return rd.Next(0, max);
        }

        public static string RamdomString(Int32 length, Int32 max = 9)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                sb.AppendFormat("{0}", RamdoInt32(max));
            }
            return sb.ToStringExtension();
        }

        public static string ORamdomStringBool(Int32 length)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                sb.AppendFormat("{0}", (RandomBool() ? "1" : "0"));
            }
            return sb.ToStringExtension();
        }
    }
}
