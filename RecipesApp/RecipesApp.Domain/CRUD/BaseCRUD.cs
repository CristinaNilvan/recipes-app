namespace RecipesApp.Domain.CRUD
{
    public abstract class BaseCRUD<T>
    {
        public static void Update(List<T> list, T firstElement, T secondElement)
        {
            int position = -1;

            for (int i = 0; i < list.Count; i++)
            {
                if (list.ElementAt(i).Equals(firstElement))
                {
                    position = i;
                }
            }

            if (position > -1)
            {
                list.RemoveAt(position);
                list.Add(secondElement);
            }
        }

        public static void Delete(List<T> list, T element)
        {
            int position = -1;

            for (int i = 0; i < list.Count; i++)
            {
                if (list.ElementAt(i).Equals(element))
                {
                    position = i;
                }
            }

            if (position > -1)
                list.RemoveAt(position);
        }
    }
}
