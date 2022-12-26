using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace SQLDatabaseCreator
{
    [Serializable]
    public partial class FormMain : Form
    {
        bool drag = true, create = false, delete = false, oneToOne = false, oneToMany = false, deleteBinding = false;
        Button[] instrumentBtns;
        int[] startArrow1k1 = new int[2];
        int[] endArrow1k1 = new int[2];
        bool firstTable1k1 = false;
        int[] startArrow1km = new int[2];
        int[] endArrow1km = new int[2];
        bool firstTable1km = false;
        int maxId = 0;
        public List<Table> tables = new List<Table>();
        public List<BindingArrows> bindings = new List<BindingArrows>();
        public int idTableAttributes, idRowEditProp, firstIdTableBinding, secondIdTableBinding;
        public bool addOrEditProp = true;

        public FormMain()
        {
            InitializeComponent();
            dragBtn.BackColor = Color.DarkGray;
            instrumentBtns = new Button[] { dragBtn, newTableBtn, deleteTableBtn, binding1k1Btn, binding1kMBtn, deleteBindingBtn };
        }
        /// <summary>
        /// Реакция панели на нажатие кнопкой мыши на неё
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_Click(object sender, EventArgs e)
        {
            if (create)
            {
                Panel table = new Panel();
                table.MouseDown += table_MouseDown;
                table.MouseMove += table_MouseMove;
                table.MouseUp += table_MouseUp;
                table.Location = new Point(Control.MousePosition.X - this.DesktopLocation.X - 20, Control.MousePosition.Y - this.DesktopLocation.Y - 100);
                table.Size = new Size(286, 139);
                table.BorderStyle = BorderStyle.Fixed3D;
                Label id = new Label();
                id.Visible = false;
                id.Text = maxId.ToString();
                TextBox tableName = new TextBox();
                tableName.Location = new Point(3, 3);
                tableName.Size = new Size(276, 20);
                tableName.TextChanged += nameBox_TextChanged;
                tableName.MaxLength = 50;
                tableName.KeyPress += textWatcher_KeyPress;
                Label pkLabel = new Label();
                pkLabel.Location = new Point(0, 35);
                pkLabel.Text = "PK:";
                pkLabel.Size = new Size(24, 13);
                TextBox pk = new TextBox();
                pk.Location = new Point(24, 31);
                pk.Size = new Size(226, 20);
                pk.TextChanged += pkBox_TextChanged;
                pk.MaxLength = 50;
                pk.KeyPress += textWatcher_KeyPress;
                DataGridView attributes = new DataGridView();
                attributes.Location = new Point(5, 57);
                attributes.Size = new Size(245, 75);
                attributes.AllowUserToAddRows = false;
                attributes.AllowUserToDeleteRows = false;
                attributes.ReadOnly = true;
                attributes.RowHeadersVisible = false;
                attributes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                attributes.MultiSelect = false;
                attributes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                attributes.CellDoubleClick += editProperty_cellClick;
                Button addAtr = new Button();
                addAtr.Location = new Point(252, 57);
                addAtr.Size = new Size(27, 23);
                addAtr.Text = "+";
                addAtr.Click += newPropertyBtn_Click;
                Button removeAtr = new Button();
                removeAtr.Location = new Point(252, 86);
                removeAtr.Size = new Size(27, 23);
                removeAtr.Text = "-";
                removeAtr.Click += deletePropertyBtn_Click;
                Table newTable = new Table(maxId);
                maxId++;
                tables.Add(newTable);
                attributes.DataSource = tables[maxId - 1].table;
                table.Controls.Add(id);
                table.Controls.Add(tableName);
                table.Controls.Add(pkLabel);
                table.Controls.Add(pk);
                table.Controls.Add(attributes);
                table.Controls.Add(addAtr);
                table.Controls.Add(removeAtr);
                this.panel1.Controls.Add(table);
            }
        }
        /// <summary>
        /// Открытие окна редактирования свойства таблицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editProperty_cellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (!tables[Convert.ToInt32(((sender as Control).Parent.Controls[0] as Label).Text)].properties[e.RowIndex].IsFk)
                {
                    addOrEditProp = false;
                    idRowEditProp = e.RowIndex;
                    idTableAttributes = Convert.ToInt32(((sender as Control).Parent.Controls[0] as Label).Text);
                    AttributeForm form = new AttributeForm();
                    form.Owner = this;
                    form.Text = $"{((sender as Control).Parent.Controls[1] as TextBox).Text}: столбец";
                    form.ShowDialog();
                }
            }
        }
        /// <summary>
        /// Фильтр вводимых данных в поля 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textWatcher_KeyPress(object sender, KeyPressEventArgs e)
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
        /// Изменение имени таблиц
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            int idTable = Convert.ToInt32(((sender as Control).Parent.Controls[0] as Label).Text);
            tables[idTable].name = (sender as TextBox).Text;
        }
        /// <summary>
        /// Изменение первичного ключа таблицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pkBox_TextChanged(object sender, EventArgs e)
        {
            int idTable = Convert.ToInt32(((sender as Control).Parent.Controls[0] as Label).Text);
            foreach (BindingArrows arrows in bindings)
            {
                if (arrows.parentTableId == idTable && !arrows.isOneToOne)
                {
                    tables[arrows.childTableId].properties.Where(x => x.Name.StartsWith(tables[idTable].pk) && x.IsFk).FirstOrDefault().Name = (sender as TextBox).Text;
                    for (int i = 0; i < tables[arrows.childTableId].table.Rows.Count; i++)
                    {
                        if (tables[arrows.childTableId].table.Rows[i].ItemArray[0].ToString().StartsWith(tables[idTable].pk) && Convert.ToBoolean(tables[arrows.childTableId].table.Rows[i].ItemArray[2]))
                        {
                            tables[arrows.childTableId].table.Rows[i]["Имя"] = (sender as TextBox).Text;
                        }
                    }
                }
            }
            tables[idTable].pk = (sender as TextBox).Text;
        }

        bool isDown;
        /// <summary>
        /// Реакция на нажатие на таблицу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void table_MouseDown(object sender, MouseEventArgs e)
        {
            if (drag) isDown = true;
        }
        /// <summary>
        /// Реакция на движение мыши в таблице
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void table_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Control c = sender as Control;
                if (isDown)
                {
                    Point point = new Point(Control.MousePosition.X - 80, Control.MousePosition.Y - 80);
                    c.Location = this.PointToClient(point);
                    for (int i = 0; i < bindings.Count; i++)
                    {
                        if (Convert.ToInt32((c.Controls[0] as Label).Text) == bindings[i].childTableId || Convert.ToInt32((c.Controls[0] as Label).Text) == bindings[i].parentTableId)
                        {
                            int startX = panel1.Controls[bindings[i].parentTableId].Location.X + (sender as Control).Width;
                            int startY = panel1.Controls[bindings[i].parentTableId].Location.Y + (sender as Control).Height / 2;
                            int endX = panel1.Controls[bindings[i].childTableId].Location.X;
                            int endY = panel1.Controls[bindings[i].childTableId].Location.Y;
                            if (startX > endX && startX - (sender as Control).Width < endX + (sender as Control).Width)
                            {
                                startX -= (sender as Control).Width / 2;
                                endX += (sender as Control).Width / 2;
                                if (startY > endY)
                                {
                                    startY -= (sender as Control).Height / 2;
                                    endY += (sender as Control).Size.Height;
                                }
                                else
                                {
                                    startY += (sender as Control).Height / 2;
                                }
                            }
                            else if (startX > endX + (sender as Control).Width * 2)
                            {
                                startX -= (sender as Control).Width;
                                endX += (sender as Control).Width;
                                endY += (sender as Control).Size.Height / 2;
                            }
                            else
                            {
                                endY += (sender as Control).Size.Height / 2;
                            }
                            bindings[i].startArrow = new Point(startX, startY);
                            bindings[i].endArrow = new Point(endX, endY);
                        }
                    }
                    RepaintAllBindings();
                }
            }
        }

        /// <summary>
        /// Перерисовка всех связей в рабочей области
        /// </summary>
        private void RepaintAllBindings()
        {
            Graphics g = panel1.CreateGraphics();
            g.Clear(Color.White);
            foreach (BindingArrows arrow in bindings)
            {
                Pen pen = new Pen(arrow.isOneToOne ? Color.DarkRed : Color.DarkGreen, 5);
                pen.EndCap = LineCap.ArrowAnchor;
                g.DrawLine(pen, arrow.startArrow, arrow.endArrow);
            }
            g.Dispose();
        }

        /// <summary>
        /// Реакция на отпускание кнопки 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void table_MouseUp(object sender, MouseEventArgs e)
        {
            if (drag) isDown = false;
            if (delete)
            {
                int idDelete = Convert.ToInt32(((sender as Control).Controls[0] as Label).Text);
                foreach (BindingArrows arrows in bindings)
                {
                    if (!arrows.isOneToOne && (idDelete == arrows.parentTableId || idDelete == arrows.childTableId))
                    {
                        tables[arrows.childTableId].properties.RemoveAll(x => x.IsFk && x.Name.StartsWith(tables[arrows.parentTableId].pk));
                        for (int i = 0; i < tables[arrows.childTableId].table.Rows.Count; i++) if (tables[arrows.childTableId].table.Rows[i].ItemArray[0].ToString().StartsWith(tables[arrows.parentTableId].pk) && Convert.ToBoolean(tables[arrows.childTableId].table.Rows[i].ItemArray[2]) == true)
                            {
                                tables[arrows.childTableId].table.Rows.RemoveAt(i);
                            }
                    }
                }
                bindings.RemoveAll(x => x.childTableId == idDelete);
                bindings.RemoveAll(x => x.parentTableId == idDelete);
                tables.RemoveAt(idDelete);
                panel1.Controls.Remove(sender as Control);
                for (int i = 0; i < panel1.Controls.Count; i++)
                {
                    var panel = panel1.Controls;
                    int currentId = Convert.ToInt32((panel[i].Controls[0] as Label).Text);
                    if (currentId > idDelete)
                    {
                        for (int j = 0; j < bindings.Count; j++)
                        {
                            if (bindings[j].parentTableId == currentId) bindings[j].parentTableId = currentId - 1;
                            if (bindings[j].childTableId == currentId) bindings[j].childTableId = currentId - 1;
                        }
                        currentId--;
                        (panel[i].Controls[0] as Label).Text = currentId.ToString();
                        tables[i].id = currentId;
                        
                    }
                }
                maxId--;
                RefreshOneToOne();
                RepaintAllBindings();
            }
            if (oneToOne)
            {
                if (!string.IsNullOrWhiteSpace(((sender as Control).Controls[1] as TextBox).Text) && !string.IsNullOrWhiteSpace(((sender as Control).Controls[3] as TextBox).Text))
                {
                    if (!firstTable1k1)
                    {
                        startArrow1k1[0] = (sender as Control).Location.X + (sender as Control).Size.Width;
                        startArrow1k1[1] = (sender as Control).Location.Y + (sender as Control).Size.Height / 2;
                        firstTable1k1 = true;
                        firstIdTableBinding = Convert.ToInt32(((sender as Control).Controls[0] as Label).Text);
                    }
                    else
                    {
                        secondIdTableBinding = Convert.ToInt32(((sender as Control).Controls[0] as Label).Text);
                        bool alreadyExists = false;
                        foreach (BindingArrows arrows in bindings) if (arrows.parentTableId == firstIdTableBinding && arrows.childTableId == secondIdTableBinding || arrows.childTableId == firstIdTableBinding && arrows.parentTableId == secondIdTableBinding || arrows.childTableId == secondIdTableBinding) alreadyExists = true;
                        if (!alreadyExists)
                        {
                            if (firstIdTableBinding != secondIdTableBinding)
                            {
                                if (startArrow1k1[0] > (sender as Control).Location.X && startArrow1k1[0] - (sender as Control).Width < (sender as Control).Location.X + (sender as Control).Width)
                                {
                                    startArrow1k1[0] -= (sender as Control).Width / 2;
                                    endArrow1k1[0] = (sender as Control).Location.X + (sender as Control).Width / 2;
                                    if (startArrow1k1[1] > (sender as Control).Location.Y)
                                    {
                                        startArrow1k1[1] -= (sender as Control).Height / 2;
                                        endArrow1k1[1] = (sender as Control).Location.Y + (sender as Control).Size.Height;
                                    }
                                    else
                                    {
                                        startArrow1k1[1] += (sender as Control).Height / 2;
                                        endArrow1k1[1] = (sender as Control).Location.Y;
                                    }
                                }
                                else if (startArrow1k1[0] > (sender as Control).Location.X + (sender as Control).Width * 2)
                                {
                                    startArrow1k1[0] -= (sender as Control).Width;
                                    endArrow1k1[0] = (sender as Control).Location.X + (sender as Control).Width;
                                    endArrow1k1[1] = (sender as Control).Location.Y + (sender as Control).Size.Height / 2;
                                }
                                else
                                {
                                    endArrow1k1[0] = (sender as Control).Location.X;
                                    endArrow1k1[1] = (sender as Control).Location.Y + (sender as Control).Size.Height / 2;
                                }
                                Graphics g = panel1.CreateGraphics();
                                Pen pen = new Pen(Color.DarkRed, 5);
                                pen.EndCap = LineCap.ArrowAnchor;
                                pen.StartCap = LineCap.Round;
                                g.DrawLine(pen, startArrow1k1[0], startArrow1k1[1], endArrow1k1[0], endArrow1k1[1]);
                                g.Dispose();
                                firstTable1k1 = false;
                                BindingArrows arrow = new BindingArrows(new Point(startArrow1k1[0], startArrow1k1[1]), new Point(endArrow1k1[0], endArrow1k1[1]), true, firstIdTableBinding, secondIdTableBinding);
                                bindings.Add(arrow);
                                ((sender as Control).Controls[3] as TextBox).Text = (panel1.Controls[firstIdTableBinding].Controls[3] as TextBox).Text;
                                ((sender as Control).Controls[3] as TextBox).Enabled = false;
                            }
                            else
                            {
                                MessageBox.Show("Связь невозможна.", "Ошибка");
                                firstTable1k1 = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Связь уже существует.", "Ошибка");
                            firstTable1k1 = false;
                        }
                    }
                }
                else
                {
                    firstTable1k1 = false;
                    MessageBox.Show("Заполните имя и первичный ключ таблицы", "Ошибка");
                }
            }
            if (oneToMany)
            {
                if (!string.IsNullOrWhiteSpace(((sender as Control).Controls[1] as TextBox).Text) && !string.IsNullOrWhiteSpace(((sender as Control).Controls[3] as TextBox).Text))
                {
                    if (!firstTable1km)
                    {
                        startArrow1km[0] = (sender as Control).Location.X + (sender as Control).Size.Width;
                        startArrow1km[1] = (sender as Control).Location.Y + (sender as Control).Size.Height / 2;
                        firstTable1km = true;
                        firstIdTableBinding = Convert.ToInt32(((sender as Control).Controls[0] as Label).Text);
                    }
                    else
                    {
                        secondIdTableBinding = Convert.ToInt32(((sender as Control).Controls[0] as Label).Text);
                        bool alreadyExists = false;
                        foreach (BindingArrows arrows in bindings) if (arrows.parentTableId == firstIdTableBinding && arrows.childTableId == secondIdTableBinding || arrows.childTableId == firstIdTableBinding && arrows.parentTableId == secondIdTableBinding) alreadyExists = true;
                        if (!alreadyExists)
                        {
                            if (startArrow1km[0] > (sender as Control).Location.X && startArrow1km[0] - (sender as Control).Width < (sender as Control).Location.X + (sender as Control).Width)
                            {
                                startArrow1km[0] -= (sender as Control).Width / 2;
                                endArrow1km[0] = (sender as Control).Location.X + (sender as Control).Width / 2;
                                if (startArrow1km[1] > (sender as Control).Location.Y)
                                {
                                    startArrow1km[1] -= (sender as Control).Height / 2;
                                    endArrow1km[1] = (sender as Control).Location.Y + (sender as Control).Size.Height;
                                }
                                else
                                {
                                    startArrow1km[1] += (sender as Control).Height / 2;
                                    endArrow1km[1] = (sender as Control).Location.Y;
                                }
                            }
                            else if (startArrow1km[0] > (sender as Control).Location.X + (sender as Control).Width * 2)
                            {
                                startArrow1km[0] -= (sender as Control).Width;
                                endArrow1km[0] = (sender as Control).Location.X + (sender as Control).Width;
                                endArrow1km[1] = (sender as Control).Location.Y + (sender as Control).Size.Height / 2;
                            }
                            else
                            {
                                endArrow1km[0] = (sender as Control).Location.X;
                                endArrow1km[1] = (sender as Control).Location.Y + (sender as Control).Size.Height / 2;
                            }
                            Graphics g = panel1.CreateGraphics();
                            Pen pen = new Pen(Color.DarkGreen, 5);
                            pen.EndCap = LineCap.ArrowAnchor;
                            g.DrawLine(pen, startArrow1km[0], startArrow1km[1], endArrow1km[0], endArrow1km[1]);
                            g.Dispose();
                            firstTable1km = false;
                            BindingArrows arrow = new BindingArrows(new Point(startArrow1km[0], startArrow1km[1]), new Point(endArrow1km[0], endArrow1km[1]), false, firstIdTableBinding, secondIdTableBinding);
                            bindings.Add(arrow);
                            tables[secondIdTableBinding].properties.Add(new Property(tables[firstIdTableBinding].pk, "int", "", true, true));
                            tables[secondIdTableBinding].table.Rows.Add(tables[firstIdTableBinding].pk, "int", true, true);
                        }
                        else
                        {
                            MessageBox.Show("Связь уже существует.", "Ошибка");
                            firstTable1km = false;
                        }
                    }
                }
                else
                {
                    firstTable1km = false;
                    MessageBox.Show("Заполните имя и первичный ключ таблицы", "Ошибка");
                }
            }
            if (deleteBinding)
            {
                var c = sender as Control;
                foreach(BindingArrows arrows in bindings)
                {
                    if (!arrows.isOneToOne && (Convert.ToInt32((c.Controls[0] as Label).Text) == arrows.parentTableId || Convert.ToInt32((c.Controls[0] as Label).Text) == arrows.childTableId))
                    {
                        tables[arrows.childTableId].properties.RemoveAll(x => x.IsFk && x.Name.StartsWith(tables[arrows.parentTableId].pk));
                        for (int i = 0; i < tables[arrows.childTableId].table.Rows.Count; i++) if (tables[arrows.childTableId].table.Rows[i].ItemArray[0].ToString().StartsWith(tables[arrows.parentTableId].pk) && Convert.ToBoolean(tables[arrows.childTableId].table.Rows[i].ItemArray[2]) == true)
                            {
                                tables[arrows.childTableId].table.Rows.RemoveAt(i);
                            }
                    }
                }
                bindings.RemoveAll(x => x.childTableId == Convert.ToInt32((c.Controls[0] as Label).Text));
                bindings.RemoveAll(x => x.parentTableId == Convert.ToInt32((c.Controls[0] as Label).Text));
                RefreshOneToOne();
                RepaintAllBindings();
            }

        }
        /// <summary>
        /// Обновление связей один к одному
        /// </summary>
        private void RefreshOneToOne()
        {
            for (int i = 0; i < tables.Count; i++) panel1.Controls[i].Controls[3].Enabled = true;
            foreach (BindingArrows arrows in bindings)
            {
                for (int i = 0; i < tables.Count; i++)
                {
                    if (arrows.childTableId == i && arrows.isOneToOne) panel1.Controls[i].Controls[3].Enabled = false;
                }
            }
        }
        /// <summary>
        /// Добавление нового свойства таблицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newPropertyBtn_Click(object sender, EventArgs e)
        {
            addOrEditProp = true;
            idTableAttributes = Convert.ToInt32(((sender as Control).Parent.Controls[0] as Label).Text);
            AttributeForm form = new AttributeForm();
            form.Owner = this;
            form.Text = $"{((sender as Control).Parent.Controls[1] as TextBox).Text}: столбец";
            form.ShowDialog();
        }

        /// <summary>
        /// Удаление свойства таблицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deletePropertyBtn_Click(object sender, EventArgs e)
        {
            idTableAttributes = Convert.ToInt32(((sender as Control).Parent.Controls[0] as Label).Text);
            if ((panel1.Controls[idTableAttributes].Controls[4] as DataGridView).SelectedRows.Count != 0)
            {
                int rowId = (panel1.Controls[idTableAttributes].Controls[4] as DataGridView).SelectedRows[0].Index;
                if (Convert.ToBoolean((panel1.Controls[idTableAttributes].Controls[4] as DataGridView).SelectedRows[0].Cells[2].Value))
                {
                    bindings.RemoveAll(x => !x.isOneToOne && x.childTableId == idTableAttributes);
                    RepaintAllBindings();
                }
                tables[idTableAttributes].properties.RemoveAt(rowId);
                tables[idTableAttributes].table.Rows.RemoveAt(rowId);
            }
        }
        /// <summary>
        /// Реакция на изменение размера основного окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_SizeChanged(object sender, EventArgs e)
        {
            RepaintAllBindings();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Выбор инструмента добавления новой таблицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newTableBtn_Click(object sender, EventArgs e)
        {
            DesactivateAllInstruments();
            newTableBtn.BackColor = Color.DarkGray;
            create = true;
        }
        /// <summary>
        /// Выбор инструмента построения связи один ко многим
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void binding1kMBtn_Click(object sender, EventArgs e)
        {
            DesactivateAllInstruments();
            binding1kMBtn.BackColor = Color.DarkGray;
            oneToMany = true;
        }
        /// <summary>
        /// Переход к окну генерации скрипта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void generateScriptBtn_Click(object sender, EventArgs e)
        {
            if (tables.Count != 0)
            {
                bool emptyFields = false;
                foreach (Table table in tables) if (string.IsNullOrWhiteSpace(table.name) || string.IsNullOrWhiteSpace(table.pk)) emptyFields = true;
                if (!emptyFields)
                {
                    FormGenerateScript form = new FormGenerateScript();
                    form.Owner = this;
                    form.ShowDialog();
                }
                else MessageBox.Show("Не все наименования таблиц или наименования их первичных ключей заполнены.", "Ошибка");
            }
            else MessageBox.Show("Создайте хотя бы одну таблицу.", "Ошибка");
        }
        /// <summary>
        /// Выбор инструмента удаления связей таблицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteBindingBtn_Click(object sender, EventArgs e)
        {
            DesactivateAllInstruments();
            deleteBindingBtn.BackColor = Color.DarkGray;
            deleteBinding = true;
        }
        /// <summary>
        /// Выбор инструмента удаления таблицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteTableBtn_Click(object sender, EventArgs e)
        {
            DesactivateAllInstruments();
            deleteTableBtn.BackColor = Color.DarkGray;
            delete = true;
        }
        /// <summary>
        /// Выбор инструмента построения связи один к одному
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void binding1k1Btn_Click(object sender, EventArgs e)
        {
            DesactivateAllInstruments();
            binding1k1Btn.BackColor = Color.DarkGray;
            oneToOne = true;
        }
        /// <summary>
        /// Выбор инструмента перетаскивания таблицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            DesactivateAllInstruments();
            dragBtn.BackColor = Color.DarkGray;
            drag = true;
        }
        /// <summary>
        /// Дезактивация всех инструментов
        /// </summary>
        private void DesactivateAllInstruments()
        {
            drag = false;
            create = false;
            delete = false;
            oneToOne = false;
            oneToMany = false;
            deleteBinding = false;
            firstTable1k1 = false;
            firstTable1km = false;
            for(int i = 0; i < instrumentBtns.Length; i++) instrumentBtns[i].BackColor = DefaultBackColor;
        }
    }
}