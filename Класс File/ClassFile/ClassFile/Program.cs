using System;
using System.IO;

namespace ClassFile
{
    class Program
    {
        static void Main(string[] args)
        {   
            //DirectoryInfo для работы с каталогами
            DirectoryInfo dr = new DirectoryInfo(@"C:\temp");
            dr.Create();

            string[] myFriernds = { "Тимур", "Тёмик" };

            //Записать данный в файл
            File.WriteAllLines(@"C:\temp\friends.txt",myFriernds);//WriteAllLines создает новый файл, если его нет

            //Прочитать и вывести
            foreach(string friend in File.ReadAllLines(@"C:\temp\friends.txt"))
            {
                Console.WriteLine("{0}", friend);
            }
            Console.ReadLine();
        }
    }
}
