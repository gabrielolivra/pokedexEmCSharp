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
            bool continuarBusca = true;

           Console.WriteLine("API POKEDEX BUSQUE QUALQUER POKEMON PELO SEU NOME");
            while (continuarBusca)
            {
                Console.Write("Digite o nome de um pokemon: ");
                string nome = Console.ReadLine().ToLower().Trim();
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

                    Console.Write("Deseja buscar outro Pokémon? (S/N): ");
                    string resposta = Console.ReadLine().Trim();
                    continuarBusca = resposta.Equals("s", StringComparison.OrdinalIgnoreCase);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocorreu um erro: {ex.Message}");
                    Console.Write("Deseja tentar buscar outro Pokémon? (S/N): ");
                    string resposta = Console.ReadLine().Trim();
                    continuarBusca = resposta.Equals("s", StringComparison.OrdinalIgnoreCase);
                }
            }
        }
    }


}