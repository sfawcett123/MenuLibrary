using System.Reflection;

namespace MenuLibrary
{
    public class Menu
    {
        public static readonly string BODY_ID = "body-id";
        public static List<Type> GetSubClasses<T>()
        {
            return Assembly.GetCallingAssembly().GetTypes().Where(
                type => type.IsSubclassOf(typeof(T))).ToList();
        }
    }
}
