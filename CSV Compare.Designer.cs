namespace csvcompare
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
        /// <parm name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            dataGridView1 = new DataGridView();
            importButton = new Button();
            compareButton = new Button();
            dataGridView2 = new DataGridView();
            switchButton = new Button();
            compareSelectedButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(-1, 29);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Size = new Size(802, 424);
            dataGridView1.TabIndex = 0;
            // 
            // importButton
            // 
            importButton.Location = new Point(1, 1);
            importButton.Name = "importButton";
            importButton.Size = new Size(94, 24);
            importButton.TabIndex = 1;
            importButton.Text = "Import";
            importButton.UseVisualStyleBackColor = true;
            importButton.Click += importButton_Click;
            // 
            // compareButton
            // 
            compareButton.Location = new Point(101, 1);
            compareButton.Name = "compareButton";
            compareButton.Size = new Size(94, 24);
            compareButton.TabIndex = 2;
            compareButton.Text = "Compare";
            compareButton.UseVisualStyleBackColor = true;
            compareButton.Click += compareButton_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.AllowUserToOrderColumns = true;
            dataGridView2.AllowUserToResizeColumns = false;
            dataGridView2.AllowUserToResizeRows = false;
            dataGridView2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(-1, 29);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.Size = new Size(802, 424);
            dataGridView2.TabIndex = 3;
            dataGridView2.Visible = false;
            // 
            // switchButton
            // 
            switchButton.Location = new Point(705, 1);
            switchButton.Name = "switchButton";
            switchButton.Size = new Size(94, 24);
            switchButton.TabIndex = 4;
            switchButton.Text = "Switch tables";
            switchButton.UseVisualStyleBackColor = true;
            switchButton.Visible = false;
            switchButton.Click += switchButton_Click;
            // 
            // compareSelectedButton
            // 
            compareSelectedButton.Location = new Point(101, 1);
            compareSelectedButton.Name = "compareSelectedButton";
            compareSelectedButton.Size = new Size(94, 24);
            compareSelectedButton.TabIndex = 5;
            compareSelectedButton.Text = "Compare";
            compareSelectedButton.UseVisualStyleBackColor = true;
            compareSelectedButton.Visible = false;
            compareSelectedButton.Click += compareSelectedButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(compareSelectedButton);
            Controls.Add(switchButton);
            Controls.Add(dataGridView2);
            Controls.Add(compareButton);
            Controls.Add(importButton);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "CSV Compare";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dataGridView1;
        private Button importButton;
        private Button compareButton;
        private DataGridView dataGridView2;
        private Button switchButton;
        private Button compareSelectedButton;
    }
}
