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

        Utils utils = new Utils();

        protected override async Task OnInitializedAsync()
        {
            var client = _httpClientFactory.CreateClient("pokeApi");

            var detail = await client.GetFromJsonAsync<Pokemon>($"pokemon/{pokemon.name}");
            pokemon.id = detail.id < 1000 ? detail.id.ToString("000") : detail.id.ToString();
            pokemon.sprites = detail.sprites;
            pokemon.types = detail.types;

            StateHasChanged();
            await Task.CompletedTask;
        }
    }
}
