using DataAccessLayer.Models;
using AlfaStoreCoreAPI.Files.DB;
using Microsoft.EntityFrameworkCore;

namespace AlfaStoreCoreAPI.Files.GraphQlScema.Queries.ModelsQuery
{
    public partial class Query
    {
        public virtual async Task<Address> GetAddress([Service] MyAppContext appContext, Guid guid)
        {
            var res = await appContext.addresses.FindAsync(guid, CancellationToken.None);
            return res;
        }

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public virtual async Task<List<Address>> GetAddresses([Service] MyAppContext appContext)
        {
            var res = await appContext.addresses.Include(c => c.District).ThenInclude(d => (City)d.City).ThenInclude(s=>s.Country).ToListAsync();
            return res;
        }
    }
}
