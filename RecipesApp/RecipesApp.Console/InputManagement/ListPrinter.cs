using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesApp.Console.InputManagement
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
