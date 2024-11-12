using AlfaStoreCoreAPI.Files.DB;
using AlfaStoreCoreAPI.IController;
using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;

namespace AlfaStoreCoreAPI.Controllers
{
    public class CrudController<T> : ICrudController<T> where T : IModel
    {
        public T Save(T model)
        {
            try
            {
                using (var context = new MyAppContext())
                {

                    if (model.Id == null)
                    {
                        var changed = context.Add(model);
                        context.SaveChanges();
                        return changed.Entity;

                    }
                    else
                    {
                        var changed = context.Update(model);
                        context.SaveChanges();
                        return changed.Entity;
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<T> Save(List<T> modelList)
        {
            try
            {
                using (var context = new MyAppContext())
                {

                    var TobeDeleted = modelList.Where(a => a.IsDeleted).ToList();
                    var TobeAdded = modelList.Where(a => !a.IsDeleted && !a.Id.HasValue).ToList();
                    var TobeUpdated = modelList.Where(a => !a.IsDeleted && a.Id.HasValue).ToList();

                    context.Remove(TobeDeleted);

                    context.AddRange(TobeAdded);

                    context.UpdateRange(TobeUpdated);

                    context.SaveChanges();

                    return context.ChangeTracker.Entries<T>().Select(a => a.Entity).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        public T Delete(T entity)
        {
            try
            {
                using (var context = new MyAppContext())
                {                   
                    var res = context.Remove(entity);
                    context.SaveChanges();
                    return res.Entity;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<T> Delete(List<T> modelList)
        {
            try
            {
                using (var context = new MyAppContext())
                {
                    var res = context.Remove(modelList);
                  
                    context.SaveChanges();
                    return res.Entity;
                }
               
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T Get(string Id)
        {
            try
            {
                using (var context = new MyAppContext())
                {
                    string[] ids = { Id };
                    var res = context.Find<T>(ids);
                    return res;
                }
               
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IQueryable<T> Get(Expression<Func<IQueryable<T>>> expression)
        {
            try
            {
                using (var context = new MyAppContext())
                {
                    var res = context.FromExpression<T>(expression);
                    return res;
                }              
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Branch SaveBranch(Branch model)
        {
            try
            {
                using (var context = new MyAppContext())
                {


                    if (model.Id == null)
                    {
                        var changed = context.Add(model);
                        context.SaveChanges();
                        return changed.Entity;

                    }
                    else
                    {
                        var changed = context.Update(model);
                        context.SaveChanges();
                        return changed.Entity;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Company SaveCompany(Company model)
        {
            try
            {
                using (var context = new MyAppContext())
                {


                    if (model.Id == null)
                    {
                        var changed = context.Add(model);
                        context.SaveChanges();
                        return changed.Entity;

                    }
                    else
                    {
                        var changed = context.Update(model);
                        context.SaveChanges();
                        return changed.Entity;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
