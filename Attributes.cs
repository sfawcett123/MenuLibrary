using System;
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

        public bool Display { get; set; }
        public string? Name { get => _name ?? Action; set => _name = value; }
        public string? Icon { get => _icon ?? "fa-circle"; set => _icon = value; }
        public string? Controller { get; set; }
        public string? Action { get; set; }
        public string? Route { get => _route ?? "Home"; set => _route = value; }

        public string PrintOut()
        {
            return string.Format("Display = {0}, Name = {1}, Icon = {2}\n", Display.ToString(), Name, Icon);
        }
    }
}
