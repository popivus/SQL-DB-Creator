
namespace SQLDatabaseCreator
{
    partial class FormGenerateScript
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dbNameBox = new System.Windows.Forms.TextBox();
            this.autoincrementBox = new System.Windows.Forms.CheckBox();
            this.createScriptSql = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Наименование базы данных:";
            // 
            // dbNameBox
            // 
            this.dbNameBox.Location = new System.Drawing.Point(173, 40);
            this.dbNameBox.MaxLength = 50;
            this.dbNameBox.Name = "dbNameBox";
            this.dbNameBox.Size = new System.Drawing.Size(241, 20);
            this.dbNameBox.TabIndex = 1;
            this.dbNameBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // autoincrementBox
            // 
            this.autoincrementBox.AutoSize = true;
            this.autoincrementBox.Location = new System.Drawing.Point(92, 78);
            this.autoincrementBox.Name = "autoincrementBox";
            this.autoincrementBox.Size = new System.Drawing.Size(259, 17);
            this.autoincrementBox.TabIndex = 2;
            this.autoincrementBox.Text = "Добавить автоинкременцию ID полям таблиц";
            this.autoincrementBox.UseVisualStyleBackColor = true;
            // 
            // createScriptSql
            // 
            this.createScriptSql.Location = new System.Drawing.Point(154, 128);
            this.createScriptSql.Name = "createScriptSql";
            this.createScriptSql.Size = new System.Drawing.Size(126, 23);
            this.createScriptSql.TabIndex = 3;
            this.createScriptSql.Text = "Создать скрипт";
            this.createScriptSql.UseVisualStyleBackColor = true;
            this.createScriptSql.Click += new System.EventHandler(this.createScriptSql_Click);
            // 
            // FormGenerateScript
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 185);
            this.Controls.Add(this.createScriptSql);
            this.Controls.Add(this.autoincrementBox);
            this.Controls.Add(this.dbNameBox);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(452, 224);
            this.MinimumSize = new System.Drawing.Size(452, 224);
            this.Name = "FormGenerateScript";
            this.Text = "Генерация скрипта";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox dbNameBox;
        private System.Windows.Forms.CheckBox autoincrementBox;
        private System.Windows.Forms.Button createScriptSql;
    }
}