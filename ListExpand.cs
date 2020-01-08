using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Collections.Generic
{
    public static class ListExpand
    {

        public static void ForEach<T>(this List<T> list, Action<T, int> action)
        {
            var index = 0;
            foreach (var item in list)
            {
                action?.Invoke(item, index++);
            }
        }

    }
}
