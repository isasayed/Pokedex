namespace Pokedex.Models
{
    public class Types
    {
        public int slot { get; set; }
        public Type type { get; set; }
    }

    public class Type
    {
        public string name { get; set; }
        public string url { get; set; }
    }
}
