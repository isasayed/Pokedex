using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Pokedex.Models;
using Pokedex.Shared;

namespace Pokedex.Components.Pages
{
    public partial class Pokemons : ComponentBase
    {
        [Inject]
        public IHttpClientFactory _httpClientFactory { get; set; }

        LoadingContainerState state = new LoadingContainerState();

        private PokemonList? pokemonList;

        protected override async Task OnInitializedAsync()
        {
            state = LoadingContainerState.Loading;

            var client = _httpClientFactory.CreateClient("pokeApi");
            var response = await client.GetFromJsonAsync<PokemonList>("pokemon/?limit=150");

            // Display the initial list
            pokemonList = response;

            state = LoadingContainerState.Loaded;
            StateHasChanged();

            await Task.CompletedTask;
        }

        //private async Task LoadImagesAsync(HttpClient client)
        //{
        //    foreach (var item in pokemonList.results)
        //    {
        //        var pokemon = await client.GetFromJsonAsync<Pokemon>($"pokemon/{item.name}");
        //        item.sprites = pokemon.sprites;
            
        //        StateHasChanged();
        //    }


        //    foreach (var item in pokemonList.results)
        //    {
        //        Console.WriteLine(item.sprites.other.officialArtwork.front_default);
        //    }
        //}
    }
}
