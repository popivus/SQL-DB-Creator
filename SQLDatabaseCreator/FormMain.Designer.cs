
namespace SQLDatabaseCreator
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.newTableBtn = new System.Windows.Forms.Button();
            this.deleteTableBtn = new System.Windows.Forms.Button();
            this.dragBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.deleteBindingBtn = new System.Windows.Forms.Button();
            this.binding1k1Btn = new System.Windows.Forms.Button();
            this.binding1kMBtn = new System.Windows.Forms.Button();
            this.generateScriptBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(12, 78);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1102, 523);
            this.panel1.TabIndex = 0;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // newTableBtn
            // 
            this.newTableBtn.Location = new System.Drawing.Point(6, 19);
            this.newTableBtn.Name = "newTableBtn";
            this.newTableBtn.Size = new System.Drawing.Size(75, 35);
            this.newTableBtn.TabIndex = 1;
            this.newTableBtn.Text = "Новая таблица";
            this.newTableBtn.UseVisualStyleBackColor = true;
            this.newTableBtn.Click += new System.EventHandler(this.newTableBtn_Click);
            // 
            // deleteTableBtn
            // 
            this.deleteTableBtn.Location = new System.Drawing.Point(87, 19);
            this.deleteTableBtn.Name = "deleteTableBtn";
            this.deleteTableBtn.Size = new System.Drawing.Size(75, 35);
            this.deleteTableBtn.TabIndex = 2;
            this.deleteTableBtn.Text = "Удалить таблицу";
            this.deleteTableBtn.UseVisualStyleBackColor = true;
            this.deleteTableBtn.Click += new System.EventHandler(this.deleteTableBtn_Click);
            // 
            // dragBtn
            // 
            this.dragBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dragBtn.Location = new System.Drawing.Point(12, 30);
            this.dragBtn.Name = "dragBtn";
            this.dragBtn.Size = new System.Drawing.Size(75, 35);
            this.dragBtn.TabIndex = 3;
            this.dragBtn.Text = "Перетаскивание";
            this.dragBtn.UseVisualStyleBackColor = false;
            this.dragBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.newTableBtn);
            this.groupBox1.Controls.Add(this.deleteTableBtn);
            this.groupBox1.Location = new System.Drawing.Point(93, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(170, 61);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Таблицы";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.deleteBindingBtn);
            this.groupBox2.Controls.Add(this.binding1k1Btn);
            this.groupBox2.Controls.Add(this.binding1kMBtn);
            this.groupBox2.Location = new System.Drawing.Point(269, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(251, 61);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Связи";
            // 
            // deleteBindingBtn
            // 
            this.deleteBindingBtn.ForeColor = System.Drawing.Color.Black;
            this.deleteBindingBtn.Location = new System.Drawing.Point(168, 19);
            this.deleteBindingBtn.Name = "deleteBindingBtn";
            this.deleteBindingBtn.Size = new System.Drawing.Size(75, 35);
            this.deleteBindingBtn.TabIndex = 3;
            this.deleteBindingBtn.Text = "Удалить связи";
            this.deleteBindingBtn.UseVisualStyleBackColor = true;
            this.deleteBindingBtn.Click += new System.EventHandler(this.deleteBindingBtn_Click);
            // 
            // binding1k1Btn
            // 
            this.binding1k1Btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.binding1k1Btn.Location = new System.Drawing.Point(6, 19);
            this.binding1k1Btn.Name = "binding1k1Btn";
            this.binding1k1Btn.Size = new System.Drawing.Size(75, 35);
            this.binding1k1Btn.TabIndex = 1;
            this.binding1k1Btn.Text = "1 к 1";
            this.binding1k1Btn.UseVisualStyleBackColor = true;
            this.binding1k1Btn.Click += new System.EventHandler(this.binding1k1Btn_Click);
            // 
            // binding1kMBtn
            // 
            this.binding1kMBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.binding1kMBtn.Location = new System.Drawing.Point(87, 19);
            this.binding1kMBtn.Name = "binding1kMBtn";
            this.binding1kMBtn.Size = new System.Drawing.Size(75, 35);
            this.binding1kMBtn.TabIndex = 2;
            this.binding1kMBtn.Text = "1 к М";
            this.binding1kMBtn.UseVisualStyleBackColor = true;
            this.binding1kMBtn.Click += new System.EventHandler(this.binding1kMBtn_Click);
            // 
            // generateScriptBtn
            // 
            this.generateScriptBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.generateScriptBtn.Location = new System.Drawing.Point(983, 30);
            this.generateScriptBtn.Name = "generateScriptBtn";
            this.generateScriptBtn.Size = new System.Drawing.Size(131, 35);
            this.generateScriptBtn.TabIndex = 6;
            this.generateScriptBtn.Text = "Сгенерировать скрипт";
            this.generateScriptBtn.UseVisualStyleBackColor = true;
            this.generateScriptBtn.Click += new System.EventHandler(this.generateScriptBtn_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 613);
            this.Controls.Add(this.generateScriptBtn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dragBtn);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(1142, 652);
            this.Name = "FormMain";
            this.Text = "Модель данных";
            this.SizeChanged += new System.EventHandler(this.FormMain_SizeChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button newTableBtn;
        private System.Windows.Forms.Button deleteTableBtn;
        private System.Windows.Forms.Button dragBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button binding1k1Btn;
        private System.Windows.Forms.Button binding1kMBtn;
        private System.Windows.Forms.Button deleteBindingBtn;
        private System.Windows.Forms.Button generateScriptBtn;
        public System.Windows.Forms.Panel panel1;
    }
}

