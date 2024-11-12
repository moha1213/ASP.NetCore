using AlfaStoreCoreAPI.Files.DB;
using DataAccessLayer;
using DataAccessLayer.Models;
using System.Threading.Tasks;

namespace AlfaStoreCoreAPI.Files.GraphQlScema.Queries
{
    public interface ISearch<T> where T : IModel
    {
       
        Task<T> GetOne([Service] MyAppContext appContext, Guid guid);

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        Task<List<T>> GetMany([Service] MyAppContext appContext);
    }
}
