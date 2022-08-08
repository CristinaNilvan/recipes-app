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
