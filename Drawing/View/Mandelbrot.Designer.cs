namespace Drawing {
    partial class Mandelbrot {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mandelbrot));
            this.generatePatternButton = new System.Windows.Forms.Button();
            this.xMinCheckBox = new System.Windows.Forms.TextBox();
            this.xMaxCheckBox = new System.Windows.Forms.TextBox();
            this.zoomCheckbox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.iterationCountTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.yMinCheckBox = new System.Windows.Forms.TextBox();
            this.yMaxCheckBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.statusLabel = new System.Windows.Forms.Label();
            this.undoButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            // xMinCheckBox
            // 
            this.xMinCheckBox.Location = new System.Drawing.Point(13, 143);
            this.xMinCheckBox.Name = "xMinCheckBox";
            this.xMinCheckBox.Size = new System.Drawing.Size(56, 20);
            this.xMinCheckBox.TabIndex = 13;
            this.xMinCheckBox.Text = "-2.2";
            // 
            // xMaxCheckBox
            // 
            this.xMaxCheckBox.Location = new System.Drawing.Point(72, 143);
            this.xMaxCheckBox.Name = "xMaxCheckBox";
            this.xMaxCheckBox.Size = new System.Drawing.Size(56, 20);
            this.xMaxCheckBox.TabIndex = 14;
            this.xMaxCheckBox.Text = "1.2";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Iterations";
            // 
            // iterationCountTextBox
            // 
            this.iterationCountTextBox.Location = new System.Drawing.Point(18, 41);
            this.iterationCountTextBox.Name = "iterationCountTextBox";
            this.iterationCountTextBox.Size = new System.Drawing.Size(103, 20);
            this.iterationCountTextBox.TabIndex = 5;
            this.iterationCountTextBox.Text = "85";
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "yMax";
            // 
            // yMinCheckBox
            // 
            this.yMinCheckBox.Location = new System.Drawing.Point(13, 94);
            this.yMinCheckBox.Name = "yMinCheckBox";
            this.yMinCheckBox.Size = new System.Drawing.Size(56, 20);
            this.yMinCheckBox.TabIndex = 9;
            this.yMinCheckBox.Text = "-1.2";
            // 
            // yMaxCheckBox
            // 
            this.yMaxCheckBox.Location = new System.Drawing.Point(72, 94);
            this.yMaxCheckBox.Name = "yMaxCheckBox";
            this.yMaxCheckBox.Size = new System.Drawing.Size(56, 20);
            this.yMaxCheckBox.TabIndex = 10;
            this.yMaxCheckBox.Text = "1.2";
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(73, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "xMax";
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
            this.groupBox1.Location = new System.Drawing.Point(844, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(144, 355);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuration";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(20, 323);
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
            this.radioButton1.Location = new System.Drawing.Point(20, 300);
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
            // Mandelbrot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 722);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Mandelbrot";
            this.Text = "Mandelbrot";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Mandelbrot_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseClickOnForm);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseUpOnForm);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button generatePatternButton;
        public System.Windows.Forms.TextBox xMinCheckBox;
        public System.Windows.Forms.TextBox xMaxCheckBox;
        public System.Windows.Forms.CheckBox zoomCheckbox;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox iterationCountTextBox;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox yMinCheckBox;
        public System.Windows.Forms.TextBox yMaxCheckBox;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Button undoButton;
        public System.Windows.Forms.Label statusLabel;
        public System.Windows.Forms.RadioButton radioButton2;
        public System.Windows.Forms.RadioButton radioButton1;
    }
}

