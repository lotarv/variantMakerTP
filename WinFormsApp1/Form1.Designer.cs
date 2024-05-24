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
            configBtn = new Button();
            generateBtn = new Button();
            label2 = new Label();
            amountInput = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 39);
            label1.Name = "label1";
            label1.Size = new Size(222, 37);
            label1.TabIndex = 0;
            label1.Text = "Выберите главы:";
            // 
            // chapter1Check
            // 
            chapter1Check.AutoSize = true;
            chapter1Check.Checked = true;
            chapter1Check.CheckState = CheckState.Checked;
            chapter1Check.Location = new Point(24, 89);
            chapter1Check.Name = "chapter1Check";
            chapter1Check.Size = new Size(354, 41);
            chapter1Check.TabIndex = 1;
            chapter1Check.Text = "Глава 1 - Комбинаторика";
            chapter1Check.UseVisualStyleBackColor = true;
            // 
            // chapter2Check
            // 
            chapter2Check.AutoSize = true;
            chapter2Check.Checked = true;
            chapter2Check.CheckState = CheckState.Checked;
            chapter2Check.Location = new Point(24, 147);
            chapter2Check.Name = "chapter2Check";
            chapter2Check.Size = new Size(404, 41);
            chapter2Check.TabIndex = 2;
            chapter2Check.Text = "Глава 2 - Случайные события";
            chapter2Check.UseVisualStyleBackColor = true;
            // 
            // chapter3Check
            // 
            chapter3Check.AutoSize = true;
            chapter3Check.Checked = true;
            chapter3Check.CheckState = CheckState.Checked;
            chapter3Check.Location = new Point(24, 204);
            chapter3Check.Name = "chapter3Check";
            chapter3Check.Size = new Size(769, 41);
            chapter3Check.TabIndex = 3;
            chapter3Check.Text = "Глава 3 - Формула полной вероятности и формулы Байеса";
            chapter3Check.UseVisualStyleBackColor = true;
            // 
            // chapter4Check
            // 
            chapter4Check.AutoSize = true;
            chapter4Check.Checked = true;
            chapter4Check.CheckState = CheckState.Checked;
            chapter4Check.Location = new Point(24, 261);
            chapter4Check.Name = "chapter4Check";
            chapter4Check.Size = new Size(356, 41);
            chapter4Check.TabIndex = 4;
            chapter4Check.Text = "Глава 4 - Схема Бернулли";
            chapter4Check.UseVisualStyleBackColor = true;
            // 
            // chapter5Check
            // 
            chapter5Check.AutoSize = true;
            chapter5Check.Checked = true;
            chapter5Check.CheckState = CheckState.Checked;
            chapter5Check.Location = new Point(24, 318);
            chapter5Check.Name = "chapter5Check";
            chapter5Check.Size = new Size(576, 41);
            chapter5Check.TabIndex = 5;
            chapter5Check.Text = "Глава 5 - Дискретные случайные величины";
            chapter5Check.UseVisualStyleBackColor = true;
            // 
            // chapter7Check
            // 
            chapter7Check.AutoSize = true;
            chapter7Check.Checked = true;
            chapter7Check.CheckState = CheckState.Checked;
            chapter7Check.Location = new Point(24, 373);
            chapter7Check.Name = "chapter7Check";
            chapter7Check.Size = new Size(1026, 41);
            chapter7Check.TabIndex = 6;
            chapter7Check.Text = "Глава 7 - Важнейшие законы распределения непрерывных случайных величин";
            chapter7Check.UseVisualStyleBackColor = true;
            // 
            // configBtn
            // 
            configBtn.Cursor = Cursors.Hand;
            configBtn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            configBtn.Location = new Point(24, 439);
            configBtn.Name = "configBtn";
            configBtn.Size = new Size(274, 61);
            configBtn.TabIndex = 7;
            configBtn.Text = "Перейти к настройке глав";
            configBtn.UseVisualStyleBackColor = true;
            configBtn.Click += configBtn_Click;
            // 
            // generateBtn
            // 
            generateBtn.Cursor = Cursors.Hand;
            generateBtn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            generateBtn.Location = new Point(724, 439);
            generateBtn.Name = "generateBtn";
            generateBtn.Size = new Size(274, 61);
            generateBtn.TabIndex = 8;
            generateBtn.Text = "Генерация задач\r\n";
            generateBtn.UseVisualStyleBackColor = true;
            generateBtn.Click += generateBtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(332, 449);
            label2.Name = "label2";
            label2.Size = new Size(167, 37);
            label2.TabIndex = 9;
            label2.Text = "Количество:";
            // 
            // amountInput
            // 
            amountInput.Location = new Point(505, 449);
            amountInput.Name = "amountInput";
            amountInput.Size = new Size(125, 42);
            amountInput.TabIndex = 10;
            amountInput.Text = "1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(14F, 36F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1119, 637);
            Controls.Add(amountInput);
            Controls.Add(label2);
            Controls.Add(generateBtn);
            Controls.Add(configBtn);
            Controls.Add(chapter7Check);
            Controls.Add(chapter5Check);
            Controls.Add(chapter4Check);
            Controls.Add(chapter3Check);
            Controls.Add(chapter2Check);
            Controls.Add(chapter1Check);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
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
        private Button configBtn;
        private Button generateBtn;
        private Label label2;
        private TextBox amountInput;
    }
}
