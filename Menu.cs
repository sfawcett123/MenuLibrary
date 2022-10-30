using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection;


namespace MenuLibrary
{
    public class Menu 
    {
        private static MenuAttributes? GetAttributeArray(Type obj)
        {
            MenuAttributes[] AttributeArray = (MenuAttributes[])obj.GetCustomAttributes(typeof(MenuAttributes), false);
            return AttributeArray.Length == 0 ? null : AttributeArray[0];
        }
        private static MenuAttributes? GetAttributeArray(MethodInfo obj)
        {
            MenuAttributes[] AttributeArray = (MenuAttributes[])obj.GetCustomAttributes(typeof(MenuAttributes), false);
            return AttributeArray.Length == 0 ? null : AttributeArray[0];
        }

        private static string ReadResource( string MENU_LIST )
        {
           return BaseHtml.Index.Replace("{{MENU_LIST}}"  , MENU_LIST );
        }
        public static string Display(List<Type> subClasses)
        {
                string controllerNames = "";
                string FMT = "<a class=\"nav_link  \" asp-area=\"\" asp-controller=\"{2}\"   asp-action=\"{3}\"> <i id=\"debug-menu\" class=\"fas {1}\">   </i> <span class=\"nav_name\">{0}</span> </a>";
                foreach (Type classes in subClasses)
                {
                    MenuAttributes? ta = GetAttributeArray(classes);

                    if (ta is not null)
                    {
                        ta.Controller = classes.Name;
                        ta.Action = "Index";
                        controllerNames += string.Format(FMT, ta.Name, ta.Icon , "Home" , ta.Action ) + "\n"; 
                    }

                    foreach (MethodInfo methods in classes.GetMethods())
                    {
                        ta = GetAttributeArray(methods);

                        if (ta is not null)
                        {
                            ta.Controller = classes.Name;
                            ta.Action = methods.Name;
                            controllerNames += string.Format(FMT, ta.Name, ta.Icon, ta.Controller, ta.Action) + "\n";
                        }

                    }
                }

                return ReadResource( controllerNames );
            }
        public static List<Type> GetSubClasses<T>()
        {
            return Assembly.GetCallingAssembly().GetTypes().Where(
                type => type.IsSubclassOf(typeof(T))).ToList();
        }
    }

}