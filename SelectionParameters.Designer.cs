namespace csvcompare
{
    partial class SelectionParameters
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
            numCheckBox = new CheckBox();
            lowerCaseBox = new CheckBox();
            SuspendLayout();
            // 
            // numCheckBox
            // 
            numCheckBox.AutoSize = true;
            numCheckBox.Location = new Point(12, 12);
            numCheckBox.Name = "numCheckBox";
            numCheckBox.Size = new Size(151, 19);
            numCheckBox.TabIndex = 0;
            numCheckBox.Text = "Compare only numbers";
            numCheckBox.TextAlign = ContentAlignment.MiddleCenter;
            numCheckBox.UseVisualStyleBackColor = true;
            numCheckBox.CheckedChanged += numCheckBox_CheckedChanged;
            // 
            // lowerCaseBox
            // 
            lowerCaseBox.AutoSize = true;
            lowerCaseBox.Location = new Point(12, 37);
            lowerCaseBox.Name = "lowerCaseBox";
            lowerCaseBox.Size = new Size(172, 19);
            lowerCaseBox.TabIndex = 1;
            lowerCaseBox.Text = "Convert letters to lowercase";
            lowerCaseBox.TextAlign = ContentAlignment.MiddleCenter;
            lowerCaseBox.UseVisualStyleBackColor = true;
            lowerCaseBox.CheckedChanged += lowerCaseBox_CheckedChanged;
            // 
            // SelectionParameters
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(193, 70);
            Controls.Add(lowerCaseBox);
            Controls.Add(numCheckBox);
            Name = "SelectionParameters";
            Text = "SelectionParameters";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox numCheckBox;
        private CheckBox lowerCaseBox;
    }
}