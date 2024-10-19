
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http; // remove after to see what uses this

using Microsoft.AspNetCore.Mvc;
using PokemonLib;

namespace RestExercise2.Controllers
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public ActionResult<IEnumerable<Pokemon>> Get()
        {
            List<Pokemon> pokemons = _repository.GetAll();
            return Ok(pokemons);
        }

        // GET api/<PokemonsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Pokemon> Get(int id)
        {
            Pokemon? foundPokemon = _repository.GetByID(id);
            if (foundPokemon == null)
            {
                return NotFound($"Pokemon with ID {id} not found.");
            }

            return Ok(foundPokemon);
        }

        // POST api/<PokemonsController>
        [DisableCors]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public ActionResult<Pokemon> Post([FromBody] Pokemon newPokemon)
        {
            try
            {
                var createdPokemon = _repository.Add(newPokemon);
                //return Created($"/{pokemon.Id}", pokemon); // Hardcoded path - needs to be changed if API logic changes
                return CreatedAtAction(nameof(Get), new { id = createdPokemon.Id, createdPokemon }); // dynamic path - updates automatically
            }

            catch (ArgumentNullException ex)
            {
                return BadRequest($"Cannot create pokemon. {ex.Message}");
            }

            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest($"Cannot create pokemon. {ex.Message}");
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

        // PUT api/<PokemonsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("{id}")]
        public ActionResult<Pokemon> Put(int id, [FromBody] Pokemon updatedPokemon)
        {
            try
            {
                var pokemon = _repository.Update(id, updatedPokemon);
                if (pokemon == null)
                {
                    return NotFound($"Pokemon with ID {id} not found.");
                }

                return Ok(pokemon);
            }

            catch (ArgumentNullException ex)
            {
                return BadRequest($"Cannot create pokemon. {ex.Message}");
            }

            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest($"Cannot create pokemon. {ex.Message}");
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

        // DELETE api/<PokemonsController>/5
        [DisableCors]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<Pokemon> Delete(int id)
        {
            var deletedPokemon = _repository.Delete(id);            
            if (deletedPokemon == null)
            {
                return NotFound($"Pokemon with ID {id} not found.");
            }

            return Ok(deletedPokemon);
        }
    }
}
