namespace Pokedex.Models
{
    public class PokemonList
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public List<Results> results { get; set; }
    }

    public class Results
    {
        public int id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public Sprites sprites { get; set; }
        public List<Types> types { get; set; }

        public Results(int id, string name, string url, Sprites sprites, List<Types> types)
        {
            this.id = id;
            this.name = name;
            this.url = url;
            this.sprites = sprites;
            this.types = types;
        }
    }
}
