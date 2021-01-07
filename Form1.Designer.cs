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
            this.ungrouping_button = new System.Windows.Forms.Button();
            this.grouping_button = new System.Windows.Forms.Button();
            this.reverse_selected_button = new System.Windows.Forms.Button();
            this.Clear_button = new System.Windows.Forms.Button();
            this.Color_label = new System.Windows.Forms.Label();
            this.Color_comboBox = new System.Windows.Forms.ComboBox();
            this.Shape_label = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.Menu_panel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox.Location = new System.Drawing.Point(12, 49);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(870, 536);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseClick);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
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
            this.Menu_panel.Controls.Add(this.ungrouping_button);
            this.Menu_panel.Controls.Add(this.grouping_button);
            this.Menu_panel.Controls.Add(this.reverse_selected_button);
            this.Menu_panel.Controls.Add(this.Clear_button);
            this.Menu_panel.Controls.Add(this.Color_label);
            this.Menu_panel.Controls.Add(this.Color_comboBox);
            this.Menu_panel.Controls.Add(this.Shape_label);
            this.Menu_panel.Controls.Add(this.Shape_comboBox);
            this.Menu_panel.Location = new System.Drawing.Point(899, 49);
            this.Menu_panel.Name = "Menu_panel";
            this.Menu_panel.Size = new System.Drawing.Size(287, 536);
            this.Menu_panel.TabIndex = 5;
            this.Menu_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.Menu_panel_Paint);
            // 
            // ungrouping_button
            // 
            this.ungrouping_button.Location = new System.Drawing.Point(3, 429);
            this.ungrouping_button.Name = "ungrouping_button";
            this.ungrouping_button.Size = new System.Drawing.Size(101, 23);
            this.ungrouping_button.TabIndex = 11;
            this.ungrouping_button.Text = "Разгруппировать";
            this.ungrouping_button.UseVisualStyleBackColor = true;
            this.ungrouping_button.Click += new System.EventHandler(this.ungrouping_button_Click);
            // 
            // grouping_button
            // 
            this.grouping_button.Location = new System.Drawing.Point(3, 400);
            this.grouping_button.Name = "grouping_button";
            this.grouping_button.Size = new System.Drawing.Size(101, 23);
            this.grouping_button.TabIndex = 10;
            this.grouping_button.Text = "Сгруппировать";
            this.grouping_button.UseVisualStyleBackColor = true;
            this.grouping_button.Click += new System.EventHandler(this.grouping_button_Click);
            // 
            // reverse_selected_button
            // 
            this.reverse_selected_button.Location = new System.Drawing.Point(127, 414);
            this.reverse_selected_button.Name = "reverse_selected_button";
            this.reverse_selected_button.Size = new System.Drawing.Size(157, 52);
            this.reverse_selected_button.TabIndex = 9;
            this.reverse_selected_button.Text = "Выделить не выделенное не выделив выделенное";
            this.reverse_selected_button.UseVisualStyleBackColor = true;
            this.reverse_selected_button.Click += new System.EventHandler(this.reverse_selected_button_Click);
            // 
            // Clear_button
            // 
            this.Clear_button.Location = new System.Drawing.Point(3, 458);
            this.Clear_button.Name = "Clear_button";
            this.Clear_button.Size = new System.Drawing.Size(101, 23);
            this.Clear_button.TabIndex = 8;
            this.Clear_button.Text = "Очистить";
            this.Clear_button.UseVisualStyleBackColor = true;
            this.Clear_button.Click += new System.EventHandler(this.clear_button_Click);
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
            this.Color_comboBox.SelectedIndexChanged += new System.EventHandler(this.Color_comboBox_SelectedIndexChanged);
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
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1198, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.сохранитьКакToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // сохранитьКакToolStripMenuItem
            // 
            this.сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            this.сохранитьКакToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.сохранитьКакToolStripMenuItem.Text = "Сохранить как...";
            this.сохранитьКакToolStripMenuItem.Click += new System.EventHandler(this.сохранитьКакToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 678);
            this.Controls.Add(this.Menu_panel);
            this.Controls.Add(this.SelectionMode_checkBox);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Новый Рисунок";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.Menu_panel.ResumeLayout(false);
            this.Menu_panel.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.Button reverse_selected_button;
        private System.Windows.Forms.Button grouping_button;
        private System.Windows.Forms.Button ungrouping_button;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
    }
}

