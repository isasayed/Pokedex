using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using Pokedex.Functions;
using Pokedex.Models;
using Pokedex.Shared;
using System.Net.Http;

namespace Pokedex.Components.Partials
{
    public partial class PokemonCard : ComponentBase
    {
        [Inject]
        public IHttpClientFactory _httpClientFactory { get; set; }

        [Parameter]
        public Models.Results pokemon { get; set; }
        
        [Parameter]
        public Modal modal { get; set; }

        Utils utils = new Utils();

        protected override async Task OnInitializedAsync()
        {
            var client = _httpClientFactory.CreateClient("pokeApi");

            var detail = await client.GetFromJsonAsync<Pokemon>($"pokemon/{pokemon.name}");
            pokemon.id = detail.id;
            pokemon.sprites = detail.sprites;
            pokemon.types = detail.types;

            StateHasChanged();
            await Task.CompletedTask;
        }

        private async Task ShowEmployeeComponent()
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("name", pokemon.name);
            await modal.ShowAsync<PokemonModal>(title: pokemon.name, parameters: parameters);
        }
    }
}
