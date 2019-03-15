using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DeleteIt_
{
    public partial class Form1 : MaterialForm
    {        
        DirectoryInfo Direction { get; set; }//автосвойство типа DirectoryInfo с именем Direction        
        FileInfo[] Files { get; set; }//автосвойство типа FileInfo с именем Files

        public Form1()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            textBox1.ReadOnly = true;//установить параметр textBox1 в режим Только чтение, чтобы пользователь не смог изменить путь с клавиатуры
        }

        public void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();//тип FolderBrowserDialog с именем FBD позволяет открыть диалоговое окно
            FBD.ShowNewFolderButton = false;//запрет на кнопку создания новой папки
            
            if (FBD.ShowDialog() == DialogResult.OK)//если нажали ОК то...
            {
                string path = FBD.SelectedPath;//присвоить значение для строки path тому, чему равен выбранный путь
                Direction = new DirectoryInfo(path);//заполняем каталог Direction выбранным путём path
                textBox1.Text = path;//textBox1 заполняем path чтобы путь был виден пользователю              
            }
        }      

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {            
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            try{//оборачиваю в try catch на случай ошибочного пути
                if (Direction.Exists) {//проверяем каталог на коректность, если true то...

                    //используем FileInfo для нахождения всех файлов в каталоге и подкаталогах
                    Files = Direction.GetFiles("*.*", SearchOption.AllDirectories);                    
                    
                    foreach (FileInfo f in Files)//из найденых строим список с чекбоксами в checkedListBox1
                    {
                        label4.Text = checkedListBox1.Items.Count.ToString();//отсчет с нуля 
                        
                        checkedListBox1.Items.Add(f.FullName);//получаем полный путь до файлов и отображаем его в списке
                        checkedListBox1.SetSelected(0, true);//устанавливаем 0 для того, чтобы не было отмечено ни одного файла в списке
                    }
                    if (checkedListBox1.Items.Count == 0)
                    {//кнопка скана активна только если список пуст
                        materialRaisedButton2.Enabled= true;

                    }
                    else materialRaisedButton2.Enabled = false;
                    
                }
            }
            catch { 
                MessageBox.Show("Укажите путь");//в случае если путь не указан или же является некорректным вывести окно с ошибкой
            }
        }
        
        private void materialRaisedButton4_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();//очистить список
            textBox1.Clear();//очистить строку с отобразившимся путём
            Direction = null;//очистить переменную которая хранит каталог 
            materialRaisedButton2.Enabled = true;//активировать кнопку Сканировать

           
        }

        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {          //отметить всё  
                for (int i = 0; i < checkedListBox1.Items.Count; i++)//пройтись циклом по всем элементам 
                checkedListBox1.SetItemChecked(i, true);//и установить для каждого значение "галочку"                
            
            /*  //снять все галочки
                 for (int i = 0; i < checkedListBox1.Items.Count; i++)
                 checkedListBox1.SetItemChecked(i, false);
                 select = false;
            */
        }

        private void materialRaisedButton5_Click(object sender, EventArgs e)
        {
            for (int i = checkedListBox1.Items.Count - 1; i >= 0; i--)//пройтись по всем элементам циклом
            {
                if (checkedListBox1.GetItemChecked(i))//и если элемент отмечен галочкой
                {                    
                    var pathFile = checkedListBox1.Items[i].ToString();//заполнить переменную пути к файлу
                    File.Delete(pathFile);//удалить файл лежащий по пути pathFile
                    checkedListBox1.Items.RemoveAt(i);//удалить элемент из списка
                }
            }
        }        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {           
        }

       
    }
}
