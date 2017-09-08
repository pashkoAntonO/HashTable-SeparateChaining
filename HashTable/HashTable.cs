using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Реализация методом цепочек
namespace HashTable
{
    class HashTable<TKey, TValue>
    {

        public int Count { get; private set; } = 0;

        private int size = 0;

        private double maxSize; 

        private LinkedList<HashTableItem<TKey, TValue>>[] array;

        public HashTable(int size, double maxSize = 0.75)
        {
            this.maxSize = maxSize;
            this.size = size;
            array = new LinkedList<HashTableItem<TKey, TValue>>[size];
        }

        private int hash(TKey key)
        {

            return Math.Abs(key.GetHashCode() % size);
        }




        //Добавление в хэш таблицу
        public int Add(TKey key, TValue value)
        {
            if (!CheckSize())
            {
                this.Resize();
            }

            int index = hash(key);

            if (array[index] == null)
            {
                array[index] = new LinkedList<HashTableItem<TKey, TValue>>();
            }

            HashTableItem<TKey, TValue> hashTable = new HashTableItem<TKey, TValue>(key, value);

            LinkedListNode<HashTableItem<TKey, TValue>> nodeHashTable = new LinkedListNode<HashTableItem<TKey, TValue>>(hashTable);

            array[index].AddFirst(nodeHashTable);
            Count++;
            return index;
        }

        //Удаление из хэш таблицы
        public bool Remove(TKey key)
        {
            int index = hash(key);

            if(array[index] == null)
            {
                return false;
            }

            foreach (var item in array[index])
            {
                if (item.Key.Equals(key))
                {
                    array[index].Remove(item);
                    Count--;
                    return true;
                }
            }

            return false;
        }

        //Получение значения
        public TValue GetValue(TKey key)
        {
            int index = hash(key);

            if(array[index] == null)
            {
                return default(TValue);
            }

            foreach (var item in array[index])
            {

                if (item.Key.Equals(key))
                {
                    return item.Value;
                }

            }

            return default(TValue);

        }
        // Очистка
        public void Clear()
        {
            Count = 0;
            array = new LinkedList<HashTableItem<TKey, TValue>>[size];
        }
        // Показать всю таблицу
        public void Show()
        {
            foreach (var item in array)
            {
                if (item != null)
                {
                    foreach (var node in item)
                    {
                        Console.WriteLine("Ключ - {0},  значение - {1}", node.Key, node.Value);
                    }
                }
            }


        }

        private bool CheckSize()
        {
            
            return ((Count/size) <= maxSize) ? true : false; 
        }
        //Увеличение таблицы в 2 раза
        public void Resize()
        {
            if (CheckSize())
            {
                return;
            }
            
            Count = 0;
            size = size * 2;
            LinkedList<HashTableItem<TKey, TValue>>[] oldArray = array;
            array =new LinkedList<HashTableItem<TKey, TValue>>[size];

            foreach (var item in oldArray)
            {
                if(item != null)
                {
                    foreach (var elem in item)
                    {
                        this.Add(elem.Key, elem.Value);
                    }
                }
            }

            Console.WriteLine("big" + array.Length);

        }


    }
}
