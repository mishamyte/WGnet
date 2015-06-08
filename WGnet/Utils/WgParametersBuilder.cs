using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WGnet.Utils
{
    internal static class WgParametersBuilder
    {
        internal static string ToWgParameter(this List<long> list)
        {
            var builder = new StringBuilder();
            if (list != null)
            {
                foreach (var l in list)
                {
                    if (l.Equals(list.Last())) builder.Append(l);
                    else builder.AppendFormat("{0},", l);
                }

            }
            return builder.ToString();
        }
    }
}
