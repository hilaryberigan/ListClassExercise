using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListClassExercise
{
    class Program
    {
        
        public static void Main(string[] args)
        {
            ListClass<string> words = new ListClass<string>();

            for (int i = 0; i < 10; i++)
            {
                words.Add("dog");
                words.Add("bike");
                words.Add("hippo");
                words.Add("table");
                words.Add("sunflower");
                words.Add("bottle");
            }

            foreach (string number in words)
            {
                Console.WriteLine(number);
            }
            words.Sort();
            foreach (string number in words)
            {
                Console.WriteLine(number);
            }
       
            Console.ReadLine();
            words.SortLengthAscending();
            foreach (string number in words)
            {
                Console.WriteLine(number);
            }
            Console.ReadLine();


            words.SortLengthDescending();
            foreach (string number in words)
            {
                Console.WriteLine(number);
            }
            Console.ReadLine();

            ListClass<int> numbers2 = new ListClass<int>();

            for (int i = 2; i < 20; i += 2)
            {
                numbers2.Add(i);
            }

            foreach (int number in numbers2)
            {
                Console.WriteLine(number);
            }
            Console.ReadLine();
            ListClass<int> numbers = new ListClass<int>();

            for (int i = 0; i < 11; i++)
            {
                numbers.Add(i);
            }


            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }

            //ListClass<string> newNumbers = new ListClass<string>();
            //newNumbers = numbers + numbers2;
            //foreach (string number in newNumbers)
            //{
            //    Console.WriteLine(number);
            //}
            //Console.ReadLine();

            //Console.WriteLine(numbers.ToString());
            //Console.WriteLine(numbers);
            //Console.ReadLine();

            ListClass<int> newList = new ListClass<int>();

            newList = numbers - numbers2;

            foreach (int item in newList)
            {
                Console.WriteLine(item);
            }

            //ListClass<int> numbersA = new ListClass<int>();
            //ListClass<int> numbersB = new ListClass<int>();
            //ListClass<int> zippedList = new ListClass<int>();

            //for (int i = 1; i < 16; i++)
            //{
            //    numbersA.Add(1);
            //}
            //for (int i = 1; i < 16; i++)
            //{
            //    numbersB.Add(2);
            //}

            //foreach (int item in numbersA)
            //{
            //    Console.WriteLine(item);
            //}
            //foreach (int item in numbersB)
            //{
            //    Console.WriteLine(item);
            //}
            Console.ReadLine();

            //zippedList = numbersA.Zip(numbersB);

            //foreach (int item in zippedList)
            //{
            //    Console.WriteLine(item);
            //}


            //Console.WriteLine(zippedList.CountList());

            //Console.ReadLine();



        }
    }
}
