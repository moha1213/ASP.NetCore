using DataAccessLayer.Models;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;

namespace AlfaStoreCoreAPI.Files.GraphQlScema.Subscriptions
{
    public class Subscribtion
    {
        [Subscribe]
        public Country CountryCreated([EventMessage] Country country) => country;

        [SubscribeAndResolve]
        public ValueTask<ISourceStream<Country>> CountryUpdated(Guid countryId, [Service] ITopicEventReceiver topicEventReceiver)
        {
            string topicName = $"{countryId}_{nameof(Subscribtion.CountryUpdated)}";
            return topicEventReceiver.SubscribeAsync<Country>(topicName);
        }
    }
}
