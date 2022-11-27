using Microsoft.AspNetCore.Routing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace MenuLibrary
{
    public class LeftMenu 
    {
        static public string ClassNavItem { get; set; } = "sf_menu_nav_item";
        static public string ClassNavLink { get; set; } = "sf_menu_nav_link";
        static public string ClassNavList { get; set; } = "nav_list";
        static public string ClassNav    { get; set; } = "sf_menu_nav";
        static public string ClassNavBar { get; set; } = "sf_menu_nav_bar";
        static public string ClassNavTop { get; set; } = "sf_menu_nav_top";
        static public string ClassNavBottom { get; set; } = "sf_menu_nav_bottom";
        static public string IconRight { get; set; } = "fa-angles-right";
        static public string IconLeft { get; set; } = "fa-angles-left";
        static public string IconGroup { get; set; } = "fas";
        static public Dictionary<string, string> ToDict()
        {
            Dictionary<string, string> attr = new(){
                {"ClassNavItem"   , ClassNavItem } ,
                {"ClassNavLink"   , ClassNavLink } ,
                {"ClassNavTop"    , ClassNavTop } ,
                {"ClassNavBottom" , ClassNavBottom } ,
                {"ClassNavBar"    , ClassNavBar },
                {"ClassNavList"   , ClassNavList },
                {"IconGroup"      , IconGroup },
                {"IconRight"      , IconRight },
                {"IconLeft"      ,  IconLeft },
                {"ClassNav"       , ClassNav    }
            };
            return attr;
        }
        public class DataType 
        {
            public string row;
            public MenuAttributes attributes;

            public DataType(MenuAttributes attributes, string row )
            {
                this.attributes = attributes;
                this.row = row;
            }
        }

        public static string Display( List<Type> subClasses )
            {
                List<DataType> controllerNames = new();

                foreach (Type controller in subClasses)
                {
                    foreach (MethodInfo action in controller.GetMethods())
                    {
                        List<MenuAttributes>? ta = MenuHelpers.GetAttributes<MenuAttributes>(action);

                        if (ta is not null )
                        {
                            foreach (MenuAttributes lattr in ta)
                            {
                                    lattr.Route = MenuHelpers.GetRoute(controller, action);

                                    controllerNames.Add(new DataType(lattr , BaseHtml.menu_line.Render(lattr.ToDict()) + "\n" ) );
                            }
                        }

                    }
                }
         
                return MenuHelpers.ReadResource( controllerNames);
            }
        }
}
