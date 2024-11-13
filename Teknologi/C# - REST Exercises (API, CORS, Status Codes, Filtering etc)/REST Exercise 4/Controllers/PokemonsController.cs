using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PokemonLib;


namespace REST_Exercise_4.Controllers
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<IEnumerable<Pokemon>> Get([FromHeader(Name = "amount")] int? amount)
        {
            IEnumerable<Pokemon> allPokemons = _repository.GetAll();
            int totalAmount = allPokemons.Count();

            Response.Headers.Append("Total-Amount", totalAmount.ToString());

            if (!allPokemons.Any())
            {
                return NoContent();
            }

            if (amount.HasValue && amount.Value > 0)
            {
                var selectedPokemons = allPokemons.Take(amount.Value); // .Value as we've already made sure amount is not null, so it won't throw an exception
                return Ok(selectedPokemons);
            }

            return Ok(allPokemons);
        }


        // GET for Pagination: api/pokemons/paginated
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status416RangeNotSatisfiable)] // When startIndex is out of range
        [HttpGet("paginated")]
        public ActionResult<IEnumerable<Pokemon>> GetPaginated(
            [FromHeader(Name = "startIndex")] int? startIndex,
            [FromHeader(Name = "amount")] int? amount)
        {
            if (startIndex == null || startIndex < 0)
            {
                return BadRequest("The 'startIndex' header is missing or invalid. It must be a non-negative integer.");
            }

            if (amount == null || amount <= 0)
            {
                return BadRequest("The 'amount' header is missing or invalid. It must be a positive integer.");
            }

            var allPokemons = _repository.GetAll();
            int totalAmount = allPokemons.Count();

            if (startIndex >= totalAmount)
            {
                return StatusCode(StatusCodes.Status416RequestedRangeNotSatisfiable, "The 'startIndex' is beyond the total amount of items.");
            }

            Response.Headers.Append("Total-Amount", totalAmount.ToString());

            var paginatedPokemons = allPokemons
                .Skip(startIndex.Value)
                .Take(amount.Value);

            return Ok(paginatedPokemons);
        }


        // GET api/<PokemonsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Pokemon> Get(int id)
        {
            Pokemon? pokemon = _repository.GetByID(id);

            if (pokemon == null)
            {
                return NotFound($"No pokemon found with id: {id}");
            }

            return Ok(pokemon);
        }


        // POST api/<PokemonsController>
        [EnableCors("RestrictedPolicy")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public ActionResult<Pokemon> Post([FromBody] Pokemon value)
        {
            var createdPokemon = new Pokemon();

            try
            {
                createdPokemon = _repository.Add(value);
                string? uri = Url.Action(nameof(Get), new { id = createdPokemon.Id });

                if (string.IsNullOrEmpty(uri))
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
                }

                return Created(uri, createdPokemon);
            }

            //if (Name == null) throw new ArgumentNullException();
            catch (ArgumentNullException)
            {
                return BadRequest($"Name cannot be null.");
            }

            //if (Name.Length <= 2) throw new ArgumentOutOfRangeException("specifik besked");
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // PUT api/<PokemonsController>/5
        [EnableCors("RestrictedPolicy")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult<Pokemon> Put(int id, [FromBody] Pokemon value)
        {
            try
            {
                Pokemon? updatedPokemon = _repository.Update(id, value);

                if (updatedPokemon == null)
                {
                    return NotFound($"No pokemon found with id: {id}");
                }

                return Ok(updatedPokemon);
            }

            //if (Name == null) throw new ArgumentNullException();
            catch (ArgumentNullException)
            {
                return BadRequest($"Name cannot be null.");
            }

            //if (Name.Length <= 2) throw new ArgumentOutOfRangeException("specifik besked");
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // DELETE api/<PokemonsController>/5
        [EnableCors("RestrictedPolicy")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<Pokemon> Delete(int id)
        {
            Pokemon? deletedPokemon = _repository.Delete(id);

            if (deletedPokemon == null)
            {
                return NotFound($"No pokemon found with id: {id}");
            }

            return Ok(deletedPokemon);
        }
    }
}
