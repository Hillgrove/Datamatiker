
using PokemonLib;
using System.Net.Http.Json;
using System.Text.Json;

namespace REST_Exercise_7
{
    public class Worker
    {
        private const string URL = "https://hill-pokemonapi.azurewebsites.net/api/pokemons";
        public async Task DoWork()
        {
            // GET test
            Console.WriteLine("GET TEST:");
            var list = await GetAllPokemons();
            foreach (var pokemon in list)
            {
                Console.WriteLine(pokemon);
            }
            Console.WriteLine();

            // POST test
            Console.WriteLine("POST TEST:");
            var newPokemon = new Pokemon { Name = "Test", Level = 13 };
            var createdPokemon = await PostPokemon(newPokemon);
            Console.WriteLine(createdPokemon);
        }

        public async Task<IEnumerable<Pokemon>> GetAllPokemons()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(URL);
                IEnumerable<Pokemon> list = await response.Content.ReadFromJsonAsync<IEnumerable<Pokemon>>();
                return list;
            }
        }

        public async Task<Pokemon> PostPokemon(Pokemon newPokemon)
        {
            JsonContent serializedPokemon = JsonContent.Create(newPokemon);

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsync(URL, serializedPokemon);
                Pokemon deserializedPokemon = await response.Content.ReadFromJsonAsync<Pokemon>();
                return deserializedPokemon;
            }
        }
    }
}
