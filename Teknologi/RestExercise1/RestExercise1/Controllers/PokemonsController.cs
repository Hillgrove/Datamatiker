using Microsoft.AspNetCore.Mvc;

namespace RestExercise1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonsController : ControllerBase
    {
        // GET: api/<PokemonsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PokemonsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PokemonsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PokemonsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PokemonsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
