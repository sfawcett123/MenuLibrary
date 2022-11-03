using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Diagnostics.Metrics;
using System.Reflection;


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
        public static string ReadResource(List<string> MENU_LIST)
        {
            string big_string = "";
            foreach( string a in MENU_LIST)
            {
                big_string += a;
            }
            return BaseHtml.Index.Replace("{{MENU_LIST}}", big_string);
        }
    }

}