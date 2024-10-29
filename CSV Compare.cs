using System.Data;
using System.Net.Http.Headers;
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
        List<int> selectedColumns1 = new List<int>();
        List<int> selectedColumns2 = new List<int>();
        bool associatedState;
        //private string compare(List<List<string>>, List<List<string>>);

        private void importButton_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Comma-separated values | *.csv";
            ofd.Multiselect = false;
            ofd.Title = "Select a csv table";
            ofd.DefaultExt = ".csv";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                switchButton.Visible = false;
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

            string[] separatedLines1un = data1.Split('\n');
            string[] separatedLines2un = data2.Split('\n');
            List<string> separatedLines1 = new List<string>();
            List<string> separatedLines2 = new List<string>();

            foreach (string s in separatedLines1un)
            {
                if (s.Length > 0) { separatedLines1.Add(s); }
            }
            foreach (string s in separatedLines2un)
            {
                if (s.Length > 0) { separatedLines2.Add(s); }
            }
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            dataGridView2.Refresh();
            dataGridView1.SelectionMode = dataGridView2.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;

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
            foreach (DataGridViewColumn dataGridViewColumn in dataGridView1.Columns)
            {
                dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewColumn dataGridViewColumn in dataGridView2.Columns)
            {
                dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dataGridView1.SelectionMode = dataGridView2.SelectionMode = DataGridViewSelectionMode.FullColumnSelect;

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
            SelectionParameters selectionParameters = new SelectionParameters();

            if (selectionParameters.ShowDialog() == DialogResult.OK)
            {
                bool numbersOnly = selectionParameters.numCheckState;
                bool lowerCase = selectionParameters.lowerCaseState;
                associatedState = selectionParameters.associatedState;
                List<List<string>> numbers1 = new List<List<string>>();
                List<List<string>> numbers2 = new List<List<string>>();

                if (numbersOnly)
                {
                    
                    for (int x = 0; x < selectedColumns1.Count; x++)
                    {
                        numbers1.Add([]);
                        numbers2.Add([]);
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            char[] strRow = row.Cells[selectedColumns1[x]].Value.ToString().ToCharArray();
                            string value = "";
                            for (int i = 0; i < strRow.Length; i++)
                            {
                                if (!Char.IsDigit(strRow[i]))
                                {
                                    strRow[i] = '0';
                                }
                            }
                            foreach (char c in strRow) value += c;
                            numbers1[x].Add((long.Parse(value)).ToString());
                        }

                        foreach (DataGridViewRow row in dataGridView2.Rows)
                        {
                            char[] strRow = row.Cells[selectedColumns2[x]].Value.ToString().ToCharArray();
                            string value = "";
                            for (int i = 0; i < strRow.Length; i++)
                            {
                                if (!Char.IsDigit(strRow[i]))
                                {
                                    strRow[i] = '0';
                                }
                            }
                            foreach (char c in strRow) value += c;
                            numbers2[x].Add((long.Parse(value)).ToString());
                        }
                    }
                }
                else
                {
                    for (int x = 0; x < selectedColumns1.Count; x++)
                    {
                        numbers1.Add([]);
                        numbers2.Add([]);
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            numbers1[x].Add(row.Cells[selectedColumns1[x]].Value.ToString());
                            
                        }

                        foreach (DataGridViewRow row in dataGridView2.Rows)
                        {
                            numbers2[x].Add(row.Cells[selectedColumns2[x]].Value.ToString());
                        }
                    }
                }
                if (outputResultToFileButton.Checked)
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.DefaultExt = ".txt";
                    string outputFileName;
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        outputFileName = sfd.FileName;
                        List<string[]> strings = new List<string[]>();
                        StreamWriter sw = new StreamWriter(outputFileName);
                        strings.Add(compare(numbers1, numbers2).Split('\n'));
                        foreach (string[] list in strings)
                        {
                            foreach (string line in list)
                            {
                                sw.WriteLine(line);
                            }
                        }
                        sw.Close();
                    }
                }
                else
                {
                    Result result = new Result();
                    result.resultText = compare(numbers1, numbers2).ToString();
                    numbers1 = numbers2 = [[]];
                    if (result.ShowDialog() == DialogResult.OK)
                    {
                        compareButton.Visible = true;
                        compareSelectedButton.Visible = false;
                    }
                }
            }

        }

        private string compare(List<List<string>> values1, List<List<string>> values2)
        {
            string result = string.Empty;
            int column = 0;

            if (!associatedState)
            {
                for (int h = 0; h < selectedColumns1.Count; h++)
                {
                    column = selectedColumns1[h];
                    for (int i = 0; i < values2[h].Count; i++) //cycling through the column (h)
                    {
                        if (!values1[h].Contains(values2[h][i]))
                        {
                            result += "Missing value detected in the first table: " + dataGridView2.Rows[i].Cells[column].Value + "\n";
                        }
                    }
                    for (int i = 0; i < values1[h].Count; i++) //cycling through the column (h)
                    {
                        if (!values2[h].Contains(values1[h][i]))
                        {
                            result += "Missing value detected in the second table: " + dataGridView1.Rows[i].Cells[column].Value + "\n";
                        }
                    }
                }
            }
            else
            {
                column = selectedColumns1[0];
                for (int i = 0; i < values2[0].Count-1; i++)
                {
                    if (!values1[0].Contains(values2[0][i])) //cycling through the column (h)
                    {
                        result += "Missing value detected in the first table: " + dataGridView2.Rows[i].Cells[column].Value + "\n";
                    }
                    else
                    {
                        if (values1.Count == 2) //if one associated value is detected
                        {
                            if (values1[1][(values1[0].FindIndex(a => a.Contains(values2[0][i])))] != values2[1][i])
                            {
                                result += "First associated value at row " + i.ToString() + " is different\n";
                            }
                        }
                        else if (values1.Count == 3) //if two associated values are detected
                        {
                            if (values1[2][(values1[2].FindIndex(a => a.Contains(values2[0][i])))] != values2[2][i]) //check if associated value is different (2)
                            {
                                result += "Second associated value at row " + i.ToString() + " is different\n";

                            }
                        }
                        else if (values1.Count == 4) //if three associated values are detected
                        {
                            if (values1[3][(values1[3].FindIndex(a => a.Contains(values2[0][i])))] != values2[3][i]) //check if associated value is different (3)
                            {
                                result += "Third associated value at row " + i.ToString() + " is different\n";
                            }
                        }
                        else
                        {
                            MessageBox.Show("Unsupported amount of columns selected, select more than one and lower than four columns");
                            break;
                        }
                    }
                }
            }
            return result;
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            selectedColumns2 = [];
            for (int i = 0; i < dataGridView2.SelectedColumns.Count; i++)
                selectedColumns2.Add(dataGridView2.SelectedColumns[dataGridView2.SelectedColumns.Count - 1 -i].Index);
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            selectedColumns1 = [];
            for (int i = 0; i < dataGridView1.SelectedColumns.Count; i++)
                selectedColumns1.Add(dataGridView1.SelectedColumns[dataGridView1.SelectedColumns.Count - 1 - i].Index);
        }
    }
}
