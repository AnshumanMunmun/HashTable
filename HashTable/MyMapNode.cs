using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public class MyMapNode<K, V>
    {
        private int size;//9 (0 -8)
        private LinkedList<KeyValue<K, V>>[] items;//array
        public MyMapNode(int size)
        {
            this.size = size;
            items = new LinkedList<KeyValue<K, V>>[size];
        }
        public int GetArrayPosition(K Key)
        {
            int position = Key.GetHashCode() % size;//22%9->4
            return Math.Abs(position);
        }
        public void Add(K Key, V Value)
        {
            int position = GetArrayPosition(Key);
            LinkedList<KeyValue<K, V>> linkedlist = GetLinkedList(position);
            KeyValue<K, V> item = new KeyValue<K, V>() { key = Key, value = Value };
            linkedlist.AddLast(item);
        }
        public LinkedList<KeyValue<K, V>> GetLinkedList(int Position)
        {
            LinkedList<KeyValue<K, V>> linkedlist = items[Position];
            if (linkedlist == null)
            {
                linkedlist = new LinkedList<KeyValue<K, V>>();
                items[Position] = linkedlist;//4->[22,null]
            }
            return linkedlist;
        }
        public void Display()
        {
            foreach (var linkedlist in items)
            {
                if (linkedlist != null)
                    foreach (KeyValue<K, V> KeyValue in linkedlist)
                    {
                        Console.WriteLine(KeyValue.key + " " + KeyValue.value);
                    }
            }
        }
    }
}
