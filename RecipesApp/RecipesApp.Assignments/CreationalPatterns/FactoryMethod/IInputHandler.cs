using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesApp.Assignments.CreationalPatterns.FactoryMethod
{
    public interface IInputHandler
    {
        void HandleCreate();
        void HandleRead();
        void HandleUpdate();
        void HandleDelete();
        void HandleReadAll();
    }
}
