using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using REST.models;
namespace REST.Controllers
{
    [Route("api/[controller]")]
    public class XSSController : Controller
    {
        private RESTContext _RESTContext;
        public XSSController(RESTContext dbContext){
            _RESTContext=dbContext;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<Xss> Get()
        {
            return _RESTContext.Xss.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Xss Get(int id)
        {
            return _RESTContext.Xss.FirstOrDefault(
                Xss=> Xss.Id==id
            );
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Xss json)
        {
            _RESTContext.Add(json);
            _RESTContext.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Xss json)
        {
            _RESTContext.Update(json);
            _RESTContext.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

             Xss temp=_RESTContext.Xss.FirstOrDefault(x=>x.Id==id);
             if (temp!= null){
                 _RESTContext.Xss.Remove(temp);
                _RESTContext.SaveChanges();
                return Ok();
             }
            else
                return BadRequest();
        }
    }
}
