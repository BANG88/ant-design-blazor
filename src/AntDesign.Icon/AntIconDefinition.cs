using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Components;


namespace AntDesign.Icon
{
    public class AntIconDefinition

    {
        public string Name { get; set; }
        public string Theme { get; set; }
        public string ViewBox { get; set; }
        public List<string> Paths { get; set; }
    }
}
