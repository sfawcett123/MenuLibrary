using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Reflection;


namespace MenuLibrary
{
    internal class MenuHelpers
    {
        public static MenuAttributes? GetAttributeArray(Type obj)
        {
            return (MenuAttributes?)obj.GetCustomAttribute(typeof(MenuAttributes));
        }

        public static MenuAttributes? GetAttributeArray(MethodInfo obj)
        {
            return (MenuAttributes?)obj.GetCustomAttribute(typeof(MenuAttributes));
        }

        public static string GetRoute(Type controller, MethodInfo method)
        {
            var routeAttribute = method.GetCustomAttribute(typeof(RouteAttribute));
            if (routeAttribute != null)
                return ((RouteAttribute)routeAttribute).Template.Replace("/[controller]", "");

            return controller.Name.Replace("Controller", "") + "/" + method.Name;
        }
        public static string ReadResource(string MENU_LIST)
        {
            return BaseHtml.Index.Replace("{{MENU_LIST}}", MENU_LIST);
        }
    }

}