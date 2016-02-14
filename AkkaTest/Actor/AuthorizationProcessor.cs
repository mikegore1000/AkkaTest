using System;
using System.Threading.Tasks;
using Akka.Actor;
using AkkaTest.Messages;

namespace AkkaTest.Actor
{
    public class AuthorizationProcessor : ReceiveActor
    {
        public AuthorizationProcessor()
        {
            var rand = new Random(DateTime.Now.Millisecond);

            Receive<AuthorizePayment>(async p =>
            {
                await Task.Delay(TimeSpan.FromMilliseconds(rand.Next(500, 1000)));
                Console.WriteLine($"Authorized payment {p.PaymentReference}");
            });
        }
    }
}