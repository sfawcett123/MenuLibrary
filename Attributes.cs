namespace MenuLibrary
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class MenuAttributes : Attribute 
    {
        private string? _name;
        private string? _icon;
        private string? _route;
        private int _order = 10;
        public bool Display { get; set; }
        public int Order { get => _order; set => _order = value; }
        public string? Name { get => _name ?? Action; set => _name = value; }
        public string? Icon { get => _icon ?? "fa-circle"; set => _icon = value; }
        public string? Controller { get; set; }
        public string? Action { get; set; }
        public string? Route { get => _route ?? "Home"; set => _route = value; }
        public string ClassNavItem { get; set; } = "sf_menu_nav_item";
        public string ClassNavLink { get; set; } = "sf_menu_nav_link";
        public string IconGroup { get; set; } = "fas";
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
                {"ClassNavLink" , ClassNavLink } 
            };
            return attr;
        }
    }
}
