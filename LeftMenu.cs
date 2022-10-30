using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MenuLibrary
{
    public class LeftMenu 
    {
        public static string Display(List<Type> subClasses)
        {
            string controllerNames = "";
            string FMT = "<a class=\"nav_link  \" href=\"/{2}\">  <i id=\"debug-menu\" class=\"fas {1}\">   </i> <span class=\"nav_name\">{0}</span> </a>";
            foreach (Type controller in subClasses)
            {
                MenuAttributes? ta =  MenuHelpers.GetAttributeArray(controller);

                if (ta is not null)
                {
                    //ta.Route = GetRoute(controller, "Index");
                    controllerNames += string.Format(FMT, ta.Name, ta.Icon, ta.Route) + "\n";
                }

                foreach (MethodInfo action in controller.GetMethods())
                {
                    ta = MenuHelpers.GetAttributeArray(action);

                    if (ta is not null)
                    {
                        ta.Route = MenuHelpers.GetRoute(controller, action);

                        controllerNames += string.Format(FMT, ta.Name, ta.Icon, ta.Route) + "\n";
                    }

                }
            }

            return MenuHelpers.ReadResource(controllerNames);
        }
    }
}
