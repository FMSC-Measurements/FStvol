using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FStvol.Util
{
    public static class EnumerableExtentions
    {
        public static IEnumerable<T> OrEmpty<T>(this IEnumerable<T> @this)
        {
            return @this ?? Enumerable.Empty<T>();
        }

        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> @this)
        {
            if(@this == null) { throw new ArgumentNullException(); }

            return new ObservableCollection<T>(@this);
        }
    }
}
