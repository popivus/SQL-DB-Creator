using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDatabaseCreator
{
    public partial class AttributeForm : Form
    {
        public AttributeForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Закрытие окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// Реакция на изменение типа данных свойства
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void typesBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (typesBox.SelectedIndex > 2)
            {
                maxCheck.Checked = false;
                SizeNeedOnOff(false);
                sizeBox.Text = "";
            }
            else
            {
                SizeNeedOnOff(true);
            }
        }
        /// <summary>
        /// Блокирование или разблокирование элементов размера свойства
        /// </summary>
        /// <param name="need"></param>
        private void SizeNeedOnOff(bool need)
        {
            sizeLabel.Enabled = need;
            sizeBox.Enabled = need;
            maxCheck.Enabled = need;
        }
        /// <summary>
        /// Установка максимального размера свойства
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void maxCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (maxCheck.Checked)
            {
                sizeBox.Text = "MAX";
                sizeBox.Enabled = false;
            }
            else
            {
                sizeBox.Text = "";
                sizeBox.Enabled = true;
            }
        }
        /// <summary>
        /// Фильтр ввода данных в поле имени
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nameBox_KeyPress(object sender, KeyPressEventArgs e)
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
        /// Фильтр вводимых данных в поле размера свойства
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sizeBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// Добавление свойства к таблице
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameBox.Text) && (!string.IsNullOrWhiteSpace(sizeBox.Text) || typesBox.SelectedIndex > 2))
            {
                FormMain form = Owner as FormMain;
                bool nameAlreadyExists = false;
                for (int i = 0; i < form.tables[form.idTableAttributes].properties.Count; i++) 
                {
                    if (form.tables[form.idTableAttributes].properties[i].Name == nameBox.Text && (form.addOrEditProp || i != form.idRowEditProp)) nameAlreadyExists = true;
                }
                if (!nameAlreadyExists)
                {
                    Property newProperty = new Property(nameBox.Text, typesBox.SelectedItem.ToString(), sizeBox.Text, false, notNullBox.Checked);
                    if (form.addOrEditProp)
                    {
                        form.tables[form.idTableAttributes].properties.Add(newProperty);
                        form.tables[form.idTableAttributes].table.Rows.Add(newProperty.Name, (newProperty.Size.Length == 0) ? newProperty.Type : $"{newProperty.Type}({newProperty.Size})", newProperty.IsFk, newProperty.NotNull);
                    }
                    else
                    {
                        form.tables[form.idTableAttributes].properties[form.idRowEditProp] = newProperty;
                        form.tables[form.idTableAttributes].table.Rows[form.idRowEditProp]["Имя"] = newProperty.Name;
                        form.tables[form.idTableAttributes].table.Rows[form.idRowEditProp]["Тип"] = (newProperty.Size.Length == 0) ? newProperty.Type : $"{newProperty.Type}({newProperty.Size})";
                        form.tables[form.idTableAttributes].table.Rows[form.idRowEditProp]["FK"] = newProperty.IsFk;
                        form.tables[form.idTableAttributes].table.Rows[form.idRowEditProp]["Не Null"] = newProperty.NotNull;
                    }
                    Close();
                }
                else MessageBox.Show("Такое имя столбца уже существует.", "Ошибка");
            }
            else MessageBox.Show("Не все поля заполнены", "Ошибка");
        }
        /// <summary>
        /// Реакция программы на запуск окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttributeForm_Load(object sender, EventArgs e)
        {
            FormMain form = Owner as FormMain;
            if (form.addOrEditProp) typesBox.SelectedIndex = 0;
            else
            {
                addBtn.Text = "Изменить";
                var editProp = form.tables[form.idTableAttributes].properties[form.idRowEditProp];
                nameBox.Text = editProp.Name;
                typesBox.SelectedItem = editProp.Type;
                sizeBox.Text = editProp.Size;
                if (sizeBox.Text == "MAX") maxCheck.Checked = true;
                notNullBox.Checked = editProp.NotNull;
            }
        }
    }
}
