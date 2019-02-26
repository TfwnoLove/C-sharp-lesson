using System;

namespace ValueFunctions
{
    class Program
    {
        static double f(double x)//cтатический член класса 
        {
            return 3 * Math.Pow(x, 3) - 2 * Math.Pow(x, 2);//Math.Pow возводит в степень. Возвращает double
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Вычисление функции 3х^3-2x^2");
            
            Console.WriteLine("Введите Х: ");
            string t = Console.ReadLine();//создать пустую строку и ждать ввода значения в неё
            int x = Convert.ToInt32(t);//х будет равен введеному конвентированном значению t
            int i;//инициализирую переменную для цикла
            double sum = 0;

            for (i = 1; i <= x; i++) sum = sum + f(i);//пройтись от 1 до х и вывести сумму
            Console.WriteLine("Результат: {0}", sum);
            Console.ReadLine();
        }
    }
}
