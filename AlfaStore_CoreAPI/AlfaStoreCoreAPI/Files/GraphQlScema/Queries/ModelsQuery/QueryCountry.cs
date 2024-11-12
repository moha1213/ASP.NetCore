using DataAccessLayer.Models;
using AlfaStoreCoreAPI.Files.DB;
using Microsoft.EntityFrameworkCore;

namespace AlfaStoreCoreAPI.Files.GraphQlScema.Queries.ModelsQuery
{
    public class QueryCountry : ISearch<Country>
    {
        public async Task<Country> GetOne([Service] MyAppContext appContext, Guid guid)
        {
            var res = await appContext.Countries.FindAsync(guid, CancellationToken.None);
            return res;
        }

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<List<Country>> GetMany([Service] MyAppContext appContext)
        {
            var res = await appContext.Countries.Include(c => c.Cities).ThenInclude(d => d.Districts).ToListAsync();
            return res;
        }
    }
}
