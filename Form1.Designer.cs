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
            this.dataGridViewShapes = new System.Windows.Forms.DataGridView();
            this.buttonShowShapes = new System.Windows.Forms.Button();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShapes)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(451, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(735, 654);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseClick);
            // 
            // dataGridViewShapes
            // 
            this.dataGridViewShapes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewShapes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.X,
            this.Y});
            this.dataGridViewShapes.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewShapes.Name = "dataGridViewShapes";
            this.dataGridViewShapes.Size = new System.Drawing.Size(419, 625);
            this.dataGridViewShapes.TabIndex = 1;
            // 
            // buttonShowShapes
            // 
            this.buttonShowShapes.Location = new System.Drawing.Point(343, 643);
            this.buttonShowShapes.Name = "buttonShowShapes";
            this.buttonShowShapes.Size = new System.Drawing.Size(75, 23);
            this.buttonShowShapes.TabIndex = 2;
            this.buttonShowShapes.Text = "Show";
            this.buttonShowShapes.UseVisualStyleBackColor = true;
            this.buttonShowShapes.Click += new System.EventHandler(this.buttonShowShapes_Click);
            // 
            // X
            // 
            this.X.HeaderText = "X";
            this.X.Name = "X";
            // 
            // Y
            // 
            this.Y.HeaderText = "Y";
            this.Y.Name = "Y";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 678);
            this.Controls.Add(this.buttonShowShapes);
            this.Controls.Add(this.dataGridViewShapes);
            this.Controls.Add(this.pictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShapes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.DataGridView dataGridViewShapes;
        private System.Windows.Forms.Button buttonShowShapes;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
    }
}

