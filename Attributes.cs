namespace MenuLibrary
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class MenuAttributes : Attribute 
    {
        public enum LEVEL
        {
            OUTER,
            INNER
        }

        private int _order = 10;
        public bool Display { get; set; }
        public int Order { get => _order; set => _order = value; }
        public string Name { get ; set; }  = "Unknown";
        public string Icon { get;  set; } = "fa-circle";
        public string? Controller { get; set; }
        public string? Action { get; set; }
        public string Route { get; set; } = "Home";
        public string ClassNavItem { get; set; } = "sf_menu_nav_item";
        public string ClassNavLink { get; set; } = "sf_menu_nav_link";
        public string IconGroup { get; set; } = "fas";
        public string? Parent { get; set; }
        public LEVEL Level {
            get
            {
                return Parent is null ? LEVEL.OUTER : LEVEL.INNER;
            }
        }

        public override string ToString()
        {
            return string.Format("Order = {3} , Display = {0}, Name = {1}, Icon = {2}", Display.ToString(), Name, Icon , Order);
        }

        public Dictionary<string, string> ToDict()
        {
            Dictionary<string, string> attr = new(){
                {"Name"         , Name },
                {"Icon"         , Icon },
                {"IconGroup"    , IconGroup },
                {"Route"        , Route },
                {"Order"        , Order.ToString()   },
                {"Display"      , Display.ToString() },
                {"ClassNavItem" , ClassNavItem } ,
                {"ClassNavLink" , ClassNavLink } ,
                {"Parent"       , Parent ?? "" } ,
            };
            return attr;
        }
    }
}
