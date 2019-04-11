using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassFileInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo direct = new DirectoryInfo(@"C:\temp");//@ указывает несуществующий каталог
            direct.Create();//создаем каталог

            FileInfo myFile = new FileInfo(@"C:\temp\file.vdd");
            FileStream fs = myFile.Create();//создать файл по указанному пути
            fs.Close();//закрыть поток

            //вместо Create() можно использовать Open() и перегрузки FileMode, FileAccess, FileShare
            //задавая параметры
            // FileStream fss = myFile.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite,FileShare.None);

            //для работы с текстовыми файлами используется метод OpenText(), CreateText(), AppendText()
            FileInfo txt = new FileInfo(@"prog.log");
            using (StreamReader txt_reader = txt.OpenText())
            {
                //читаем с файла
            }

            FileInfo f = new FileInfo(@"C:\temp\file.log");
            using (StreamWriter txt_reader = f.CreateText())//для записи/изменения используется StreamWriter!
            {
                //записываем в файл
            }

            FileInfo е = new FileInfo(@"C:\temp\file.log");//добавить текст
            using (StreamWriter txt_reader = е.AppendText())//AppendText!
            {
                //добавляем в файл
            }
        }
    }
}
