namespace RecipesApp.Console.InputHandling.Utils
{
    internal class ListPrinter
    {
        public static void PrintList<T>(List<T> list)
        {
            foreach (var item in list)
            {
                System.Console.WriteLine(item);
            }
        }
    }
}
