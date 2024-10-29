
using PokemonLib;
using System.Net.Http.Json;

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
            if (list == null || !list.Any())
            {
                Console.WriteLine("Nothing returned");
            }
            else
            {
                foreach (var pokemon in list)
                {
                    Console.WriteLine(pokemon);
                }
            }
            Console.WriteLine();

            // GET pagination test
            Console.WriteLine("GET PAGINATION TEST:");
            list = await GetPaginatedPokemons("5", "2");
            if (list == null || !list.Any())
            {
                Console.WriteLine("Nothing returned");
            }
            else
            {
                foreach (var pokemon in list)
                {
                    Console.WriteLine(pokemon);
                }
            }
            Console.WriteLine();

            // GET by id test
            Console.WriteLine("GETBYID TEST:");
            int id = 654;
            Pokemon? foundPokemon = await GetById(id);
            Console.WriteLine(foundPokemon == null ? $"No pokemon found with id: {id}" : foundPokemon);
            Console.WriteLine();

            // POST test
            Console.WriteLine("POST TEST:");
            var newPokemon = new Pokemon { Name = "Test", Level = 13 };
            var createdPokemon = await PostPokemon(newPokemon);
            Console.WriteLine(createdPokemon);
            Console.WriteLine();

            // PUT test
            Console.WriteLine("PUT TEST:");
            id = 32;
            var updateData = new Pokemon {Name = "Test", Level = 13, PokeDex = 1313 };
            var updatedPokemon = await PutPokemon(id, updateData);
            Console.WriteLine(updatedPokemon == null ? $"No pokemon found with id: {id}" : updatedPokemon);
            Console.WriteLine();

            // DELETE test
            Console.WriteLine("DELETE TEST:");
            id = 3;
            var deletedPokemon = await DeletePokemon(id);
            Console.WriteLine(deletedPokemon == null ? $"No pokemon found with id: {id}" : deletedPokemon);
            Console.WriteLine();
        }

        public async Task<IEnumerable<Pokemon>?> GetAllPokemons()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(URL);
                IEnumerable<Pokemon>? list = await response.Content.ReadFromJsonAsync<IEnumerable<Pokemon>>();
                return list;
            }
        }

        public async Task<IEnumerable<Pokemon>?> GetPaginatedPokemons(string startIndex, string amount)
        {
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"{URL}/paginated")
                };

                request.Headers.Add("startIndex", startIndex);
                request.Headers.Add("amount", amount);

                HttpResponseMessage response = await client.SendAsync(request);
                IEnumerable<Pokemon>? list = await response.Content.ReadFromJsonAsync<IEnumerable<Pokemon>>();
                return list;
            }
        }

        public async Task<Pokemon?> GetById(int id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{URL}/{id}");
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }

                Pokemon? foundPokemon = await response.Content.ReadFromJsonAsync<Pokemon>();
                return foundPokemon;
            }
        }

        public async Task<Pokemon?> PostPokemon(Pokemon newPokemon)
        {
            JsonContent serializedPokemon = JsonContent.Create(newPokemon);

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsync(URL, serializedPokemon);
                Pokemon? deserializedPokemon = await response.Content.ReadFromJsonAsync<Pokemon>();
                return deserializedPokemon;
            }
        }

        public async Task<Pokemon?> PutPokemon(int id, Pokemon updateData)
        {
            using (var client = new HttpClient())
            {
                var content = JsonContent.Create(updateData);
                HttpResponseMessage response = await client.PutAsync($"{URL}/{id}", content);
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }

                Pokemon? updatedPokemon = await response.Content.ReadFromJsonAsync<Pokemon>();
                return updatedPokemon;
            }
        }

        public async Task<Pokemon?> DeletePokemon(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync($"{URL}/{id}");
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }

                Pokemon? deletedPokemon = await response.Content.ReadFromJsonAsync<Pokemon>();
                return deletedPokemon;
            }
        }
    }
}
