using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogMODBUS
{
    public partial class Form1 : Form
    {
        OpenFileDialog dialogWin { get; set; }
        DirectoryInfo Direction { get; set; }
        public Form1()
        {
            InitializeComponent();
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            button2.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void importToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            using (dialogWin = new OpenFileDialog() { Filter = "MODBUS log|*.log",ValidateNames = true })
            {
                
                if (dialogWin.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = dialogWin.FileName;

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
            Direction = new DirectoryInfo(textBox1.Text);
            if (Direction.Exists == false) {                 
                textBox2.Text = File.ReadAllText(Direction.FullName);
                button2.Enabled = true;
            }
            else {
                MessageBox.Show("Invalid path");
            }
        }
       
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        public void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text !=  null)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string text = saveFileDialog1.FileName; 
                    File.WriteAllText(text, textBox2.Text);
                }
            }
        }

       
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
