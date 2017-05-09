using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Editor
{
    interface GItem
    {
        string Name { get; set; }
        string Type { get; set; }
        List<GItem> Subitem { get; set; }
    }
}
