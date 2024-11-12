using AlfaStoreCoreAPI.Files.DB;
using AlfaStoreCoreAPI.Files.HelperModel;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace AlfaStoreCoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {
        CrudController<Country> _Controller = new CrudController<Country>();

        // GET: CountryController
        [HttpGet("{filters}")]
        public List<Country> Index(string filters)
        {
            List<Filter> filterList = JsonConvert.DeserializeObject<List<Filter>>(filters);

            Country ct = new Country();
            var exp = ct.GetExpression(filterList);

            using (var context = new MyAppContext())
            {
               return context.Countries.Include(a=>a.Cities).ThenInclude(b=>b.Districts).Where(exp == null ? a => true : exp).ToList();                 
            }
        }

        [HttpPost]
        public List<Country> Create(List<Country> country)
        {
            try
            {
                using (var context = new MyAppContext())
                {
                    context.Countries.AddRange(country);
                    context.SaveChanges();
                    return country;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        public List<Country> Update(List<Country> countries)
        {

            try
            {
                using (var context = new MyAppContext())
                {
                    context.Countries.UpdateRange(countries);
                    context.SaveChanges();
                    return countries;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete]
        public List<Country> Delete(List<Country> countries)
        {
            try
            {
                using (var context = new MyAppContext())
                {
                    context.RemoveRange(countries);
                    context.SaveChanges();
                    return countries;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
