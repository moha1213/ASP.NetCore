﻿using DataAccessLayer.Models;
using AlfaStoreCoreAPI.Files.DB;
using Microsoft.EntityFrameworkCore;

namespace AlfaStoreCoreAPI.Files.GraphQlScema.Queries.ModelsQuery
{
    public partial class Query
    {
        public async Task<City> GetCity([Service] MyAppContext appContext, Guid guid)
        {
            var res = await appContext.cities.FindAsync(guid, CancellationToken.None);
            return res;
        }

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<List<City>> GetCities([Service] MyAppContext appContext)
        {
            var res = await appContext.cities.Include(c => c.Country).Include(d => d.Districts).ToListAsync();
            return res;
        }
    }
}
