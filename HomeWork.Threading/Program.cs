using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork.Threading
{
    class Program
    {
        private static bool isDone = false;

        public delegate int BinaryOp(int x, int y);
        static void Main(string[] args)
        {
            //Console.WriteLine("*****Synch Delegate Review *****");

            // // Вивести ідентифікатор виконуючого потоку
            // Console.WriteLine("Main() invoked on thread {0}.”," +
            //      Thread.CurrentThread.ManagedThreadId);
            // // Викликати Add() у синхронному режимі

            // BinaryOp b = new BinaryOp(Add);

            //     int answer = b(10, 10);
            //     // Ці рядки не виконуються до того моменту, 
            //     // поки не завержиться метод Add
            //     Console.WriteLine("Doing more work m Main()'");
            //     Console.WriteLine("10 + 10 is {0}.", answer);
            //     Console.ReadLine();

            Console.WriteLine("-----Asyn Delegate");

            Console.WriteLine("Main() викликаний потік {0}.",
                Thread.CurrentThread.ManagedThreadId);

            BinaryOp b = new BinaryOp(Add);
            // Після обробки наступного оператора, потік, 
            // який викликається, блокується, поки не буде завершений BeginInvoke
            IAsyncResult ar = b.BeginInvoke(10, 10, null, null);

            // Буде виводити Main, поки не завершиться метод Add
            //while (!ar.IsCompleted)
            //{
            //    Console.WriteLine("Main()!");
            //    Thread.Sleep(1000);
            //}
           
            while (!isDone)
            {
                Console.WriteLine("Working.....");
                Thread.Sleep(1000);
            }
            // знову очікується завершення іншого потоку
            int answer = b.EndInvoke(ar);
            Console.WriteLine("10 + 10 is {0}.", answer);
            Console.ReadLine();



        }
        static int Add(int x, int y)
        {
            Console.WriteLine("Add () Викликаний потік {0}.",
            Thread.CurrentThread.ManagedThreadId);
            // пауза у 5 секунд
            Thread.Sleep(5000);
            return x + y;
        }

        static void AddComplete(IAsyncResult iar)
        {
            Console.WriteLine("AddComplete() викликаний потік {0}.",
                Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Your addiction is comlpete");

            AsyncResult ar = (AsyncResult)iar;
            BinaryOp b = (BinaryOp)ar.AsyncDelegate;
            Console.WriteLine("10 + 10 is {0}.", b.EndInvoke(iar));
            isDone = true;
        }
        }
}
