using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace MenuLibrary
{
    internal class MenuHelpers
    {
        public static List<MenuAttributes>? GetAttributes<T>(MemberInfo member) 
        {
            return member.GetCustomAttributes(typeof(MenuAttributes)).Select(attr => (MenuAttributes)attr).ToList();
        }

        public static string GetRoute(Type controller, MethodInfo method)
        {
            var routeAttribute = method.GetCustomAttribute(typeof(RouteAttribute));
            if (routeAttribute != null)
                return ((RouteAttribute)routeAttribute).Template.Replace("/[controller]", "");

            return controller.Name.Replace("Controller", "") + "/" + method.Name;
        }

        public static string ReadResource(Dictionary<string, string> attr , List<string> MENU_LIST)
        {
            string big_string = "";
            foreach( string a in MENU_LIST)
            {
                big_string += a;
            }

            return big_string;
        }


    }
    internal static class Helper
    {  
        public static string Render( this string str, Dictionary<string, string> attributes)
        {
            String rendererd = str;


            foreach ( var item in attributes)
            {
                Regex regex = new( "{" + item.Key.ToUpper() + "}" );
                rendererd = regex.Replace(rendererd, item.Value );
            }

            return rendererd;
        }

        public static Dictionary<string, string> Merge(this Dictionary<string, string> x, Dictionary<string, string> y)
        {
            Dictionary<string, string> z = x;

            foreach (var item in y ) {
                z.Add(item.Key, item.Value);
            }

            return z;
        }
    }
}