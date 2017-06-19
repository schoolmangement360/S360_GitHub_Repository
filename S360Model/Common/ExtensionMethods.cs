using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S360Model
{
    public static class ExtensionMethods
    {
        public static System.Collections.ObjectModel.ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> source)
        {
            if (source == null)
                throw new ArgumentNullException("Source is Null", new Exception());
            return new System.Collections.ObjectModel.ObservableCollection<T>(source);
        }
    }
}
