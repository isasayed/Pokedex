namespace Pokedex.Functions
{
    public class Utils
    {
        public string getCardClass(string type)
        {
            switch (type)
            {
                case "grass":
                    return "bg-grass";
                case "fire":
                    return "bg-fire";
                case "water":
                case "ice":
                    return "bg-water";
                case "bug":
                    return "bg-bug";
                case "poison":
                    return "bg-poison";
                case "electric":
                    return "bg-electric";
                case "fighting":
                    return "bg-fighting";
                case "dragon":
                    return "bg-dragon";
                case "ground":
                    return "bg-ground";
                case "psychic":
                    return "bg-psychic";
                default:
                    return "";
            }
        }

    }
}
