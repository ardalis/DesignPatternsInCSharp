using System.Collections.Generic;

namespace DesignPatternsInCSharp.TemplateMethod
{
    public class Pizza : PanFood 
    {
        public string CrustType { get; set; } = "no crust";
        public int NumSlices { get; set; } = 1;
        public List<string> Toppings { get; private set; } = new List<string>();
        public bool WasBaked { get; set; }
    }
}
