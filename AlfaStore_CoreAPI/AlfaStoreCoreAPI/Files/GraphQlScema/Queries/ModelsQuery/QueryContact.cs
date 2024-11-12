using DataAccessLayer.Models;
using AlfaStoreCoreAPI.Files.DB;
using Microsoft.EntityFrameworkCore;

namespace AlfaStoreCoreAPI.Files.GraphQlScema.Queries.ModelsQuery
{
    public partial class Query
    {
        public async Task<Contact> GetDistrict([Service] MyAppContext appContext, Guid guid)
        {
            var res = await appContext.contacts.FindAsync(guid, CancellationToken.None);
            return res;
        }

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<List<Contact>> GetDistricts([Service] MyAppContext appContext)
        {
            var res = await appContext.contacts.Include(c => c.Address).ThenInclude(d => (District)d.District).ThenInclude(v=>(City)v.City).ThenInclude(s => (Country)s.Country).ToListAsync();
            return res;
        }
    }
}
