using System;
using System.Net.Http;
using System.Threading.Tasks;
using consumindoApiEmCsharp.Class;
using Newtonsoft.Json;

namespace ConsumindoApiEmCsharp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("API POKEDEX BUSQUE QUALQUER POKEMON PELO SEU NOME");
            Console.Write("Digite o nome de um pokemon: ");
            string nome = Console.ReadLine().ToLower();
            try
            {

                string apiUrl = $"https://pokeapi.co/api/v2/pokemon/{nome}";

                using (HttpClient httpClient = new HttpClient())
                {

                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                    PokemonData pokemonData = JsonConvert.DeserializeObject<PokemonData>(responseBody);

                    Console.WriteLine($"Nome: {pokemonData.Name}");
                    Console.WriteLine($"Altura: {pokemonData.Height}");
                    Console.WriteLine($"Peso: {pokemonData.Weight}");
                    Console.WriteLine($"Habilidades:");
                    foreach (var ability in pokemonData.Abilities)
                    {
                        Console.WriteLine($"- {ability.Ability.Name}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            }
        }
    }
   
}