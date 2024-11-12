using DataAccessLayer.Models;
using AlfaStoreCoreAPI.Files.DB;
using Microsoft.EntityFrameworkCore;

namespace AlfaStoreCoreAPI.Files.GraphQlScema.Queries.ModelsQuery
{
    public class QueryAddress : ISearch<Address>
    {
        public async Task<Address> GetOne([Service] MyAppContext appContext, Guid guid)
        {
            var res = await appContext.addresses.FindAsync(guid, CancellationToken.None);
            return res;
        }

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<List<Address>> GetMany([Service] MyAppContext appContext)
        {
            var res = await appContext.addresses.Include(c => c.District).ThenInclude(d => (City)d.City).ThenInclude(s=>s.Country).ToListAsync();
            return res;
        }
    }
}
