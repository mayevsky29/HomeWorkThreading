using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleMultiThreadApp
{
    class Program
    {
        static void PrintTime(object state)
        {
            Console.WriteLine("Time is: {0}",
                DateTime.Now.ToLongTimeString());
        }
        static void Main(string[] args)
        {
            // створити делегат для типу Timer
            TimerCallback timeCB = new TimerCallback(PrintTime);

            // встановити параметри таймера
            Timer t = new Timer(
                timeCB, // обєкт делегата TimerCallback
                null, // інформація для передачі у викликаючий метод
                0, // період очікування перед запуском
                1000 // інтервал між викликами
                );
            Console.WriteLine("Hit key to terminate...");
            Console.ReadLine();


            //Console.WriteLine("*****Synchronizing Threads *****\n");
            //Printer p = new Printer();
            //// Создать 10 потоков, которые указывают на один 
            ////и тот же метод того же самого объекта.
            //Thread[] threads = new Thread[10];
            //for (int i = 0; i < 10; i++)
            //{
            //    threads[i] = new Thread(new ThreadStart(p.PrintNumbers))
            //    {
            //        Name = $"Worker thread #{i}"
            //    };
            //    // Теперь запустить их все. 
            //    foreach (Thread t in threads)
            //        t.Start();
            //    Console.ReadLine();
            //}


        }
    }
}
