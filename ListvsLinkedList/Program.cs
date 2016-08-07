using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Diagnostics;

namespace ListvsLinkedList
{
    //A delegate to pass methods of type void with no parameters to other functions
    public delegate void funcTimeDelegate();

    class Number
    {        
        public int nr { get; set; }

        public Number(int nr)
        {
            this.nr = nr;
        }
    }    

    class Program
    {
        static void RunLinked()
        {
            //Create a LinkedList with 1M class entries
            LinkedList<Number> numberLinkedList = new LinkedList<Number>();
            for (int i = 0; i < 8000; i++)
            {
                numberLinkedList.AddLast(new Number(i));
            }
            foreach(var numero in numberLinkedList)
            {
                Console.Write(numero.nr + " ");
            }            
        }
        static void RunList()
        {
            List<Number> numberList = new List<Number>();
            for (int i = 0; i < 8000; i++)
            {
                numberList.Add(new Number(i));
            }
            foreach(var numero in numberList)
            {
                Console.Write(numero.nr + " ");
            }            
        }
        static void Main(string[] args)
        {
            //This Program will test the speed of List vs LinkedList
            funcTimeDelegate f1 = RunList;
            timeFunc(f1);
            f1 = RunList;
            timeFunc(f1);
            Console.ReadLine();
        }
        static void timeFunc(funcTimeDelegate f)
        {
            Console.WriteLine("Start Timer: ");
            Stopwatch timer = new Stopwatch();
            timer.Start();
            f();
            timer.Stop();
            Console.WriteLine("\nThe function finished after: {0} ms.\n", timer.ElapsedMilliseconds);
            timer.Reset();
        }
        ///NOTES
        ///LINKED LISTS ARE FASTER FOR SEQUENTIAL PROCESSING 
        ///LINKED LISTS ARE FASTER FOR INTERNAL ADDING OR REMOVING OF ELEMENTS
        ///
    }
}
