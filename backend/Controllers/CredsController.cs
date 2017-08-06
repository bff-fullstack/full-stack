using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using REST.models;
using System.Security.Cryptography;
using System.Text;

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
        [HttpGet]
        public IEnumerable<Creds> Get()
        {
            return _RESTContext.Creds.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Creds Get(int id)
        {
            return _RESTContext.Creds.FirstOrDefault(
                Creds=> Creds.Id==id
            );
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Creds entity)
        {
            entity.Key=OneWayHash(entity.Key);
            _RESTContext.Add(entity);
            _RESTContext.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Creds entity)
        {
            entity.Key=OneWayHash(entity.Key);
            _RESTContext.Update(entity);
            _RESTContext.SaveChanges();
        }

        // DELETE api/values/5
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

        private string OneWayHash(string value){
            SHA512 hasher  = SHA512.Create();
            byte[] hashedBytes;

            hashedBytes= hasher.ComputeHash(Encoding.UTF8.GetBytes(value)) ;
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower(); 
        }
    }
}
