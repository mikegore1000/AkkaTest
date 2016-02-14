using System;
using Akka.Actor;
using AkkaTest.Actor;
using AkkaTest.Messages;
using static System.Console;

namespace AkkaTest
{
    class Program
    {
        static void Main()
        {
            PaymentAuthDemo();

            ReadLine();
        }

        private static void PaymentAuthDemo()
        {
            var system = ActorSystem.Create("AkkaTestSystem");
            var distributor = system.ActorOf<AuthorizationDistributor>("AuthorizationDistributor-Singleton");

            var workloadSize = GetWorkload();

            for (int i = 0; i < workloadSize; i++)
            {
                distributor.Tell(new AuthorizePayment(Guid.NewGuid(), new Amount(100, Currency.GBP)));
            }

            WriteLine($"Successfully sent {workloadSize} payments for authorization.");
        }

        private static int GetWorkload()
        {
            ForegroundColor = ConsoleColor.Green;
            WriteLine("Created actor system & actors");
            ForegroundColor = ConsoleColor.White;
            Write("Enter the number of payments to authorize: ");
            var workloadSize = int.Parse(ReadLine());
            return workloadSize;
        }
    }
}
