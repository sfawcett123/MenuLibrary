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

        public static string ReadResource(List<LeftMenu.DataType> MENU_LIST)
        {
            string big_string = "";
            foreach( var top_level in MENU_LIST.Where( x=> x.attributes.Level == MenuAttributes.LEVEL.OUTER ).OrderBy(o => o.attributes.Order))
            {
                big_string += top_level.row;
                var children = MENU_LIST.Where(x => x.attributes.Level == MenuAttributes.LEVEL.INNER).Where( x=> x.attributes.Parent == top_level.attributes.Name).OrderBy(o => o.attributes.Order).Select(x => x.row);
                if( children.Any() )
                {
                    big_string += "<ul>";
                    foreach ( var sub_level in children)
                    {
                        Console.WriteLine($"Item {sub_level}");
                        big_string += sub_level;
                    }
                    big_string += "</ul>";
                }
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
                if (item.Value is null) continue;

                
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