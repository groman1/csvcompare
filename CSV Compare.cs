using System.Data;
using System.Windows.Forms.Design.Behavior;

namespace csvcompare
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string fileName1 = "";
        string fileName2 = "";

        private void importButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Comma-separated values | *.csv";
            ofd.Multiselect = false;
            ofd.Title = "Select a csv table";
            ofd.DefaultExt = ".csv";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fileName1 = ofd.FileName;
                StreamReader sr = new StreamReader(fileName1);
                handleData(sr.ReadToEnd());
            }
        }
        private void handleData(string data)
        {
            List<string[]> separatedLinesAndRows1 = new List<string[]>();
            int breakLineCount = 0;
            foreach (char c in data) { if (c == '\n') ++breakLineCount; }
            string[] separatedLines = data.Split('\n');
            int width;
            foreach (string s in separatedLines)
                separatedLinesAndRows1.Add(s.Split(','));
            width = separatedLinesAndRows1[0].Length;
            int len = 0;
            for (len = 1; len <= width; len++)
            {
                dataGridView1.Columns.Add(len.ToString(), len.ToString());
            }
            separatedLinesAndRows1.RemoveAt(len - 2);
            foreach (string[] strings in separatedLinesAndRows1)
                dataGridView1.Rows.Add(strings);

        }
        private void handleData(string data1, string data2)
        {
            List<string[]> separatedLinesAndRows1 = new List<string[]>();
            List<string[]> separatedLinesAndRows2 = new List<string[]>();
            int len1 = 0, len2 = 0, width1, width2;

            string[] separatedLines1 = data1.Split('\n');
            string[] separatedLines2 = data2.Split('\n');

            foreach (string s in separatedLines1)
                separatedLinesAndRows1.Add(s.Split(','));
            foreach (string s in separatedLines2)
                separatedLinesAndRows2.Add(s.Split(","));

            width1 = separatedLinesAndRows1[0].Length;
            width2 = separatedLinesAndRows2[0].Length;

            for (len1 = 1; len1 <= width1; len1++)
            {
                dataGridView1.Columns.Add(len1.ToString(), len1.ToString());
            }
            for (len2 = 1; len2 <= width2; len2++)
            {
                dataGridView2.Columns.Add(len2.ToString(), len2.ToString());
            }
            separatedLinesAndRows1.RemoveAt(len1 - 2);
            separatedLinesAndRows2.RemoveAt(len2 - 2);

            foreach (string[] strings in separatedLinesAndRows1)
                dataGridView1.Rows.Add(strings);
            foreach (string[] strings in separatedLinesAndRows2)
                dataGridView2.Rows.Add(strings);

        }

        private void compareButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd1 = new OpenFileDialog();
            OpenFileDialog ofd2 = new OpenFileDialog();

            ofd1.Filter = ofd2.Filter = "Comma-separated values | *.csv";
            ofd1.Title = ofd2.Title = "Select a table";
            ofd1.DefaultExt = ofd2.DefaultExt = ".csv";
            if (ofd1.ShowDialog() == DialogResult.OK && ofd2.ShowDialog() == DialogResult.OK)
            {
                fileName1 = ofd1.FileName;
                fileName2 = ofd2.FileName;

                StreamReader sr1 = new StreamReader(fileName1);
                StreamReader sr2 = new StreamReader(fileName2);

                handleData(sr1.ReadToEnd(), sr2.ReadToEnd());
                switchButton.Visible = true;

                compareButton.Visible = false;
                compareSelectedButton.Visible = true;
            }
        }

        private void switchButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Visible)
            {
                dataGridView1.Visible = false;
                dataGridView2.Visible = true;
            }
            else
            {
                dataGridView1.Visible = true;
                dataGridView2.Visible = false;
            }
        }

        private void compareSelectedButton_Click(object sender, EventArgs e)
        {
            int selectedColumn1 = dataGridView1.SelectedColumns[0].Index;
            int selectedColumn2 = dataGridView2.SelectedColumns[0].Index;

            SelectionParameters selectionParameters = new SelectionParameters();

            if (selectionParameters.ShowDialog() == DialogResult.OK)
            {
                bool numbersOnly = selectionParameters.numCheckState;
                bool lowerCase = selectionParameters.lowerCaseState;

                if (numbersOnly)
                {
                    foreach (DataRow row in dataGridView1.Rows)
                    {
                        char[] strRow = row[selectedColumn1].ToString().ToCharArray();
                        for (int i = 0; i<strRow.Length; i++)
                        {
                            if (Char.IsLetter(strRow[i]) || strRow[i] == '-' || strRow[i] == '_')
                            {
                                strRow[i] = '0';
                            }
                        }
                    }
                    int[] numbers1 = 
                }
            }

        }
    }
}
