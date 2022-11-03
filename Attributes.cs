using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public override string ToString()
        {
            return string.Format("Order = {3} , Display = {0}, Name = {1}, Icon = {2}", Display.ToString(), Name, Icon , Order);
        }
    }
}
