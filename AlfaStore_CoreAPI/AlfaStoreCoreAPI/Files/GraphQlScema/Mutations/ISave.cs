using AlfaStoreCoreAPI.Files.DB;
using DataAccessLayer;
using DataAccessLayer.Models;
using HotChocolate.Subscriptions;
using System.Security.Claims;
using HotChocolate.Authorization;

namespace AlfaStoreCoreAPI.Files.GraphQlScema.Mutations
{
    public interface ISave<T> where T : IModel
    {
        [Authorize]
        Task<T> Save([Service] MyAppContext context, T model, ITopicEventSender topicEventSender, ClaimsPrincipal claimsPrincipal);

        [Authorize]
        Task<IQueryable<T>> Save([Service] MyAppContext context, IQueryable<T> modelList, ITopicEventSender topicEventSender, ClaimsPrincipal claimsPrincipal);
    }
}
