namespace WindowsFormsControls
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
            this.button1 = new System.Windows.Forms.Button();
            this.hoverButton1 = new WindowsFormsControls.HoverButton();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(642, 392);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // hoverButton1
            // 
            this.hoverButton1.ClickColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.hoverButton1.Color = System.Drawing.Color.Teal;
            this.hoverButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hoverButton1.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoverButton1.ForeColor = System.Drawing.Color.White;
            this.hoverButton1.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(140)))));
            this.hoverButton1.Location = new System.Drawing.Point(650, 400);
            this.hoverButton1.Name = "hoverButton1";
            this.hoverButton1.Size = new System.Drawing.Size(31, 24);
            this.hoverButton1.TabIndex = 1;
            this.hoverButton1.Text = "hoverButton1";
            this.hoverButton1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.hoverButton1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private HoverButton hoverButton1;
    }
}

