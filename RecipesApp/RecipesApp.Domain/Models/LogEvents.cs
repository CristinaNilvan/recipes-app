namespace RecipesApp.Domain.Models
{
    public class LogEvents
    {
        public const int CreateItem = 1000;
        public const int GetItem = 1001;
        public const int GetItems = 1002;
        public const int UpdateItem = 1003;
        public const int DeleteItem = 1004;
        public const int GenerateItem = 1005;
        public const int AddToItem = 1006;
        public const int RemoveFromItem = 1007;

        public const int GetItemNotFound = 4000;
        public const int UpdateItemNotFound = 4001;
        public const int DeleteItemNotFound = 4002;
        public const int AddToItemNotFound = 4003;
        public const int RemoveFromItemNotFound = 4004;
    }
}