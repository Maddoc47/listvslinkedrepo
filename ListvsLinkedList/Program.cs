using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Diagnostics;

namespace ListvsLinkedList
{
    //Create a custom delegate type to hold methods of type void with 1 parameter   
    public delegate void dlgFuncTimeNoPara();
    public delegate void dlgFuncTimeGeneric<T>(T x);
    

    class Program
    {
        static void Main(string[] args)
        {                                                     
            timeFunc(RunLinked);                 
            timeFunc(RunList);
            
            //timeFunc<int>(RunList);                 

            Console.ReadLine();                      
        }

        
        //Times void functions with 0 parameters
        static void timeFunc(Action funcToTime)
        {
            //Uses the custom delegate
            Console.WriteLine("Start Timer: ");
            Stopwatch timer = new Stopwatch();
            timer.Start();
            funcToTime();                               //CAN'T ACCESS THE INT RANGE FROM THE METHOD STORED IN funcToTime
            timer.Stop();
            Console.WriteLine("\nThe function finished after: {0} ms.\n", timer.ElapsedMilliseconds);
        }

        //Times void functions with 1 int parameter (Overload repeat for other types)
        static void timeFunc(Action<int> funcToTime)
        {                        
            //Uses the custom delegate
            Console.WriteLine("Start Timer: ");
            Stopwatch timer = new Stopwatch();
            timer.Start();
            funcToTime(2000);                               //CAN'T ACCESS THE INT RANGE FROM THE METHOD STORED IN funcToTime
            timer.Stop();
            Console.WriteLine("\nThe function finished after: {0} ms.\n", timer.ElapsedMilliseconds);
        }

        /*
        //Times void functions with 1 parameter
        static void timeFunc<T>(Action<T> funcToTime)
        {
            //Uses the custom delegate
            Console.WriteLine("Start Timer: ");
            Stopwatch timer = new Stopwatch();
            timer.Start();
            funcToTime(2000);                               //CAN'T ACCESS THE INT RANGE FROM THE METHOD STORED IN funcToTime
            timer.Stop();
            Console.WriteLine("\nThe function finished after: {0} ms.\n", timer.ElapsedMilliseconds);
        }
        */
        
        static void RunLinked()
        {
            //Create a LinkedList with 1M class entries
            LinkedList<Number> numberLinkedList = new LinkedList<Number>();
            for (int i = 0; i < 5000; i++)
            {
                numberLinkedList.AddLast(new Number(i));
            }
            foreach (var numero in numberLinkedList)
            {
                Console.Write(numero.Nr + " ");
            }
        }
        static void RunList(int range)
        {
            List<Number> numberList = new List<Number>();
            for (int i = 0; i < range; i++)
            {
                numberList.Add(new Number(i));
            }
            foreach (var numero in numberList)
            {
                Console.Write(numero.Nr + " ");
            }
        }
        ///NOTES
        ///LINKED LISTS ARE FASTER FOR SEQUENTIAL PROCESSING 
        ///LINKED LISTS ARE FASTER FOR INTERNAL ADDING OR REMOVING OF ELEMENTS
        ///
    }

    class Number
    {
        public int Nr { get; set; }

        public Number(int nr)
        {
            this.Nr = nr;
        }
    }
}
