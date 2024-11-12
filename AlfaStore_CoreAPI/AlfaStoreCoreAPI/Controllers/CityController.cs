using AlfaStoreCoreAPI.Files.DB;
using AlfaStoreCoreAPI.Files.HelperModel;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Text.Json;

namespace AlfaStoreCoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityController : ControllerBase
    {
        CrudController<City> _Controller = new CrudController<City>();

        // GET: CityController
        [HttpGet("{filters}")]
        public List<City> Index(string filters)
        {

            List<Filter> filterList = JsonSerializer.Deserialize<List<Filter>>(filters);

            City ct = new City();
            var exp = ct.GetExpression(filterList);

            using (var context = new MyAppContext())
            {
                return context.cities.Include(c=>c.Districts).Include(a=>a.Country).Where(exp == null ? a => true : exp).ToList();
            }
        }

        [HttpPost]
        public List<City> Create(List<City> City)
        {
            try
            {
                using (var context = new MyAppContext())
                {
                    context.cities.AddRange(City);
                    context.SaveChanges();
                    return City;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        public List<City> Update(List<City> objs)
        {
            try
            {
                using (var context = new MyAppContext())
                {
                    context.cities.UpdateRange(objs);
                    context.SaveChanges();
                    return objs;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete]
        public List<City> Delete(List<City> objs)
        {

            try
            {
                using (var context = new MyAppContext())
                {
                    context.RemoveRange(objs);
                    context.SaveChanges();
                    return objs;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
