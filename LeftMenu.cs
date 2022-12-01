using System.Reflection;

namespace MenuLibrary
{
    public class LeftMenu
    {
        public static string ClassNavItem { get; set; } = "sf_menu_nav_item";
        public static string ClassNavLink { get; set; } = "sf_menu_nav_link";
        public static string ClassNavList { get; set; } = "nav_list";
        public static string ClassNav { get; set; } = "sf_menu_nav";
        public static string ClassNavBar { get; set; } = "sf_menu_nav_bar";
        public static string ClassNavTop { get; set; } = "sf_menu_nav_top";
        public static string ClassNavBottom { get; set; } = "sf_menu_nav_bottom";
        public static string IconRight { get; set; } = "fa-angles-right";
        public static string IconLeft { get; set; } = "fa-angles-left";
        public static string IconGroup { get; set; } = "fas";
        public static Dictionary<string, string> ToDict()
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

            public DataType(MenuAttributes attributes, string row)
            {
                this.attributes = attributes;
                this.row = row;
            }
        }

        public static string Display(List<Type> subClasses)
        {
            List<DataType> controllerNames = new();

            foreach (Type controller in subClasses)
            {
                foreach (MethodInfo action in controller.GetMethods())
                {
                    List<MenuAttributes>? ta = MenuHelpers.GetAttributes<MenuAttributes>(action);

                    if (ta is not null)
                    {
                        foreach (MenuAttributes lattr in ta)
                        {
                            lattr.Route = MenuHelpers.GetRoute(controller, action);

                            controllerNames.Add(new DataType(lattr, BaseHtml.menu_line.Render(lattr.ToDict()) + "\n"));
                        }
                    }

                }
            }

            return MenuHelpers.ReadResource(controllerNames);
        }
    }
}
