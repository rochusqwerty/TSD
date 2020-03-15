using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class OwnGenericCollection<T>
    {
        private List<T> Items = new List<T>();

        public void Add(T item)
        {
            Random r = new Random();
            if (r.Next(100) < 50)
            {
                Items.Add(item);
            }
            else
            {
                Items.Insert(0, item);
            }
        }

        public T Get(int index)
        {
            Random r = new Random();
            int element = r.Next(0, index + 1);
            return Items[element];
        }

        public bool IsEmpty()
        {
            if (Items.Count() == 0) return true;
            return false;
        }
    }
}
