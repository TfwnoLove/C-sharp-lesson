using System;
using System.IO;


namespace DirectoryInfos
{
    class Program
    {
        static void Main(string[] args)
        {
            //работа с каталогами 
            //класс DirectoryInfo
            DirectoryInfo direct = new DirectoryInfo(@"C:\DirectoryInfos");//@ указывает несуществующий каталог
            direct.Create();//создаем каталог
            direct.CreateSubdirectory("Data");//создать подкатолог
            direct.CreateSubdirectory("Help/Me/Please");

            //рассмотрим свойства каталога с помощью методов унаследованных от FileSystemInfo
            Console.WriteLine("FullName: {0}", direct.FullName);
            Console.WriteLine("Name: {0}", direct.Name);
            Console.WriteLine("Parent: {0}", direct.Parent);
            Console.WriteLine("CreationTime: {0}", direct.CreationTime);
            Console.WriteLine("Attributes: {0}", direct.Attributes);
            Console.WriteLine("Root: {0}", direct.Root);

            Console.ReadLine();

        }
    }
}
