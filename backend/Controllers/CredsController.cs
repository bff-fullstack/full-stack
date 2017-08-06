using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using REST.models;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace REST.Controllers
{
    [Route("api/[controller]")]
    public class CredsController : Controller
    {
        private RESTContext _RESTContext;
        public CredsController(RESTContext dbContext){
            _RESTContext=dbContext;
        }
        // GET api/values
        [Authorize]
        [HttpGet]
        public IEnumerable<Creds> Get()
        {
            return _RESTContext.Creds.ToList();
        }

        // GET api/values/5
        [Authorize]
        [HttpGet("{id}")]
        public Creds Get(int id)
        {
            return _RESTContext.Creds.FirstOrDefault(
                Creds=> Creds.Id==id
            );
        }

        // POST api/values
        [Authorize]
        [HttpPost]
        public void Post([FromBody] Creds entity)
        {
            entity.Key=Helper.OneWayHash(entity.Key);
            _RESTContext.Add(entity);
            _RESTContext.SaveChanges();
        }

        // PUT api/values/5
        [Authorize]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Creds entity)
        {
            entity.Key=Helper.OneWayHash(entity.Key);
            _RESTContext.Update(entity);
            _RESTContext.SaveChanges();
        }

        // DELETE api/values/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

             Creds temp=_RESTContext.Creds.FirstOrDefault(x=>x.Id==id);
             if (temp!= null){
                 _RESTContext.Creds.Remove(temp);
                _RESTContext.SaveChanges();
                return Ok();
             }
            else
                return BadRequest();
        }

        
    }
}
