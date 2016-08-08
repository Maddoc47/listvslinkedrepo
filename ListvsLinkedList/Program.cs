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
            timeFunc(RunLinked);                   //Run the timer method with the delegate object as a parameter           
            timeFunc(RunList);                     //Run the timer method with the delegate object as a parameter

            timeFunc<int>(RunList);                 //This compiles, BUT: can't access the int range parameter in the timeFunc<T> method below
            Console.ReadLine();                      
        }

        static void timeFunc(Action<int> funcToTime)
        {
            //Uses the built-in Action delegate that that takes 1 parameter and has void return
            Console.WriteLine("Start Timer: ");
            Stopwatch timer = new Stopwatch();
            timer.Start();
            funcToTime(8000);
            timer.Stop();
            Console.WriteLine("\nThe function finished after: {0} ms.\n", timer.ElapsedMilliseconds);
            timer.Reset();
        }

        static void timeFunc(dlgFuncTimeGeneric<double> funcToTime)
        {
            //Uses the custom delegate
            Console.WriteLine("Start Timer: ");
            Stopwatch timer = new Stopwatch();
            timer.Start();
            funcToTime(8000);
            timer.Stop();
            Console.WriteLine("\nThe function finished after: {0} ms.\n", timer.ElapsedMilliseconds);
        }

        static void timeFunc<T>(dlgFuncTimeGeneric<T> funcToTime)
        {
            //Uses the custom delegate
            Console.WriteLine("Start Timer: ");
            Stopwatch timer = new Stopwatch();
            timer.Start();            
            funcToTime(8000);                               //CAN'T ACCESS THE INT RANGE FROM THE METHOD STORED IN funcToTime
            timer.Stop();
            Console.WriteLine("\nThe function finished after: {0} ms.\n", timer.ElapsedMilliseconds);
        }




        static void RunLinked(int range)
        {
            //Create a LinkedList with 1M class entries
            LinkedList<Number> numberLinkedList = new LinkedList<Number>();
            for (int i = 0; i < range; i++)
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
