using System;
using System.IO;
using System.Text;

namespace StreamFileStream
{
    class Program
    {
        static void Main(string[] args)
        {
            //Получаем объект типа FileStream
            using (FileStream fStream = File.Open(@"C:\temp\test.dat", FileMode.Create))
            {
                //Кодируем строку в виде массива байтов
                string txt = "Test";
                byte[] txtByteAttay = Encoding.Default.GetBytes(txt);

                //Записываем массив в файл
                fStream.Write(txtByteAttay, 0, txtByteAttay.Length);

                //Сбрасываем position
                fStream.Position = 0;

                //Читаем из файла и выводим
                byte[] byteFromFile = new byte[txtByteAttay.Length];
                for(int i=0; i<txtByteAttay.Length; i++)
                {
                    byteFromFile[i] = (byte)fStream.ReadByte();
                    Console.Write(byteFromFile[i]);
                }
                Console.WriteLine();

                //Декодируем сообщение и выводим
                Console.Write("Декодированное сообщение: ");
                Console.WriteLine(Encoding.Default.GetString(byteFromFile));
                Console.ReadLine();               
            }
        }
    }   
}
