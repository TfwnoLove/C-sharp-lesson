using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;

namespace LogMODBUS
{
    public partial class Form1 : Form
    {
        OpenFileDialog DialogWin { get; set; }
        DirectoryInfo Direction { get; set; }

        public Form1()
        {
            InitializeComponent();
            saveFileDialog1.Filter = "XML (*.xml)|*.xml|All files(*.*)|*.*";
            button2.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void importToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            using (DialogWin = new OpenFileDialog() { Filter = "MODBUS log|*.log", ValidateNames = true })
            {

                if (DialogWin.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = DialogWin.FileName;
                    Direction = new DirectoryInfo(textBox1.Text);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Direction = new DirectoryInfo(textBox1.Text);
                if (Direction.Exists == false)
                {
                    parseText();
                    button2.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Invalid path");
                }
            }
            catch
            {
                MessageBox.Show("Invalid path");
            }
        }

        public void parseText()
        {
            List<LogProperties> Tables = new List<LogProperties>();
            //взять n-ную строку           
            
            IEnumerable<string> result = File.ReadLines(Direction.FullName);

            LogProperties logProp = new LogProperties();
            //заполняю хедер
            dataGridView1.Columns.Add(logProp.Number, "Number");
            dataGridView1.Columns.Add(logProp.Time, "Time");
            dataGridView1.Columns.Add(logProp.AppName, "AppName");
            dataGridView1.Columns.Add(logProp.IRP, "IRP");
            dataGridView1.Columns.Add(logProp.Serial0, "Serial0");
            dataGridView1.Columns.Add(logProp.ErrorType, "ErrorType");
            dataGridView1.Columns.Add(logProp.Length, "Length");
            dataGridView1.Columns.Add(logProp.Adress, "Adress");
            dataGridView1.Columns.Add(logProp.Command, "Command");
            dataGridView1.Columns.Add(logProp.Crc, "Crc");
            dataGridView1.Columns.Add(logProp.Raw_frame, "Raw_frame");
            dataGridView1.Columns.Add(logProp.Raw_data, "Raw_data");

            foreach (string logText in result)
            {
                //распарсить строку
                string[] parsing = logText.Split(new char[] { '\n','\t' }, StringSplitOptions.RemoveEmptyEntries);

                //эти свойства хранят данные из лога 1й строки
                logProp.Number = parsing[0];
                logProp.Time = parsing[1];
                logProp.AppName = parsing[2];
                logProp.IRP = parsing[3];//IRP
                logProp.Serial0 = parsing[4];//serial
                logProp.ErrorType = parsing[5];//error type

                Regex regexLength = new Regex(@"Length (\w*)");//for logProp.Length
                var mLength = regexLength.Matches(logText);
                foreach (Match match in mLength)
                {
                    var m = match.Groups[1].Value;
                    logProp.Length = m;
                }

                Regex regexAdr = new Regex(@": (\w*)");//for logProp.Adress
                var mAdr = regexAdr.Matches(logText);
                foreach (Match match in mAdr)
                {
                    var m = match.Groups[1].Value;
                    logProp.Adress = m;
                }

                Regex regexCommand = new Regex(logProp.Adress + @" (\w*)");//for logProp.Command
                var mCom = regexCommand.Matches(logText);
                foreach (Match match in mCom)
                {
                    var m = match.Groups[1].Value;
                    logProp.Command = m;
                }

                string logTextCopy = logText.Replace(" ", string.Empty);//

                logProp.Raw_frame = logTextCopy.Substring(logTextCopy.Length - (Convert.ToInt32(logProp.Length) * 2 + 1));

                if (logProp.Length == "0")
                {
                    logProp.Crc = "";
                }
                else if (logProp.Length != "0" && logProp.Raw_frame.Length>3)
                {
                    logProp.Crc = logTextCopy.Substring(logTextCopy.Length - 5);
                }
                else logProp.Crc = logTextCopy.Substring(logTextCopy.Length - 3);

                try
                {
                    if (logProp.Command != "")
                    {
                        string forRdata = logProp.Raw_frame.Remove(0, 4);
                        logProp.Raw_data = forRdata.Remove(forRdata.Length - 4);
                    }
                }
                catch {
                    logProp.Raw_data = "Error!";
                }
                //заполняю ячейки данными полученными из свойств
                int rowNumber = dataGridView1.Rows.Add();
                dataGridView1.Rows[rowNumber].Cells[0].Value = logProp.Number;
                dataGridView1.Rows[rowNumber].Cells[1].Value = logProp.Time;
                dataGridView1.Rows[rowNumber].Cells[2].Value = logProp.AppName;
                dataGridView1.Rows[rowNumber].Cells[3].Value = logProp.IRP;
                dataGridView1.Rows[rowNumber].Cells[4].Value = logProp.Serial0;
                dataGridView1.Rows[rowNumber].Cells[5].Value = logProp.ErrorType;
                dataGridView1.Rows[rowNumber].Cells[6].Value = logProp.Length;
                dataGridView1.Rows[rowNumber].Cells[7].Value = logProp.Adress;
                dataGridView1.Rows[rowNumber].Cells[8].Value = logProp.Command;
                dataGridView1.Rows[rowNumber].Cells[9].Value = logProp.Crc;
                dataGridView1.Rows[rowNumber].Cells[10].Value = logProp.Raw_frame;
                dataGridView1.Rows[rowNumber].Cells[11].Value = logProp.Raw_data;
            }
        }        

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        public void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1 != null)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                  
                    XDocument xdoc = new XDocument();
                    XElement source = new XElement("source");                    
                    XAttribute addressAttr = new XAttribute("address", dataGridView1.Rows[1].Cells[4].Value);//fix it!
                    XAttribute speedAttr = new XAttribute("speed", "unknown");

                    XElement line = new XElement("line");
                    XAttribute directionAttr = new XAttribute("direction", "request");
                    XAttribute addressLineAttr = new XAttribute("address", dataGridView1.Rows[1].Cells[4]);
                    XAttribute commandAttr = new XAttribute("command", "46:Read EEPROM");
                    XAttribute crcAttr = new XAttribute("crc","CA6C");

                    XElement raw_frame = new XElement("raw_frame");
                    raw_frame.Value = "";//fix it 

                    // добавляем атрибут и элементы в первый элемент
                    source.Add(addressAttr);
                    source.Add(speedAttr);
                    source.Add(line);
                    

                    line.Add(directionAttr);
                    line.Add(addressLineAttr);
                    line.Add(commandAttr);
                    line.Add(crcAttr);
                    line.Add(raw_frame);


                    //raw_frame.Add(raw_frame);

                    // создаем второй элемент
                   
                    // создаем корневой элемент
                    XElement data = new XElement("data");
                    XAttribute dataAttr = new XAttribute("source_type","com");
                    // добавляем в корневой элемент                   
                    data.Add(source);                    
                    data.Add(dataAttr);
                    //data.Add(galaxys5);

                    // добавляем корневой элемент в документ                   
                    xdoc.Add(data);
                    
                    //сохраняем документ
                    xdoc.Save("Log.xml");
                }
            }
           
        }
       


        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
