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
    public partial class SelectionParameters : Form
    {
        public SelectionParameters()
        {
            InitializeComponent();
        }
        public bool numCheckState = false;
        public bool lowerCaseState = false;
        public bool associatedState = false;
        private void numCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            numCheckState = numCheckBox.Checked;
        }

        private void lowerCaseBox_CheckedChanged(object sender, EventArgs e)
        {
            lowerCaseState = lowerCaseBox.Checked;
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            SelectionParameters selectionParameters = new SelectionParameters();
            selectionParameters.Hide();
            this.DialogResult = DialogResult.OK;
        }

        private void associateBox_CheckedChanged(object sender, EventArgs e)
        {
            associatedState = associateBox.Checked;
        }
    }
}
