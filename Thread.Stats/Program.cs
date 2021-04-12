using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadStats
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Primary Thread stats *****\n");
            //отримати імя поточного потоку 
            Thread primaryThread = Thread.CurrentThread;
            primaryThread.Name = "ThePrimaryThread";
            
            // деталі домена додатку і контексту
            Console.WriteLine("Name of current AppDomain: {0}",
            Thread.GetDomain().FriendlyName);  // імя домена додатку
            Console.WriteLine("ID of current Context: {0}",
            Thread.CurrentContext.ContextID);  // ідентифікатор поточного контексту
                                               // виведення статистики про даний потік
            Console.WriteLine("Thread Name: {0}",
            primaryThread.Name);  
            Console.WriteLine("Has thread started?: {0}",
            primaryThread.IsAlive);  // чи запущений потік
            Console.WriteLine("Priority Level: {0}",
            primaryThread.Priority);  // пріорітет потоку
            Console.WriteLine("Thread State: {0}",
            primaryThread.ThreadState);  // стан потоку
            Console.ReadLine();

        }
    }
}
