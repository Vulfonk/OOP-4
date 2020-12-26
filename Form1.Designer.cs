namespace OOP_4
{
    partial class Form1
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.SelectionMode_checkBox = new System.Windows.Forms.CheckBox();
            this.Shape_comboBox = new System.Windows.Forms.ComboBox();
            this.Menu_panel = new System.Windows.Forms.Panel();
            this.Color_label = new System.Windows.Forms.Label();
            this.Color_comboBox = new System.Windows.Forms.ComboBox();
            this.Shape_label = new System.Windows.Forms.Label();
            this.Clear_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.Menu_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(870, 573);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseClick);
            // 
            // SelectionMode_checkBox
            // 
            this.SelectionMode_checkBox.AutoSize = true;
            this.SelectionMode_checkBox.Location = new System.Drawing.Point(12, 615);
            this.SelectionMode_checkBox.Name = "SelectionMode_checkBox";
            this.SelectionMode_checkBox.Size = new System.Drawing.Size(120, 17);
            this.SelectionMode_checkBox.TabIndex = 3;
            this.SelectionMode_checkBox.Text = "Режим выделения";
            this.SelectionMode_checkBox.UseVisualStyleBackColor = true;
            // 
            // Shape_comboBox
            // 
            this.Shape_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Shape_comboBox.FormattingEnabled = true;
            this.Shape_comboBox.Items.AddRange(new object[] {
            "Круг",
            "Квадрат",
            "Треугольник",
            "Отрезок"});
            this.Shape_comboBox.Location = new System.Drawing.Point(115, 13);
            this.Shape_comboBox.Name = "Shape_comboBox";
            this.Shape_comboBox.Size = new System.Drawing.Size(169, 21);
            this.Shape_comboBox.TabIndex = 4;
            // 
            // Menu_panel
            // 
            this.Menu_panel.Controls.Add(this.Clear_button);
            this.Menu_panel.Controls.Add(this.Color_label);
            this.Menu_panel.Controls.Add(this.Color_comboBox);
            this.Menu_panel.Controls.Add(this.Shape_label);
            this.Menu_panel.Controls.Add(this.Shape_comboBox);
            this.Menu_panel.Location = new System.Drawing.Point(899, 12);
            this.Menu_panel.Name = "Menu_panel";
            this.Menu_panel.Size = new System.Drawing.Size(287, 573);
            this.Menu_panel.TabIndex = 5;
            // 
            // Color_label
            // 
            this.Color_label.AutoSize = true;
            this.Color_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.Color_label.Location = new System.Drawing.Point(13, 59);
            this.Color_label.Name = "Color_label";
            this.Color_label.Size = new System.Drawing.Size(42, 18);
            this.Color_label.TabIndex = 7;
            this.Color_label.Text = "Цвет";
            // 
            // Color_comboBox
            // 
            this.Color_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Color_comboBox.FormattingEnabled = true;
            this.Color_comboBox.Location = new System.Drawing.Point(115, 59);
            this.Color_comboBox.Name = "Color_comboBox";
            this.Color_comboBox.Size = new System.Drawing.Size(169, 21);
            this.Color_comboBox.TabIndex = 6;
            // 
            // Shape_label
            // 
            this.Shape_label.AutoSize = true;
            this.Shape_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.Shape_label.Location = new System.Drawing.Point(13, 13);
            this.Shape_label.Name = "Shape_label";
            this.Shape_label.Size = new System.Drawing.Size(58, 18);
            this.Shape_label.TabIndex = 5;
            this.Shape_label.Text = "Фигура";
            // 
            // Clear_button
            // 
            this.Clear_button.Location = new System.Drawing.Point(3, 547);
            this.Clear_button.Name = "Clear_button";
            this.Clear_button.Size = new System.Drawing.Size(75, 23);
            this.Clear_button.TabIndex = 8;
            this.Clear_button.Text = "Очистить";
            this.Clear_button.UseVisualStyleBackColor = true;
            this.Clear_button.Click += new System.EventHandler(this.clear_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 678);
            this.Controls.Add(this.Menu_panel);
            this.Controls.Add(this.SelectionMode_checkBox);
            this.Controls.Add(this.pictureBox);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.Menu_panel.ResumeLayout(false);
            this.Menu_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.CheckBox SelectionMode_checkBox;
        private System.Windows.Forms.ComboBox Shape_comboBox;
        private System.Windows.Forms.Panel Menu_panel;
        private System.Windows.Forms.Label Color_label;
        private System.Windows.Forms.ComboBox Color_comboBox;
        private System.Windows.Forms.Label Shape_label;
        private System.Windows.Forms.Button Clear_button;
    }
}

