using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_3
{
    public static class ListHelper
    {
        public static List<T> ProcessLists<T>(List<T> list1, List<T> list2)
        {
            List<T> result = new List<T>();

            int n = Math.Max(list1.Count, list2.Count);
            int j = 0;
            for (int i = 0; i < n; i++)
            {
                if (i < list2.Count && list2[i] is int && (int)(object)list2[i] % 2 == 1)
                {
                    result.Add(list2[i]);
                    j++;
                }
                if (j < 2 && i < list1.Count && list1[i] is int && (int)(object)list1[i] % 2 == 0)
                {
                    result.Add(list1[i]);
                    j++;
                }
            }
            return result;
        }
    }
}
