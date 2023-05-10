using CerealsApi.Db;
using CerealsApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CerealsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CerealsController : ControllerBase
    {
        CerealsDbContext context;

        public CerealsController() : base()
        {
            context = new CerealsDbContext();
        }

        // GET: api/<CerealsController>
        [HttpGet]
        public IEnumerable<Cereal> Get() 
        {
            return context.Cereals.ToList();
        }

        
        // GET api/<CerealsController>/5
        [HttpGet("{id}")]
        public Cereal? Get(int id)
        {
            return context.Cereals.FirstOrDefault(c => c.Id == id);
        }

        // POST api/<CerealsController>
        [HttpPost]
        public void Post([FromBody] Cereal value)
        {
            context.Cereals.Add(value);
            context.SaveChanges();
        }

        // PUT api/<CerealsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Cereal value)
        {
            if (Get(id) is Cereal c && c.Id == id)
            {
                c.UpdateFromModel(value);
                context.Cereals.Update(c);
                context.SaveChanges();
            }
        }

        // DELETE api/<CerealsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (Get(id)!=null)
            {
                context.Cereals.Remove(Get(id));
                context.SaveChanges();
            }
        }
    }
}
