using System.Reflection;

namespace MenuLibrary
{
    public class Menu
    {
        public static readonly string BODY_ID = "body-id";
        private static Dictionary<string, string> Dict  = new()
        {
            { "BODY_ID" , BODY_ID }
        };


        public static List<Type> GetSubClasses<T>()
        {
            return Assembly.GetCallingAssembly().GetTypes().Where(
                type => type.IsSubclassOf(typeof(T))).ToList();
        }
    }
}
