using System.Text.Json.Serialization;

namespace Pokedex.Models
{
    public class Pokemon
    {
        public int id { get; set; }
        public string name { get; set; }

        //public string height { get; set; }
        public int weight { get; set; }

        public Sprites sprites { get; set; }
    }

    public class Sprites
    {
        public string back_default { get; set; }
        public string back_shiny { get; set; }
        public string front_default { get; set; }
        public string front_shiny { get; set; }

        public Other other { get; set; }
    }

    public class Other
    {
        [JsonPropertyName("official-artwork")]
        public OfficialArtwork officialArtwork { get; set; }
    }

    public class OfficialArtwork
    {
        public string front_default { get; set; }
        public string front_shiny { get; set; }
    }
}
