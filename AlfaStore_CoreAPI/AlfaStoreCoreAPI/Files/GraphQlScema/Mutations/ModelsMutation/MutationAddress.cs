﻿using DataAccessLayer.Models;
using AlfaStoreCoreAPI.Files.DB;
using AlfaStoreCoreAPI.Files.GraphQlScema.Subscriptions;
using HotChocolate.Authorization;
using HotChocolate.Subscriptions;
using System.Security.Claims;
using FirebaseAdminAuthentication.DependencyInjection.Models;
using System.Diagnostics.Metrics;

namespace AlfaStoreCoreAPI.Files.GraphQlScema.Mutations.ModelsMutation
{
    public class MutationAddress : ISave<Address>
    {
        [Authorize]
        public async Task<Address> Save([Service] MyAppContext context, Address model, ITopicEventSender topicEventSender, ClaimsPrincipal claimsPrincipal)
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
                }
                else
                {
                    context.Add(model);
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
        public async Task<IQueryable<Address>> Save([Service] MyAppContext context, IQueryable<Address> modelList, ITopicEventSender topicEventSender, ClaimsPrincipal claimsPrincipal)
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
