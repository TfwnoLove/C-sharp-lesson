using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace DeleteIt_
{
    public partial class Form1 : Form
    {        
        DirectoryInfo Direction { get; set; }        
        FileInfo[] Files { get; set; }

        public Form1()
        {
            InitializeComponent();
            textBox1.ReadOnly = true;
        }

        public void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            FBD.ShowNewFolderButton = false;
            
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                string path = FBD.SelectedPath;
                Direction = new DirectoryInfo(path);//заполняем каталог Direction выбранным путём path
                textBox1.Text = path;              
            }
        }      

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try{
                if (Direction.Exists) {//проверяем каталог на коректность, если true то...

                    //используем FileInfo для нахождения всех файлов в каталоге и подкаталогах
                    Files = Direction.GetFiles("*.*", SearchOption.AllDirectories);                    
                    
                    foreach (FileInfo f in Files)//из найденых строим список с чекбоксами в checkedListBox1
                    {
                        label4.Text = checkedListBox1.Items.Count.ToString();//отсчет с нуля 
                        //checkedListBox1.Items.Add(f.ToString());
                        checkedListBox1.Items.Add(f.FullName);
                        checkedListBox1.SetSelected(0, true);
                    }
                    if (checkedListBox1.Items.Count == 0)
                    {//кнопка скана активна только если список пуст
                        button2.Enabled= true;
                    }
                    else button2.Enabled = false;
                }
            }
            catch { 
                MessageBox.Show("Укажите путь");
            }
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            textBox1.Clear();
            Direction = null;
            button2.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {          //отметить всё  
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                checkedListBox1.SetItemChecked(i, true);                
            
            /*  //снять все галочки
                 for (int i = 0; i < checkedListBox1.Items.Count; i++)
                 checkedListBox1.SetItemChecked(i, false);
                 select = false;
            */
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = checkedListBox1.Items.Count - 1; i >= 0; i--)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    
                    var pathFile = checkedListBox1.Items[i].ToString();
                    File.Delete(pathFile);
                    checkedListBox1.Items.RemoveAt(i);
                }
            }
        }        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {           
        }
    }
}
