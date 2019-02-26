using System;

namespace CountWords
{
    class Program
    {
        static void Main(string[] args)
        {           
            Console.WriteLine("Введите текст: ");
            string text = Console.ReadLine();//заполняем переменную тем, что вводится с клавиатуры
            string[] tArr;        
            tArr = text.Split(new char[] { ' ', ',', '.' },StringSplitOptions.RemoveEmptyEntries);//Split разделит строку на массив подстрок
            Console.WriteLine("Количество слов в тексте: ");
            Console.WriteLine(tArr.Length);
            Console.ReadLine();
        }
    }
}
