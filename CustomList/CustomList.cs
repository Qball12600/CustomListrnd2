using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    public class CustomList<T> 
    {
        //Member Variables (HAS A)
        public T[] items;
        public int capacity;
        public int count;

        //Constructor
        public CustomList(params T[] initialItems)
        {
            capacity = 4;
            count = 0;
            items = new T[capacity];
            foreach (T item in initialItems)
            {
                Add(item);
            }
        }

       
        public int Capacity
        {
            get { return capacity; }
        }
        public int Count
        {
            get { return count; }
        }

        //Member Methods (CAN DO)
        public void Add(T item)
        {
            //'item' parameter should be added to internal 'items' array
            //if items array is at capacity, double capacity and create new array
            //transfer all items to new array
            if (count == capacity)
            {
                capacity *= 2;
                Array.Resize(ref items, capacity);
            }    
                items[count] = item;
            
           count++;
            //'item' parameter should be added to internal 'items' array
            //if items array is at capacity, double capacity and create new array
            //transfer all items to new array
        }
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                {
                    throw new IndexOutOfRangeException();
                }
                return items[index];
            }
        }
        
        
        
        
        public bool Remove(T item)
        {
            //If 'item' exists in the 'items' array, remove its first instance
            //Any items coming after the removed item should be shifted down so there is no empty index.
            //If 'item' was removed, return true. If no item was removed, return false.
            int index = Array.IndexOf(items, item);

            if (index >= 0)
            {
                for (int i = index; i < count - 1; i++)
                {
                    items[i] = items[i + 1];
                }
                count--;
                return true;
            }
            return false;
           
            
        }

        public override string ToString()
        {
            //returns a single string result = " ";string that contains all items from array
            StringBuilder sb = new StringBuilder();
            if (items != null)
            {
                for (int i = 0; i < count; i++)
                {
                    sb.Append(items[i]?.ToString());
                    if (i < count - 1)
                    {
                        sb.Append(",");
                    }
                }   
            }
            
            return sb.ToString();
        }
        
       
        public static CustomList<T> operator + (CustomList<T> list1, CustomList<T> list2)
        {
            //returns a single CustomList<T> that contains all items from firstList and all items from secondList 
            CustomList<T> combinedList = new CustomList<T>();
 
            foreach (T item in list1.items)
            {
                combinedList.Add(item);
            }
            foreach (T item in list2.items)
            {
                combinedList.Add(item);
            }
            
            return combinedList;
        }

        public static CustomList<T> operator - (CustomList<T> list1, CustomList<T> list2)
        {
            //returns a single CustomList<T> with all items from firstList, EXCEPT any items that also appear in secondList
            CustomList<T> resultList = new CustomList<T>();
            for (int i = 0; i < list1.count; i++)
            {
                resultList.Add(list1.items[i]);
            }
            for (int i = 0; i < list2.count; i++)
            {
                resultList.Remove(list2.items[i]);
            }
            return resultList;
        }


    }
}
