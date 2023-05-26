namespace Patterns
{
    internal class Program
    {

        public static void Main(string[] args)
        {
            var builder = new MapBuilder("Moscow");
            builder.AddComposite("Street", "Tverskaya");
            builder.AddLeaf("House", "21");
            builder.AddLeaf("House", "17");
            builder.AddLeaf("House", "32");
            builder.AddComposite("Housing Complex", "Sunrise");
            builder.AddLeaf("House", "1");
            builder.AddLeaf("House", "2");
            builder.AddLeaf("House", "3");
            builder.SetCurrentComposite("Moscow");
            builder.RemoveLeaf("Sunrise", "3");
            builder.AddComposite("Street", "Arbat");
            builder.AddLeaf("Theater", "Vakhtangova");
            builder.AddLeaf("House", "10");
            builder.DisplayTree(1);
        }
    }
}