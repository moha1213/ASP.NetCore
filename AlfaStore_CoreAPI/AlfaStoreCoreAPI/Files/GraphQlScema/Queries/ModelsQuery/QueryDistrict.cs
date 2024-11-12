using DataAccessLayer.Models;
using AlfaStoreCoreAPI.Files.DB;
using Microsoft.EntityFrameworkCore;

namespace AlfaStoreCoreAPI.Files.GraphQlScema.Queries.ModelsQuery
{
    public partial class Query
    {
        public async Task<District> Getdistrict([Service] MyAppContext appContext, Guid guid)
        {
            var res = await appContext.districts.FindAsync(guid, CancellationToken.None);
            return res;
        }

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<List<District>> Getdistricts([Service] MyAppContext appContext)
        {
            var res = await appContext.districts.Include(c => c.City).ThenInclude(d => d.Country).ToListAsync();
            return res;
        }
    }
}
