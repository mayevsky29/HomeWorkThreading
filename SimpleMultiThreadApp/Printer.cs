using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleMultiThreadApp
{
   public class Printer
    {
        public void PrintNumbers()
        { 
            for(int i = 0; i< 10; i++)
                {
                    // Приостановить поток на случайный период времени.
                    Random r = new Random();
                    Thread.Sleep(1000 * r.Next(5));
                    Console.Write("{0}, ", i);
                }
                Console.WriteLine();
        }
    }
}
