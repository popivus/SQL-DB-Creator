
namespace SQLDatabaseCreator
{
    partial class AttributeForm
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
            this.typesBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.maxCheck = new System.Windows.Forms.CheckBox();
            this.sizeBox = new System.Windows.Forms.TextBox();
            this.sizeLabel = new System.Windows.Forms.Label();
            this.addBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.notNullBox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // typesBox
            // 
            this.typesBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typesBox.FormattingEnabled = true;
            this.typesBox.Items.AddRange(new object[] {
            "char",
            "varchar",
            "varbinary",
            "int",
            "float",
            "real",
            "money",
            "date",
            "datetime"});
            this.typesBox.Location = new System.Drawing.Point(59, 31);
            this.typesBox.Name = "typesBox";
            this.typesBox.Size = new System.Drawing.Size(212, 21);
            this.typesBox.TabIndex = 0;
            this.typesBox.SelectedIndexChanged += new System.EventHandler(this.typesBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Тип:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Наименование:";
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(104, 6);
            this.nameBox.MaxLength = 50;
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(188, 20);
            this.nameBox.TabIndex = 3;
            this.nameBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nameBox_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.notNullBox);
            this.groupBox1.Controls.Add(this.maxCheck);
            this.groupBox1.Controls.Add(this.sizeBox);
            this.groupBox1.Controls.Add(this.sizeLabel);
            this.groupBox1.Controls.Add(this.typesBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(15, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(277, 140);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Тип данных";
            // 
            // maxCheck
            // 
            this.maxCheck.AutoSize = true;
            this.maxCheck.Location = new System.Drawing.Point(115, 72);
            this.maxCheck.Name = "maxCheck";
            this.maxCheck.Size = new System.Drawing.Size(49, 17);
            this.maxCheck.TabIndex = 4;
            this.maxCheck.Text = "MAX";
            this.maxCheck.UseVisualStyleBackColor = true;
            this.maxCheck.CheckedChanged += new System.EventHandler(this.maxCheck_CheckedChanged);
            // 
            // sizeBox
            // 
            this.sizeBox.Location = new System.Drawing.Point(59, 69);
            this.sizeBox.MaxLength = 5;
            this.sizeBox.Name = "sizeBox";
            this.sizeBox.Size = new System.Drawing.Size(50, 20);
            this.sizeBox.TabIndex = 3;
            this.sizeBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sizeBox_KeyPress);
            // 
            // sizeLabel
            // 
            this.sizeLabel.AutoSize = true;
            this.sizeLabel.Location = new System.Drawing.Point(6, 72);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(49, 13);
            this.sizeLabel.TabIndex = 2;
            this.sizeLabel.Text = "Размер:";
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(217, 178);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 23);
            this.addBtn.TabIndex = 5;
            this.addBtn.Text = "Добавить";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(15, 178);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 6;
            this.cancelBtn.Text = "Отмена";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // notNullBox
            // 
            this.notNullBox.AutoSize = true;
            this.notNullBox.Location = new System.Drawing.Point(59, 105);
            this.notNullBox.Name = "notNullBox";
            this.notNullBox.Size = new System.Drawing.Size(61, 17);
            this.notNullBox.TabIndex = 5;
            this.notNullBox.Text = "Не Null";
            this.notNullBox.UseVisualStyleBackColor = true;
            // 
            // AttributeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 215);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.label2);
            this.MaximumSize = new System.Drawing.Size(323, 254);
            this.MinimumSize = new System.Drawing.Size(323, 254);
            this.Name = "AttributeForm";
            this.Text = "AttributeForm";
            this.Load += new System.EventHandler(this.AttributeForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox typesBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox maxCheck;
        private System.Windows.Forms.TextBox sizeBox;
        private System.Windows.Forms.Label sizeLabel;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.CheckBox notNullBox;
    }
}