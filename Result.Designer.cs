namespace csvcompare
{
    partial class Result
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
            richTextBox1 = new RichTextBox();
            doneButton = new Button();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox1.Location = new Point(12, 12);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(776, 406);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // doneButton
            // 
            doneButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            doneButton.Location = new Point(12, 424);
            doneButton.Name = "doneButton";
            doneButton.Size = new Size(776, 23);
            doneButton.TabIndex = 1;
            doneButton.Text = "OK";
            doneButton.UseVisualStyleBackColor = true;
            doneButton.Click += doneButton_Click;
            // 
            // Result
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 456);
            Controls.Add(doneButton);
            Controls.Add(richTextBox1);
            Name = "Result";
            Text = "Result";
            Load += Result_Load;
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox richTextBox1;
        private Button doneButton;
    }
}