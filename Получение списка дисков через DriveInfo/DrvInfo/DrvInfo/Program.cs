using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrvInfo
{
    class Program
    {
        //Directory возвращает строковые данные
        static void Main(string[] args)
        {
            Console.WriteLine("List local disks: ");
            string[] dsk = Directory.GetLogicalDrives();//GetLogicalDrives возвращает массив строк
            foreach (string s in dsk)
                Console.WriteLine("{0}", s);
            Console.WriteLine("\n");


            //GetLogicalDrives не выдаст подробной информации о дисках. Только их буквы.
            //Для подробного описания дисков используют DriveInfo

            DriveInfo[] drvs = DriveInfo.GetDrives();
            foreach (DriveInfo d in drvs)
            {                
                if (d.IsReady)
                {
                    Console.WriteLine("Disk: {0}, Type {1}", d.Name, d.DriveType);
                    Console.WriteLine("Free memory: {0} bytes", d.TotalFreeSpace);
                    Console.WriteLine("File system: {0}", d.DriveFormat);
                    Console.WriteLine("Lable: {0}", d.VolumeLabel);
                    Console.WriteLine("\n");
                }                
            }
            Console.ReadLine();
        }
    }
}
