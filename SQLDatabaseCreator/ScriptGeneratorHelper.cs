using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDatabaseCreator
{
    public class ScriptGeneratorHelper
    {
        public string DatabaseName { get; set; }
        private List<string> TablesScripts { get; set; }
        private List<string> BindingsScripts { get; set; }
        private List<Table> Tables { get; set; }
        private List<BindingArrows> Bindings { get; set; }
        private string AutoIncrement { get; set; }
        public ScriptGeneratorHelper(string dbName, List<BindingArrows> bindings, List<Table> tables, bool autoIncrement)
        {
            DatabaseName = dbName;
            TablesScripts = new List<string>();
            BindingsScripts = new List<string>();
            Tables = tables;
            Bindings = bindings;
            AutoIncrement = autoIncrement ? "IDENTITY(1,1)" : "";
            foreach(Table table in Tables)
            {
                string identity = (Bindings.Where(x => x.childTableId == table.id && x.isOneToOne).Count() == 0 && autoIncrement) ? AutoIncrement : "";
                string tableScript = $"CREATE TABLE [dbo].[{table.name}]\n(\n[{table.pk}] [int] NOT NULL {identity},\n";
                foreach (Property property in table.properties) tableScript += $"[{property.Name}] [{property.Type}] {((property.Size == "") ? "" : $"({property.Size})")} {(property.NotNull ? "NOT NULL" : "NULL")},\n";
                tableScript += $"\nCONSTRAINT [PK_{table.name}] PRIMARY KEY CLUSTERED ([{table.pk}] ASC) ON [PRIMARY],\n)\n\n";
                TablesScripts.Add(tableScript);
            }
            foreach (BindingArrows binding in Bindings)
            {
                string bindingScript;
                string childTable = Tables.Where(x => x.id == binding.childTableId).FirstOrDefault().name;
                string parentTable = Tables.Where(x => x.id == binding.parentTableId).FirstOrDefault().name;
                string parentPk = Tables.Where(x => x.id == binding.parentTableId).FirstOrDefault().pk;
                if (binding.isOneToOne)
                {
                    bindingScript = $"ALTER TABLE [dbo].[{childTable}] WITH CHECK\n" +
                            $"ADD FOREIGN KEY ([{parentPk}]) REFERENCES [dbo].[{parentTable}]([{parentPk}])\n" +
                            $"ON DELETE CASCADE\nGO\n\n";
                }
                else
                {
                    bindingScript = $"ALTER TABLE [dbo].[{childTable}] WITH CHECK ADD CONSTRAINT [FK_{parentTable}_{childTable}] FOREIGN KEY ([{parentPk}])\n" +
                        $"REFERENCES [dbo].[{parentTable}]([{parentPk}])\nGO\n" +
                        $"ALTER TABLE [dbo].[{childTable}] CHECK CONSTRAINT [FK_{parentTable}_{childTable}]\nGO\n\n";
                }
                BindingsScripts.Add(bindingScript);
            }
        }
        /// <summary>
        /// Генерация скрипта SQL
        /// </summary>
        /// <returns>Текст скрипта</returns>
        public string GetScript()
        {
            string script = "SET ANSI_PADDING ON\nGO\nSET QUOTED_IDENTIFIER ON\nGO\nSET ANSI_NULLS ON\nGO\n\n" +
                $"CREATE DATABASE [{DatabaseName}]\nGO\n\n" +
                $"USE [{DatabaseName}]\nGO\n\n";
            foreach (string table in TablesScripts) script += table;
            foreach (string binding in BindingsScripts) script += binding;
            return script;
        }
    }
}
