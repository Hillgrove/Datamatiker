using Microsoft.AspNetCore.Mvc;
using PokemonLib;

namespace RestExercise1.Controllers
{
    [Route("api/[controller]")]
    // the controller is available on ..../api/pokemons
    // [controller] means the name of the controller minus "Controller"
    [ApiController]
    public class PokemonsController : ControllerBase
    {
        private readonly PokemonsRepository _repository;

        public PokemonsController(PokemonsRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<PokemonsController>
        [HttpGet]
        public IEnumerable<Pokemon> Get()
        {
            return _repository.GetAll();
        }

        // GET api/<PokemonsController>/5
        [HttpGet("{id}")]
        public Pokemon Get(int id)
        {
            return _repository.GetByID(id);
        }

        // POST api/<PokemonsController>
        [HttpPost]
        public Pokemon Post([FromBody] Pokemon value)
        {
            return _repository.Add(value);
        }

        // PUT api/<PokemonsController>/5
        [HttpPut("{id}")]
        public Pokemon Put(int id, [FromBody] Pokemon value)
        {
            return _repository.Update(id, value);
        }

        // DELETE api/<PokemonsController>/5
        [HttpDelete("{id}")]
        public Pokemon Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}
