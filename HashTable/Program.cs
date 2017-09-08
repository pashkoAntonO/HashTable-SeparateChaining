using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable<int, int> hashTable = new HashTable<int, int>(5);

            hashTable.Add(1, 1);
            hashTable.Add(2, 2);
            hashTable.Add(3, 5);
            hashTable.Add(4, 3);
            hashTable.Add(5, 4);
            hashTable.Add(8, 6);
            hashTable.Add(13, 7);

            Console.WriteLine(hashTable.Remove(13));

           // hashTable.Clear();

            hashTable.Show();
            Console.ReadKey();
        }
    }
}
