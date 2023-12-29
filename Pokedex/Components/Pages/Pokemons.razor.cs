using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Pokedex.Models;
using Pokedex.Shared;
using System.Linq;

namespace Pokedex.Components.Pages
{
    public partial class Pokemons : ComponentBase
    {
        [Inject]
        public IHttpClientFactory _httpClientFactory { get; set; }

        LoadingContainerState state = new LoadingContainerState();

        private string Filter;

        private PokemonList? pokemonList;
        private PokemonList? filteredList;

        protected override async Task OnInitializedAsync()
        {
            ShowGenOne();
        }

        private async Task ShowGenOne()
        {
            state = LoadingContainerState.Loading;

            Console.WriteLine("component initialized");

            //var client = _httpClientFactory.CreateClient("pokeApi");
            var response = await GenOne();

            // Display the initial list
            pokemonList = response;
            filteredList = pokemonList;

            state = LoadingContainerState.Loaded;
            StateHasChanged();

            await Task.CompletedTask;
        }

        private async Task ShowGenTwo()
        {
            state = LoadingContainerState.Loading;

            Console.WriteLine("component initialized");

            //var client = _httpClientFactory.CreateClient("pokeApi");
            var response = await GenTwo();

            // Display the initial list
            pokemonList = response;
            filteredList = pokemonList;

            state = LoadingContainerState.Loaded;
            StateHasChanged();

            await Task.CompletedTask;
        }

        private async Task<PokemonList> GenOne()
        {
            var client = _httpClientFactory.CreateClient("pokeApi");
            return await client.GetFromJsonAsync<PokemonList>("pokemon/?limit=150");
        }

        private async Task<PokemonList> GenTwo()
        {
            var client = _httpClientFactory.CreateClient("pokeApi");
            return await client.GetFromJsonAsync<PokemonList>("pokemon/?offset=150&limit=100");
        }

        private void NameChanged(string value)
        {
            Console.WriteLine();
            Console.WriteLine();
            foreach (var item in pokemonList.results)
            {
                Console.WriteLine(item.name);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("`"+value+"`");
            Filter = value;

            if (string.IsNullOrEmpty(value))
            {
                filteredList.results = pokemonList.results;
            }
            else
            {
                filteredList.results = pokemonList.results
                    .Where(pokemon => pokemon.name.ToLower().Contains(value.ToLower()))
                    .Select(pokemon => new Models.Results(pokemon.id, pokemon.name, pokemon.url, pokemon.sprites, pokemon.types))
                    .ToList();
            }
            StateHasChanged();

            Console.WriteLine();
            Console.WriteLine();
            foreach (var item in filteredList.results)
            {
                Console.WriteLine(item.name);
            }
        }
    }
}
