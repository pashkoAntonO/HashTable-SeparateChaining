using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class HashTableItem<TKey, TValue>
    {

        public TKey Key { get; set; }
        public TValue Value { get; set; }

        public HashTableItem(TKey key, TValue value)
        {
            Key = key; 
            Value = value;
        }


    }
}
