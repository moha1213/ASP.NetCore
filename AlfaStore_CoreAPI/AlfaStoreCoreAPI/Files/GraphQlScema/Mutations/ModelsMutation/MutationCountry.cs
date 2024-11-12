using DataAccessLayer.Models;
using AlfaStoreCoreAPI.Files.DB;
using AlfaStoreCoreAPI.Files.GraphQlScema.Subscriptions;
using HotChocolate.Authorization;
using HotChocolate.Subscriptions;
using System.Security.Claims;
using FirebaseAdminAuthentication.DependencyInjection.Models;
using System.Diagnostics.Metrics;

namespace AlfaStoreCoreAPI.Files.GraphQlScema.Mutations.MutationModels
{
    public class MutationCountry : ISave<Country>
    {
        [Authorize]
        public async Task<Country> Save([Service] MyAppContext context, Country model, ITopicEventSender topicEventSender, ClaimsPrincipal claimsPrincipal)
        {
            try
            {
                string userId = claimsPrincipal.FindFirstValue(FirebaseUserClaimType.ID);
                string userName = claimsPrincipal.FindFirstValue(FirebaseUserClaimType.USERNAME);
                string userEmail = claimsPrincipal.FindFirstValue(FirebaseUserClaimType.EMAIL);
                string userVerified = claimsPrincipal.FindFirstValue(FirebaseUserClaimType.EMAIL_VERIFIED);

                if (model.Id.HasValue)
                {
                    context.Update(model);

                    string createdCourse = $"{model.Id}_{nameof(Subscribtion.CountryUpdated)}";
                    await topicEventSender.SendAsync(createdCourse, model);
                }
                else
                {
                    context.Add(model);
                    string createdCourse = $"{model.Id}_{nameof(Subscribtion.CountryCreated)}";
                    await topicEventSender.SendAsync(createdCourse, model);
                }
                await context.SaveChangesAsync();
                return model;
            }
            catch (GraphQLException ex)
            {
                throw ex;
            }
        }
        [Authorize]
        public async Task<IQueryable<Country>> Save([Service] MyAppContext context, IQueryable<Country> modelList, ITopicEventSender topicEventSender, ClaimsPrincipal claimsPrincipal)
        {
            try
            {
                string userId = claimsPrincipal.FindFirstValue(FirebaseUserClaimType.ID);
                string userName = claimsPrincipal.FindFirstValue(FirebaseUserClaimType.USERNAME);
                string userEmail = claimsPrincipal.FindFirstValue(FirebaseUserClaimType.EMAIL);
                string userVerified = claimsPrincipal.FindFirstValue(FirebaseUserClaimType.EMAIL_VERIFIED);

                var tobeAdd = modelList.Where(a => !a.Id.HasValue);
                var tobeUpdate = modelList.Where(a => a.Id.HasValue);
                var tobeDelete = modelList.Where(a => a.IsDeleted);

                await context.AddRangeAsync(tobeAdd);
                context.UpdateRange(tobeUpdate.ToList());
                context.RemoveRange(tobeDelete);

                await context.SaveChangesAsync();
                return modelList;
            }
            catch (GraphQLException ex)
            {
                throw ex;
            }
        }
    }
}
