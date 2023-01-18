using Drawing.Properties;

namespace Drawing
{
    partial class Julia
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.statusLabel = new System.Windows.Forms.Label();
            this.undoButton = new System.Windows.Forms.Button();
            this.generatePatternButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.zoomCheckbox = new System.Windows.Forms.CheckBox();
            this.iterationCountTextBox = new System.Windows.Forms.TextBox();
            this.xMaxCheckBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.xMinCheckBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.yMinCheckBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.yMaxCheckBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.statusLabel);
            this.groupBox1.Controls.Add(this.undoButton);
            this.groupBox1.Controls.Add(this.generatePatternButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.zoomCheckbox);
            this.groupBox1.Controls.Add(this.iterationCountTextBox);
            this.groupBox1.Controls.Add(this.xMaxCheckBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.xMinCheckBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.yMinCheckBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.yMaxCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(862, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(144, 352);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuration";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(20, 321);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(78, 17);
            this.radioButton2.TabIndex = 26;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Line by line";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(20, 298);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(72, 17);
            this.radioButton1.TabIndex = 25;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Full image";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(10, 273);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(40, 13);
            this.statusLabel.TabIndex = 24;
            this.statusLabel.Text = "Status:";
            // 
            // undoButton
            // 
            this.undoButton.BackColor = System.Drawing.Color.Transparent;
            this.undoButton.BackgroundImage = global::Drawing.Properties.Resources.undo_4_xxl;
            this.undoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.undoButton.ImageKey = "(none)";
            this.undoButton.Location = new System.Drawing.Point(9, 205);
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(41, 41);
            this.undoButton.TabIndex = 23;
            this.undoButton.UseVisualStyleBackColor = false;
            this.undoButton.Click += new System.EventHandler(this.undo_Click);
            // 
            // generatePatternButton
            // 
            this.generatePatternButton.BackColor = System.Drawing.SystemColors.Control;
            this.generatePatternButton.Location = new System.Drawing.Point(56, 205);
            this.generatePatternButton.Name = "generatePatternButton";
            this.generatePatternButton.Size = new System.Drawing.Size(81, 57);
            this.generatePatternButton.TabIndex = 0;
            this.generatePatternButton.Text = "Generate Pattern";
            this.generatePatternButton.UseVisualStyleBackColor = false;
            this.generatePatternButton.Click += new System.EventHandler(this.generate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Iterations";
            // 
            // zoomCheckbox
            // 
            this.zoomCheckbox.AutoSize = true;
            this.zoomCheckbox.Location = new System.Drawing.Point(14, 182);
            this.zoomCheckbox.Name = "zoomCheckbox";
            this.zoomCheckbox.Size = new System.Drawing.Size(53, 17);
            this.zoomCheckbox.TabIndex = 15;
            this.zoomCheckbox.Text = "Zoom";
            this.zoomCheckbox.UseVisualStyleBackColor = true;
            // 
            // iterationCountTextBox
            // 
            this.iterationCountTextBox.Location = new System.Drawing.Point(18, 41);
            this.iterationCountTextBox.Name = "iterationCountTextBox";
            this.iterationCountTextBox.Size = new System.Drawing.Size(103, 20);
            this.iterationCountTextBox.TabIndex = 5;
            this.iterationCountTextBox.Text = "85";
            // 
            // xMaxCheckBox
            // 
            this.xMaxCheckBox.Location = new System.Drawing.Point(72, 143);
            this.xMaxCheckBox.Name = "xMaxCheckBox";
            this.xMaxCheckBox.Size = new System.Drawing.Size(56, 20);
            this.xMaxCheckBox.TabIndex = 14;
            this.xMaxCheckBox.Text = "1.7";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "yMin";
            // 
            // xMinCheckBox
            // 
            this.xMinCheckBox.Location = new System.Drawing.Point(13, 143);
            this.xMinCheckBox.Name = "xMinCheckBox";
            this.xMinCheckBox.Size = new System.Drawing.Size(56, 20);
            this.xMinCheckBox.TabIndex = 13;
            this.xMinCheckBox.Text = "-1.7";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "yMax";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(73, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "xMax";
            // 
            // yMinCheckBox
            // 
            this.yMinCheckBox.Location = new System.Drawing.Point(13, 94);
            this.yMinCheckBox.Name = "yMinCheckBox";
            this.yMinCheckBox.Size = new System.Drawing.Size(56, 20);
            this.yMinCheckBox.TabIndex = 9;
            this.yMinCheckBox.Text = "-1.2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "xMin";
            // 
            // yMaxCheckBox
            // 
            this.yMaxCheckBox.Location = new System.Drawing.Point(72, 94);
            this.yMaxCheckBox.Name = "yMaxCheckBox";
            this.yMaxCheckBox.Size = new System.Drawing.Size(56, 20);
            this.yMaxCheckBox.TabIndex = 10;
            this.yMaxCheckBox.Text = "1.2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(796, 329);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 16);
            this.label1.TabIndex = 21;
            this.label1.Text = "1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(518, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 16);
            this.label7.TabIndex = 22;
            this.label7.Text = "1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(518, 659);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 16);
            this.label8.TabIndex = 23;
            this.label8.Text = "-1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(203, 330);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 16);
            this.label9.TabIndex = 24;
            this.label9.Text = "-1";
            // 
            // Julia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 722);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Julia";
            this.Text = "Julia";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Julia_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseClickOnForm);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseUpOnForm);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label statusLabel;
        public System.Windows.Forms.Button undoButton;
        public System.Windows.Forms.Button generatePatternButton;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.CheckBox zoomCheckbox;
        public System.Windows.Forms.TextBox iterationCountTextBox;
        public System.Windows.Forms.TextBox xMaxCheckBox;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox xMinCheckBox;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox yMinCheckBox;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox yMaxCheckBox;
        public System.Windows.Forms.RadioButton radioButton2;
        public System.Windows.Forms.RadioButton radioButton1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label label9;
    }
}