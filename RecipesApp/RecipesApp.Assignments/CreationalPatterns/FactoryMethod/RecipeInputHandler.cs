using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesApp.Assignments.CreationalPatterns.FactoryMethod
{
    public class RecipeInputHandler : IInputHandler
    {
        public void HandleCreate()
        {
            Console.WriteLine("Create recipe");
        }

        public void HandleDelete()
        {
            Console.WriteLine("Delete recipe");
        }

        public void HandleRead()
        {
            Console.WriteLine("Read recipe");
        }

        public void HandleReadAll()
        {
            Console.WriteLine("Read all recipes");
        }

        public void HandleUpdate()
        {
            Console.WriteLine("Update recipe");
        }
    }
}
