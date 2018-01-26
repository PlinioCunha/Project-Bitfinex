
using Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading;

namespace AppConsoleBitfinex
{
    public class Program
    {

        //private IServiceBitfinex _service;

        static void Main()
        {
            // Create a Timer object that knows to call our TimerCallback
            // method once every 2000 milliseconds.
            Timer t = new Timer(TimerCallbackAsync, null, 0, 2000);


            // Wait for the user to hit <Enter>
            Console.ReadLine();
        }

        private static void TimerCallbackAsync(Object o)
        {


            Console.WriteLine("Registro gravado com sucesso: " + DateTime.Now);



            //Console.WriteLine();

            // Force a garbage collection to occur for this demo.
            //GC.Collect();
        }
    }
}
