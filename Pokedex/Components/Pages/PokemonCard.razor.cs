using Microsoft.AspNetCore.Components;
using Pokedex.Models;
using Pokedex.Shared;
using System.Net.Http;

namespace Pokedex.Components.Pages
{
    public partial class PokemonCard : ComponentBase
    {

        [Inject]
        public IHttpClientFactory _httpClientFactory { get; set; }

        [Parameter]
        public Models.Results pokemon { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var client = _httpClientFactory.CreateClient("pokeApi");

            var detail = await client.GetFromJsonAsync<Pokemon>($"pokemon/{pokemon.name}");
            pokemon.sprites = detail.sprites;

            StateHasChanged();
            await Task.CompletedTask;
        }
    }
}
