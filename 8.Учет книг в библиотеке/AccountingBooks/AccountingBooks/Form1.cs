using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Runtime.InteropServices;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;
using System.Net;
using System.IO;
using System.Xml;

namespace AccountingBooks
{
    public partial class Form1 : Form
    {
        string pathFile { get; set; }
        WebClient wc = new WebClient();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
            using (OpenFileDialog dialogWin = new OpenFileDialog() { Filter= "Excel Workbook|*.xls", ValidateNames = true }) {
                if (dialogWin.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = dialogWin.FileName;
                   // pathFile = textBox1.Text;
                    GetFile();
                }
            }
        }

        private void GetFile()
        {
            pathFile = textBox1.Text;
            
            OleDbConnection conStr;
            conStr = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathFile + ";Extended Properties=Excel 8.0;");
            OleDbDataAdapter adapter = new OleDbDataAdapter("select * from [Лист1$]", conStr);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];

            conStr.Close();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            SaveTable(dataGridView1);
        }
        void SaveTable(DataGridView whatSave)
        {
            string path = pathFile;           

            Excel.Application excelapp = new Excel.Application();
            Excel.Workbook workbook = excelapp.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.ActiveSheet;

            for(int i = 1; i < whatSave.RowCount + 1; i++)
            {
                for (int j=1; j < whatSave.ColumnCount + 1; j++)
                {
                    worksheet.Rows[i].Columns[j] = whatSave.Rows[i - 1].Cells[j - 1].Value;
                }
            }
            excelapp.AlertBeforeOverwriting = false;
            try {
                workbook.SaveAs(path);
            }
            catch
            {
                path = System.IO.Directory.GetCurrentDirectory() + @"\" + "Save_Channel.xlsx";
                workbook.SaveAs(path);
                MessageBox.Show("Сохранено в каталоге программы");
            }            
            excelapp.Quit();
        }

        private void импортИзСетиToolStripMenuItem_Click(object sender, EventArgs e)
        {

            dwnLoad();
        }

        private void dwnLoad()
        {
            string url = "https://github.com/TfwnoLove/C-sharp-lesson/raw/master/8.%D0%A3%D1%87%D0%B5%D1%82%20%D0%BA%D0%BD%D0%B8%D0%B3%20%D0%B2%20%D0%B1%D0%B8%D0%B1%D0%BB%D0%B8%D0%BE%D1%82%D0%B5%D0%BA%D0%B5/AccountingBooks/AccountingBooks/bin/Debug/Save_Channel.xlsx";
            textBox1.Text = Directory.GetCurrentDirectory() + @"\";
            string save_path = Directory.GetCurrentDirectory() + @"\";
           
            string name = "Save_Channel.xlsx";
            wc.DownloadFile(url, save_path + name);
            string endPath = save_path + name;

            OleDbConnection conStr;
            conStr = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;extended properties=\"excel 8.0;hdr=no;IMEX=1\";data source=" + endPath + ";Extended Properties=Excel 8.0;");
            OleDbDataAdapter adapter = new OleDbDataAdapter("select * from [Лист1$]", conStr);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];

            conStr.Close();
        }
            
                
            
    }
}

