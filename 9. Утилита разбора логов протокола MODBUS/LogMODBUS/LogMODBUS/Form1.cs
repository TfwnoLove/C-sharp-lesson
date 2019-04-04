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
            StreamReader reader = new StreamReader(Direction.FullName);
            List<LogProperties> Tables = new List<LogProperties>();
            //распарсить строку...
            string logText = reader.ReadLine();
            string[] parsing = logText.Split(new char[] { '\t'});

            LogProperties logProp = new LogProperties();
            //эти свойства хранят данные из лога 1й строки
            logProp.Number = parsing[0];
            logProp.Time = parsing[1];
            logProp.AppName = parsing[2];
            logProp.IRP = parsing[3];//IRP
            logProp.Serial0 = parsing[4];//serial
            logProp.ErrorType = parsing[5];//error
            logProp.Length = parsing[6].Substring(0, 8); //lenth. Add substrng
            logProp.Adress = parsing[6].Substring(10,2);
            logProp.Command = parsing[6].Substring(13, 2);
            logProp.Crc = parsing[6].Substring(parsing.Length + 17);

            dataGridView1.DataSource = Tables; //create head
            
            string row;
            int i = 1;
            while ((row = reader.ReadLine()) != null) //читаем по одной линии(строке) пока не вычитаем все из потока (пока не достигнем конца файла)
            {
                i++;  //i укажет кол-во строк в логе              
            }            
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
