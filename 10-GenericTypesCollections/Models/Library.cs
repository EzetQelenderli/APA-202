using System;
using System.Collections.Generic;
using System.Text;
using static System.Reflection.Metadata.BlobBuilder;

namespace _10_GenericTypesCollections.Models
{
    internal class Library<T>
    {
        private object items;

        public List<T> Items { get; set; }
        public string Name { get; set; }
        public Library(string name)

        {
            Name = name;
            List<T> items = new List<T>();
        }
        public void Add(T item)
        {
            Items.Add(item);
            Console.WriteLine("Elave edildi");
        }
        public void Remove(T item)
        {
            Items.Remove(item);
            Console.WriteLine("Silindi");
        }
        public List<T> GetAll()
        {
            return Items;
        }
        public T FindByIndex(int index)
        {
            if (index >= 0 && index < Items.Count)
            {
                return Items[index];
            }
            throw new IndexOutOfRangeException();
        }
        
        
    }


}