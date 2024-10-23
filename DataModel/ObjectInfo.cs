using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAssignmentSitek.DataModel
{
    public class ObjectInfo
    {
       public string name_type { get; set; }
        public string name { get; set; }
        
        public ObjectInfo(string name_type, string name)
        { 
            this.name_type = name_type;
            this.name = name;
        }
    }
}
