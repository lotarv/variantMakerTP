namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            chapter1Check = new CheckBox();
            chapter2Check = new CheckBox();
            chapter3Check = new CheckBox();
            chapter4Check = new CheckBox();
            chapter5Check = new CheckBox();
            chapter7Check = new CheckBox();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 39);
            label1.Name = "label1";
            label1.Size = new Size(174, 30);
            label1.TabIndex = 0;
            label1.Text = "Выберите главы:";
            // 
            // chapter1Check
            // 
            chapter1Check.AutoSize = true;
            chapter1Check.Location = new Point(24, 89);
            chapter1Check.Name = "chapter1Check";
            chapter1Check.Size = new Size(275, 34);
            chapter1Check.TabIndex = 1;
            chapter1Check.Text = "Глава 1 - Комбинаторика";
            chapter1Check.UseVisualStyleBackColor = true;
            // 
            // chapter2Check
            // 
            chapter2Check.AutoSize = true;
            chapter2Check.Location = new Point(24, 147);
            chapter2Check.Name = "chapter2Check";
            chapter2Check.Size = new Size(317, 34);
            chapter2Check.TabIndex = 2;
            chapter2Check.Text = "Глава 2 - Случайные события";
            chapter2Check.UseVisualStyleBackColor = true;
            // 
            // chapter3Check
            // 
            chapter3Check.AutoSize = true;
            chapter3Check.Location = new Point(24, 204);
            chapter3Check.Name = "chapter3Check";
            chapter3Check.Size = new Size(599, 34);
            chapter3Check.TabIndex = 3;
            chapter3Check.Text = "Глава 3 - Формула полной вероятности и формулы Байеса";
            chapter3Check.UseVisualStyleBackColor = true;
            // 
            // chapter4Check
            // 
            chapter4Check.AutoSize = true;
            chapter4Check.Location = new Point(24, 261);
            chapter4Check.Name = "chapter4Check";
            chapter4Check.Size = new Size(280, 34);
            chapter4Check.TabIndex = 4;
            chapter4Check.Text = "Глава 4 - Схема Бернулли";
            chapter4Check.UseVisualStyleBackColor = true;
            // 
            // chapter5Check
            // 
            chapter5Check.AutoSize = true;
            chapter5Check.Location = new Point(24, 318);
            chapter5Check.Name = "chapter5Check";
            chapter5Check.Size = new Size(452, 34);
            chapter5Check.TabIndex = 5;
            chapter5Check.Text = "Глава 5 - Дискретные случайные величины";
            chapter5Check.UseVisualStyleBackColor = true;
            // 
            // chapter7Check
            // 
            chapter7Check.AutoSize = true;
            chapter7Check.Location = new Point(24, 373);
            chapter7Check.Name = "chapter7Check";
            chapter7Check.Size = new Size(800, 34);
            chapter7Check.TabIndex = 6;
            chapter7Check.Text = "Глава 7 - Важнейшие законы распределения непрерывных случайных величин";
            chapter7Check.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(67, 439);
            button1.Name = "button1";
            button1.Size = new Size(274, 61);
            button1.TabIndex = 7;
            button1.Text = "Перейти к настройке глав";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(456, 439);
            button2.Name = "button2";
            button2.Size = new Size(274, 61);
            button2.TabIndex = 8;
            button2.Text = "Генерация задач\r\n";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(909, 637);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(chapter7Check);
            Controls.Add(chapter5Check);
            Controls.Add(chapter4Check);
            Controls.Add(chapter3Check);
            Controls.Add(chapter2Check);
            Controls.Add(chapter1Check);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(5, 6, 5, 6);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private CheckBox chapter1Check;
        private CheckBox chapter2Check;
        private CheckBox chapter3Check;
        private CheckBox chapter4Check;
        private CheckBox chapter5Check;
        private CheckBox chapter7Check;
        private Button button1;
        private Button button2;
    }
}
