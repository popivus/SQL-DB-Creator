using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDatabaseCreator
{
    public partial class FormGenerateScript : Form
    {
        public FormGenerateScript()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Фильтр вводимых данных в поле имени базы данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !"qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890_".Contains(e.KeyChar))
            {
                e.Handled = true;
            }
            if (char.IsDigit(e.KeyChar) && (sender as TextBox).Text.Length == 0)
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// Выбор места сохранения скрипта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createScriptSql_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(dbNameBox.Text))
            {
                SaveFileDialog saveScriptDialog = new SaveFileDialog();
                saveScriptDialog.Filter = "SQL|*.sql";
                saveScriptDialog.Title = "Сохранить скрипт";
                if (saveScriptDialog.ShowDialog() == DialogResult.OK && saveScriptDialog.FileName != "")
                {
                    FormMain form = Owner as FormMain;
                    StreamWriter writer = new StreamWriter(saveScriptDialog.FileName);
                    ScriptGeneratorHelper scriptGenerator = new ScriptGeneratorHelper(dbNameBox.Text, form.bindings, form.tables, autoincrementBox.Checked);
                    writer.Write(scriptGenerator.GetScript());
                    writer.Close();
                    MessageBox.Show($"Скрипт создан в:\n\n{saveScriptDialog.FileName}");
                    Close();
                }
            }
            else MessageBox.Show("Заполните наименование базы данных.", "Ошибка");
        }
    }
}
