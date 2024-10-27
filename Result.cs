using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csvcompare
{
    public partial class Result : Form
    {
        public Result()
        {
            InitializeComponent();
        }
        public string resultText = "";
        private void doneButton_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.OK;
        }

        private void Result_Load(object sender, EventArgs e)
        {
            richTextBox1.ReadOnly = true;
            richTextBox1.Text = resultText;
        }
    }
}
