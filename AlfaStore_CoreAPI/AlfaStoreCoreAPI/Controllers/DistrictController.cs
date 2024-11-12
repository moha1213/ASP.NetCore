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
    public class DistrictController : ControllerBase
    {
        CrudController<District> _Controller = new CrudController<District>();

        // GET: DistrictController
        [HttpGet("{filters}")]
        public List<District> Index(string filters)
        {

            List<Filter> filterList = JsonSerializer.Deserialize<List<Filter>>(filters);

            District ct = new District();
            var exp =  ct.GetExpression(filterList);

            using (var context = new MyAppContext())
            {//
                return context.districts.Include(a=>a.Addresses).Include(b=>b.City).ThenInclude(c=>c.Country).Where(exp == null ? a => true : exp).ToList();
            }
        }

        [HttpPost]
        public List<District> Create(List<District> District)
        {

            try
            {
                using (var context = new MyAppContext())
                {
                    context.districts.AddRange(District);
                    context.SaveChanges();
                    return District;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        public List<District> Update(List<District> objs)
        {
            try
            {
                using (var context = new MyAppContext())
                {
                    context.districts.UpdateRange(objs);
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
        public List<District> Delete(List<District> objs)
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
