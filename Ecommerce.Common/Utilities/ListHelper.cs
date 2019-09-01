using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Common.Utilities
{
    public class ListHelper
    {
        public static List<T> GetRandom<T>(List<T> collection, int randomItems)
        {
            List<T> copy = new List<T>(collection);
            List<T> outputs = new List<T>();
            Random r = new Random();
            int count = 0;
            while (count < collection.Count && count < randomItems)
            {
                int i = r.Next(1, copy.Count) - 1;
                outputs.Add(copy[i]);
                copy.RemoveAt(i);
                count++;                
            }
            return outputs;
        }
    }
}
