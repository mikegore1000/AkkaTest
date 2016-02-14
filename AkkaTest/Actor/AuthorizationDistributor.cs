using System.Collections.Generic;
using Akka.Actor;
using Akka.Routing;
using AkkaTest.Messages;

namespace AkkaTest.Actor
{
    public class AuthorizationDistributor : ReceiveActor
    {
        private readonly Dictionary<Currency, IActorRef> actorPool = new Dictionary<Currency, IActorRef>();

        public AuthorizationDistributor()
        {
            CreatePools();

            Receive<AuthorizePayment>(cmd =>
            {
                actorPool[cmd.Amount.Currency].Tell(cmd);
            });
        }

        private void CreatePools()
        {
            var props = Props.Create<AuthorizationProcessor>().WithRouter(new SmallestMailboxPool(20));
            actorPool.Add(Currency.GBP, Context.ActorOf(props, "AuthorizePool-GBP"));
        }
    }
}