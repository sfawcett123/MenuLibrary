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


        public static string Css()
        {
            Dictionary<string, string> att = LeftMenu.ToDict().Merge(Dict );
            return string.Format("<style>{0}</style>", BaseHtml.Styles.Render( att ));
        }

        public static string Scripts()
        {
            Dictionary<string, string> att = LeftMenu.ToDict().Merge( Dict);

            return string.Format("<script>{0}</script>", BaseHtml.menu.Render( att ));
        }
        public static List<Type> GetSubClasses<T>()
        {
            return Assembly.GetCallingAssembly().GetTypes().Where(
                type => type.IsSubclassOf(typeof(T))).ToList();
        }
    }
}
