using Newtonsoft.Json.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MenuLibrary
{
    public class LeftMenu 
    {
    private class DataType 
    { 
        public int order;
        public string? row;

            public DataType(int order, string? row)
            {
                this.order = order;
                this.row = row;
            }
        }
    public static string Display(List<Type> subClasses)
        {
            List<DataType> controllerNames = new List<DataType>();

            string FMT = "<a class=\"nav_link\" href=\"/{2}\">  <i id=\"debug-menu\" class=\"fas {1}\">   </i> <span class=\"nav_name\">{0}</span> </a>";
            foreach (Type controller in subClasses)
            {
                foreach (MethodInfo action in controller.GetMethods())
                {
                    List<MenuAttributes>? ta = MenuHelpers.GetAttributes<MenuAttributes>(action);

                    if (ta is not null )
                    {
                        foreach (MenuAttributes attr in ta)
                        {  
                            Console.WriteLine( attr.ToString() );

                            attr.Route = MenuHelpers.GetRoute(controller, action);

                            controllerNames.Add( new DataType( attr.Order, string.Format(FMT, attr.Name, attr.Icon, attr.Route) + "\n" ) );
                        }
                    }

                }
            }

            return MenuHelpers.ReadResource(controllerNames.OrderBy(o => o.order).Select(o => o.row).ToList());
        }
    }
}
