using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListClassExercise
{
    class ListClass<T> : IEnumerable
    {
        int length;
        T[] innerArray;
        string stringInnerArray;
        bool isItem;
        T listItem1;
        T listItem2;

        public int Count
        {
            get
            {
                return length;
            }
            private set { }
        }
        public ListClass()
        {
            length = 0;
            innerArray = new T[length];
        }

        
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < innerArray.Length; i++)
            {
                yield return innerArray[i];
            }
        }

       
        public void Remove(T listItem)
        {
            T[] newInnerArray = new T[length - 1];
            isItem = false;

            for (int i = 0; i < length - 1; i++)
            {
                CheckItem(listItem, i);
                if (isItem == true)
                {
                    newInnerArray[i] = innerArray[i + 1];
                }
                else
                {
                    newInnerArray[i] = innerArray[i];
                }
            }
            innerArray = newInnerArray;
            length--;
        }

        public void Add(T listItem)
        {
            T[] newInnerArray = new T[length + 1];

            for (int i = 0; i < length; i++)
            {
                newInnerArray[i] = innerArray[i];
            }
            newInnerArray[length] = listItem;

            innerArray = newInnerArray;
            length++;
        }
        public override string ToString()
        {
            foreach (T item in innerArray)
            {
                string stringItem = String.Format("{0}", item);
                Console.Write(stringItem);
            }
            string listAsString = Console.ReadLine();
            return listAsString;
        }

        public ListClass<T> MoveIntoOtherArray()
        {
            ListClass<T> tempList = new ListClass<T>();

            for (int i = 0; i < length; i++)
            {
                tempList.Add(innerArray[i]);
            }
            return tempList;
        }


        public void Sort()
        {
            for (int i = 0; i < length - 1; i++)
            {
                for (int j = 0; j < length - 1; j++)
                {
                    if (Comparer<T>.Default.Compare(innerArray[j], innerArray[j + 1]) > 0)
                    {
                        T temporary = innerArray[j];
                        innerArray[j] = innerArray[j + 1];
                        innerArray[j + 1] = temporary;
                    }
                }
            }
        }
        public int LengthCompare(T ListItem1, T ListItem2)
        {

            string item1 = Convert.ToString(ListItem1);
            string item2 = Convert.ToString(ListItem2);
            int result = item1.Length.CompareTo(item2.Length);
            return result;
        }
        

        public void SortLengthDescending()
        {

            for (int i = 0; i < length - 1; i++)
            {
                for (int j = 0; j < length - 1; j++)
                {
                    if (-LengthCompare(innerArray[j], innerArray[j + 1]) > 0)
                    {
                        T temporary = innerArray[j];
                        innerArray[j] = innerArray[j + 1];
                        innerArray[j + 1] = temporary;
                    }
                }
            }
            for (int i = 0; i < length; i++)
            {
                innerArray[i] = innerArray[i];
            }
        }
        public void SortLengthAscending()
        {

            for (int i = 0; i < length - 1; i++)
            {
                for (int j = 0; j < length - 1; j++)
                {
                    if (LengthCompare(innerArray[j], innerArray[j + 1]) > 0)
                    {
                        T temporary = innerArray[j];
                        innerArray[j] = innerArray[j + 1];
                        innerArray[j + 1] = temporary;
                    }
                }
            }
            for (int i = 0; i < length; i++)
            {
                innerArray[i] = innerArray[i];
            }
        }



        public static ListClass<string> operator +(ListClass<T> list1, ListClass<T> list2)
        {
                string temporaryVariable;

                ListClass<string> addedList= new ListClass<string>();
                ListClass<T> largerList = new ListClass<T>();

                int zipLength = list1.length;
                int difference = 0;

                if (list1.length < list2.length)
                {
                    difference = list2.length - list1.length;
                    largerList = list2;
                }
                else if (list2.length < list1.length)
                {
                    zipLength = list2.length;
                    difference = list1.length - list2.length;
                    largerList = list1;
                }
                for (int i = 0; i < zipLength; i++)
                {
                    temporaryVariable = String.Format("{0} {1}", list1.innerArray[i], list2.innerArray[i]);
                    addedList.Add(temporaryVariable);
            }

            if (list1.length != list2.length)
            {
                for (int i = zipLength; i < zipLength + difference; i++)
                {
                    addedList.Add(String.Format("{0}", largerList.innerArray[i]));
                }
            } 
            return addedList;
        }
        public ListClass<T> Zip(ListClass<T> list2)
        {
            ListClass<T> temporaryZip = new ListClass<T>();
            ListClass<T> largerList = new ListClass<T>();

            int zipLength = this.length;
            int difference = 0;
            largerList = this;
           
                if (this.length < list2.length)
                {
                    zipLength = this.length;
                    difference = list2.length - this.length;
                    largerList = list2;
                }
                else if (list2.length < this.length)
                {
                    zipLength = list2.length;
                    difference = this.length - list2.length;    
                }

            for (int i = 0; i < zipLength; i++)
            {  
                    temporaryZip.Add(this.innerArray[i]);
                    temporaryZip.Add(list2.innerArray[i]);
            }

            if (this.length != list2.length)
            {
                for (int i = zipLength; i < zipLength + difference; i++)
                {
                    temporaryZip.Add(largerList.innerArray[i]);
                }
            }
            return temporaryZip;

        }
        public void CheckItem(T listItem, int i)
        {

            if (innerArray[i].Equals(listItem))
            {
                isItem = true;
            }
        }
        public static ListClass<T> operator -(ListClass<T> list1, ListClass<T> list2)
        {
            foreach (T item in list1)
            {
                for (int i = 0; i < list2.length; i++)
                {
                    if (list2.innerArray[i].Equals(item))
                    {
                        list1.Remove(item);
                    }
                }
            }      
            return list1;
        }

        public int CountList()
        {
            int count = 0;
            for (int i = 0; i < innerArray.Length; i++)
            {
                count++;
            }
            return count;
        }

       
    }
}
