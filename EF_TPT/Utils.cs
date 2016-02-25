using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_TPT
{
    public static class Utils
    {

        public static IEnumerable<T> AsEnumerable<T>(this Type enumType)
        {
            return (IEnumerable<T>)Enum.GetValues(enumType);
        }

        public static T GetRandomElement<T>(this IEnumerable<T> items, Random seed)
        {
            var max = items.Count();
            var skip = seed.Next(max);
            return items.Skip(skip).Take(1).First();
        }

        public static T GetRandomElement<T>(this IEnumerable<T> items)
        {
            return items.GetRandomElement(new Random());
        }

    }
}
