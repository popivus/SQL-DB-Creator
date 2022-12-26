using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDatabaseCreator
{
    public class Table
    {
        public int id { get; set; }
        public string name { get; set; }
        public string pk { get; set; }
        public List<Property> properties { get; set; }
        public DataTable table { get; set; }
        public Table(int id)
        {
            this.id = id;
            table = new DataTable();
            table.Columns.Add("Имя", typeof(string));
            table.Columns.Add("Тип", typeof(string));
            table.Columns.Add("FK", typeof(bool));
            table.Columns.Add("Не Null", typeof(bool));
            properties = new List<Property>();
        }
    }
}
