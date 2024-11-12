using DataAccessLayer.Models;
using AlfaStoreCoreAPI.Files.DB;
using Microsoft.EntityFrameworkCore;

namespace AlfaStoreCoreAPI.Files.GraphQlScema.Queries.ModelsQuery
{
    public class QueryUserProfile : ISearch<UserProfile>
    {
        public async Task<UserProfile> GetOne([Service] MyAppContext appContext, Guid guid)
        {
            var res = await appContext.users.FindAsync(guid, CancellationToken.None);
            return res;
        }

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<List<UserProfile>> GetMany([Service] MyAppContext appContext)
        {
            var res = await appContext.users.Include(c => c.ContactDetails).ThenInclude(d => d.Address).ToListAsync();
            return res;
        }
    }
}
