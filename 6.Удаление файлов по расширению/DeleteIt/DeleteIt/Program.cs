using System;
using System.IO;
using System.Collections.Generic;
using System.Text;


namespace DeleteIt
{
    class Program
    {       
        static void Main(string[] args)
        {
        
            Console.WriteLine("Привет! Напиши путь к папке в которой искать и нажми Enter");
            string path = Console.ReadLine();            
            DirectoryInfo directory = new DirectoryInfo(path);
           
            if(path != null )
            {
                Console.WriteLine("Понял. Искать в каталоге {0}",path);
                Console.WriteLine("Напиши какой формат файлов нужно найти и удалить?");
                string format = "*."+ Console.ReadLine();             

                if (format != null)
                {
                    FileInfo[] files = directory.GetFiles(format, SearchOption.AllDirectories);
                    foreach (FileInfo f in files)
                    {
                        Console.WriteLine("Найдено файлов {0}", files.Length);
                        Console.WriteLine("Имя каталога: {0}", directory.Name);
                        Console.WriteLine("Аттрибут файла: {0}", directory.Attributes);
                        Console.WriteLine("Создан: {0}", directory.CreationTime);
                        f.Delete();
                    }
                    Console.WriteLine("Эти файл/ы были удалены");
                    Console.ReadLine();                   
                }
                else
                {
                    Console.WriteLine("Не указан формат");
                }
            }
            else
            {
                Console.WriteLine("Ты не указал путь :( ");
            }
        }
    }
}
