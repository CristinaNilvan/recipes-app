namespace RecipesApp.Assignments.Queries
{
    internal class ListPrinter
    {
        public static void PrintList<T>(List<T> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
