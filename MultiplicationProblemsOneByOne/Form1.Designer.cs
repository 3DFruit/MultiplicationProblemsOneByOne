namespace MultiplicationProblemsOneByOne
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonNext = new System.Windows.Forms.Button();
            this.labelOutput = new System.Windows.Forms.Label();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.difficultiesGroupBox = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.richTextBoxProgress = new System.Windows.Forms.RichTextBox();
            this.difficultiesGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonNext
            // 
            this.buttonNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonNext.Location = new System.Drawing.Point(10, 78);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(158, 34);
            this.buttonNext.TabIndex = 9;
            this.buttonNext.TabStop = false;
            this.buttonNext.Text = "Дальше";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // labelOutput
            // 
            this.labelOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelOutput.Location = new System.Drawing.Point(10, 10);
            this.labelOutput.Name = "labelOutput";
            this.labelOutput.Size = new System.Drawing.Size(221, 27);
            this.labelOutput.TabIndex = 7;
            this.labelOutput.Text = "Умножение столбиком";
            // 
            // buttonCheck
            // 
            this.buttonCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCheck.Location = new System.Drawing.Point(10, 40);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(158, 35);
            this.buttonCheck.TabIndex = 8;
            this.buttonCheck.TabStop = false;
            this.buttonCheck.Text = "Проверить";
            this.buttonCheck.UseVisualStyleBackColor = true;
            this.buttonCheck.Click += new System.EventHandler(this.buttonCheck_Click);
            // 
            // difficultiesGroupBox
            // 
            this.difficultiesGroupBox.Controls.Add(this.radioButton3);
            this.difficultiesGroupBox.Controls.Add(this.radioButton2);
            this.difficultiesGroupBox.Controls.Add(this.radioButton1);
            this.difficultiesGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.difficultiesGroupBox.Location = new System.Drawing.Point(13, 118);
            this.difficultiesGroupBox.Name = "difficultiesGroupBox";
            this.difficultiesGroupBox.Size = new System.Drawing.Size(155, 115);
            this.difficultiesGroupBox.TabIndex = 10;
            this.difficultiesGroupBox.TabStop = false;
            this.difficultiesGroupBox.Text = "Сложность";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(6, 82);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(140, 21);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "Четырехзначные";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 55);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(114, 21);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Трёхзначные";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 28);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(108, 21);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "Двузначные";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.SystemColors.Control;
            this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainPanel.Location = new System.Drawing.Point(181, 40);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(128, 193);
            this.mainPanel.TabIndex = 11;
            // 
            // richTextBoxProgress
            // 
            this.richTextBoxProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxProgress.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBoxProgress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxProgress.Enabled = false;
            this.richTextBoxProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxProgress.ForeColor = System.Drawing.Color.Red;
            this.richTextBoxProgress.Location = new System.Drawing.Point(10, 239);
            this.richTextBoxProgress.Name = "richTextBoxProgress";
            this.richTextBoxProgress.ReadOnly = true;
            this.richTextBoxProgress.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBoxProgress.Size = new System.Drawing.Size(304, 14);
            this.richTextBoxProgress.TabIndex = 12;
            this.richTextBoxProgress.TabStop = false;
            this.richTextBoxProgress.Text = "* * * * * * * *";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 251);
            this.Controls.Add(this.richTextBoxProgress);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.buttonCheck);
            this.Controls.Add(this.difficultiesGroupBox);
            this.Controls.Add(this.labelOutput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(335, 290);
            this.MinimumSize = new System.Drawing.Size(335, 290);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "Умножение";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.difficultiesGroupBox.ResumeLayout(false);
            this.difficultiesGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Label labelOutput;
        private System.Windows.Forms.Button buttonCheck;
        private System.Windows.Forms.GroupBox difficultiesGroupBox;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.RichTextBox richTextBoxProgress;
    }
}

