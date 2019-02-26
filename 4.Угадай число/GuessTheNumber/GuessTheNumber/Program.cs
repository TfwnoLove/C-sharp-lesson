using System;


namespace GuessTheNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            char again = '1'; //объявляю символ у
            Random rand = new Random();//добавляю переменную rand типа Random и присваиваю ей метод
            Console.WriteLine("Поиграем? (y= Да, n= Нет)");
            try
            {
                again = Convert.ToChar(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Неизвестный символ");
                Console.ReadLine();
            }

            while (again == 'y')//выполнить следующий блок кода если символ равен у
            {
                int i = rand.Next(10);//локальная переменная i будет равна от 0 до 9
                Console.WriteLine("Компьютер загадал число от 0 до 9");
                if (i < 5) Console.WriteLine("Число меньше 5");//считать значение загаданной i и если она меньше 5 то вывести подсказку 
                else Console.WriteLine("Число больше или равно 5");

                // int x = Convert.ToInt32(Console.ReadKey());//не работает
                int x = (int)(Console.ReadKey().KeyChar);//объявляю лок.переменную х и заполняю её вводом с клавиатуры
                if (x == i) Console.WriteLine("\nВы угадали!");
                else Console.WriteLine("\nВы не угадали. Компьютер загадал число {0}", i);

                Console.WriteLine("Начать сначала? (y= Да, n= Нет)");
                if (again == 'y' || again == 'n')
                {
                    try
                    {
                        again = Convert.ToChar(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Неизвестный символ");
                        Console.ReadLine();
                    }
                }

                else
                {
                    Console.WriteLine("Неизвестный символ");
                    Console.ReadLine();
                }

                //string text = " ";
                // string.IsNullOrWhiteSpace(text);
            }
        }
    }
}
