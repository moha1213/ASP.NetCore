using DataAccessLayer;
using DataAccessLayer.Models;
using System.Data;
using System.Linq.Expressions;

namespace AlfaStoreCoreAPI.IController
{
    public interface ICrudController<T> where T : IModel
    {
        /// <summary>
        /// Insert if it has no id
        /// and update if it has id
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Save(T model);
        /// <summary>
        /// Insert which has no id
        /// and update which has id
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        List<T> Save(List<T> modelList);
        /// <summary>
        /// Delete one record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Delete(T entity);
        /// <summary>
        /// Bulk Delete
        /// </summary>
        /// <param name="modelList"></param>
        /// <returns></returns>
        List<T> Delete(List<T> modelList);
        /// <summary>
        /// Get One
        /// </summary>
        /// <param name="Id">Get one record by id</param>
        /// <returns></returns>
        T Get(string Id);
        /// <summary>
        /// Get All records according to expresion, Note it dostnt work properly to 'In' method, should use in where method.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IQueryable<T> Get(Expression<Func<IQueryable<T>>> expression);

        Branch SaveBranch(Branch model);
        Company SaveCompany(Company model);
    }
}
