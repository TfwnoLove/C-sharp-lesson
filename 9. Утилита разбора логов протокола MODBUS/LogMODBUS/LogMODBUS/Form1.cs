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
            string logText = GetString(0, Direction.FullName);//Direction.FullName автосвойство хранящие в себе путь к файлу
            //распарсить строку
            string[] parsing = logText.Split(new char[] { '\t'});

            LogProperties logProp = new LogProperties();
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

            Regex regexCommand = new Regex(logProp.Adress +@" (\w*)");//for logProp.Command
            var mCom = regexCommand.Matches(logText);
            foreach (Match match in mCom)
            {
                var m = match.Groups[1].Value;
                logProp.Command = m;
            }

            string logTextCopy = GetString(0, Direction.FullName).Replace(" ", string.Empty);//
            logProp.Crc = logTextCopy.Substring(logTextCopy.Length - 5);


            logProp.Raw_frame = logTextCopy.Substring(logTextCopy.Length-(Convert.ToInt32(logProp.Length)*2+1));

            
            string forRdata = logProp.Raw_frame.Remove(0, 4);
            logProp.Raw_data = forRdata.Remove(forRdata.Length - 5);
            

            //заполняю хедер
            dataGridView1.Columns.Add(logProp.Number, "Number");
            dataGridView1.Columns.Add(logProp.Time, "Time");
            dataGridView1.Columns.Add(logProp.AppName, "AppName");
            dataGridView1.Columns.Add(logProp.IRP, "IRP");
            dataGridView1.Columns.Add(logProp.Serial0, "Serial0");
            dataGridView1.Columns.Add(logProp.ErrorType, "ErrorType");
            dataGridView1.Columns.Add(logProp.Length.ToString(), "Length");
            dataGridView1.Columns.Add(logProp.Adress, "Adress");
            dataGridView1.Columns.Add(logProp.Command, "Command");
            dataGridView1.Columns.Add(logProp.Crc, "Crc");
            dataGridView1.Columns.Add(logProp.Raw_frame, "Raw_frame");
            dataGridView1.Columns.Add(logProp.Raw_data, "Raw_data");


            //заполняю ячейки данными полученными из свойств
            int rowNumber = dataGridView1.Rows.Add();
            dataGridView1.Rows[rowNumber].Cells[logProp.Number].Value = logProp.Number;
            dataGridView1.Rows[rowNumber].Cells[logProp.Time].Value = logProp.Time;
            dataGridView1.Rows[rowNumber].Cells[logProp.AppName].Value = logProp.AppName;
            dataGridView1.Rows[rowNumber].Cells[logProp.IRP].Value = logProp.IRP;
            dataGridView1.Rows[rowNumber].Cells[logProp.Serial0].Value = logProp.Serial0;
            dataGridView1.Rows[rowNumber].Cells[logProp.ErrorType].Value = logProp.ErrorType;
            dataGridView1.Rows[rowNumber].Cells[logProp.Length].Value = logProp.Length;
            dataGridView1.Rows[rowNumber].Cells[logProp.Adress].Value = logProp.Adress;
            dataGridView1.Rows[rowNumber].Cells[logProp.Command].Value = logProp.Command;
            dataGridView1.Rows[rowNumber].Cells[logProp.Crc].Value = logProp.Crc;
            dataGridView1.Rows[rowNumber].Cells[logProp.Raw_frame].Value = logProp.Raw_frame;
            dataGridView1.Rows[rowNumber].Cells[logProp.Raw_data].Value = logProp.Raw_data;
        }
        public string GetString(int numberString,string filePath)
        {
            IEnumerable<string> result = File.ReadLines(filePath).Skip(numberString).Take(1);

            string newString = null;

            foreach (string str in result)
            {
                newString += str;
            }

            return newString;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        public void button2_Click(object sender, EventArgs e)
        {
        /*   // if (textBox2.Text != null)
           // {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    var path = saveFileDialog1.FileName;

                    XDocument xdoc = new XDocument();
                    XElement source = new XElement("source");                    
                    XAttribute addressAttr = new XAttribute("address", serial);
                    XAttribute speedAttr = new XAttribute("speed", "unknown");

                    XElement line = new XElement("line");
                    XAttribute directionAttr = new XAttribute("direction", "request");
                    XAttribute addressLineAttr = new XAttribute("address", address4);
                    XAttribute commandAttr = new XAttribute("command", "46:Read EEPROM");
                    XAttribute crcAttr = new XAttribute("crc","CA6C");

                    XElement raw_frame = new XElement("raw_frame");
                    raw_frame.Value = address;//fix it 

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
           // }
           */
        }
       


        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
