using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesApp.Assignments.CreationalPatterns.FactoryMethod
{
    public class IngredientInputHandler : IInputHandler
    {
        public void HandleCreate()
        {
            Console.WriteLine("Create ingredient");
        }

        public void HandleDelete()
        {
            Console.WriteLine("Delete ingredient");
        }

        public void HandleRead()
        {
            Console.WriteLine("Read ingredient");
        }

        public void HandleReadAll()
        {
            Console.WriteLine("Read all ingredients");
        }

        public void HandleUpdate()
        {
            Console.WriteLine("Update ingredient");
        }
    }
}
