using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace WGnet.Utils
{
    internal static class WgExtenders
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

        internal static string GetEnumDescription(this Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());

            var attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }
    }
}
