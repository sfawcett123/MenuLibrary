using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MenuLibrary
{
    public class Menu
    {
        public static string BODY_ID { get => "body-id";  }
        public static string Css()
        {
            return string.Format("<style>{0}</style>", BaseHtml.Styles);
        }

        public static string Scripts()
        {
            return string.Format("<script>{0}</script>", BaseHtml.menu.Replace("{{BODY_ID}}" , Menu.BODY_ID ));
        }
        public static List<Type> GetSubClasses<T>()
        {
            return Assembly.GetCallingAssembly().GetTypes().Where(
                type => type.IsSubclassOf(typeof(T))).ToList();
        }
    }
}
