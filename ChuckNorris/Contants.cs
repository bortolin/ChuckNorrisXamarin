namespace ChuckNorris
{
    public static class Constants
    {

        public static string BaseAddress = "https://api.chucknorris.io/jokes";
        public static string RandomFact = BaseAddress + "/random";
        public static string RandomFactByCategory = BaseAddress + "/random?category={0}";
        public static string Categories = BaseAddress + "/categories";
        public static string Search = BaseAddress + "/search?query={0}";

        public static string Settings_MaxNumFacts = "MaxNumFacts";

    }
}
