using DataAccessLayer.Models;
using AlfaStoreCoreAPI.Files.DB;
using Microsoft.EntityFrameworkCore;

namespace AlfaStoreCoreAPI.Files.GraphQlScema.Queries.ModelsQuery
{
    public partial class Query
    {
        public async Task<UserProfile> Getuser([Service] MyAppContext appContext, Guid guid)
        {
            var res = await appContext.users.FindAsync(guid, CancellationToken.None);
            return res;
        }

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<List<UserProfile>> Getusers([Service] MyAppContext appContext)
        {
            var res = await appContext.users.Include(c => c.ContactDetails).ThenInclude(d => d.Address).ToListAsync();
            return res;
        }
    }
}
