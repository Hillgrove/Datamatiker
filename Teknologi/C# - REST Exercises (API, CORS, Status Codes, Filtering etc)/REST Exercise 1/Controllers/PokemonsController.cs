﻿using Microsoft.AspNetCore.Mvc;
using PokemonLib;


namespace REST_Exercise_1.Controllers
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
        public ActionResult<IEnumerable<Pokemon>> Get()
        {
            IEnumerable<Pokemon> pokemons = _repository.GetAll();

            if (!pokemons.Any())
            {
                return NoContent();
            }

            return Ok(pokemons);
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
                return NotFound("No such class, id: {id}");
            }

            return Ok(pokemon);
        }

        // POST api/<PokemonsController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public ActionResult<Pokemon> Post([FromBody] Pokemon value)
        {
            var createdPokemon = new Pokemon();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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
            catch (ArgumentNullException ex)
            {
                return BadRequest($"Name cannot be null. {ex}");
            }

            //if (Name.Length <= 2) throw new ArgumentOutOfRangeException("specifik besked");
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<PokemonsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult<Pokemon> Put(int id, [FromBody] Pokemon value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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
            catch (ArgumentNullException ex)
            {
                return BadRequest($"Name cannot be null. {ex}");
            }

            //if (Name.Length <= 2) throw new ArgumentOutOfRangeException("specifik besked");
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<PokemonsController>/5
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
