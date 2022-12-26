using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDatabaseCreator
{
    public class Property
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Size { get; set; }
        public bool IsFk { get; set; }
        public bool NotNull { get; set; }

        public Property(string name, string type, string size, bool isfk, bool notNull)
        {
            Name = name;
            Type = type;
            Size = size;
            IsFk = isfk;
            NotNull = notNull;
        }
    }
}
