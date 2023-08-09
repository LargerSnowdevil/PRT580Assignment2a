using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRT580Assignment2a
{
    public static class Extensions
    {
        public static List<int> ToList(this string csv)
        {
            var temp = csv.Split(',').ToList();
            return temp.Select(int.Parse).ToList();
        }

        public static string ToCsv(this List<int> list)
        {
            return string.Join(",", list);
        }
    }
}
