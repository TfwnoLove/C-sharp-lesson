using System;

namespace ConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b;
            double res = 0;
            char oper;

            Console.WriteLine("Введите первое число:");
            a = Convert.ToDouble(Console.ReadLine());           

            Console.WriteLine("\nВведите оператор:");
            oper = Convert.ToChar(Console.ReadLine());

            Console.WriteLine("Введите второе число:");
            b = Convert.ToDouble(Console.ReadLine());
            //программа падает, если вместо первого числа ввести символ/букву
            if(oper == '+')
            {
                res = a + b;
            }
            else if(oper == '-')
            {
                res = a - b;
            }
            else if (oper == '*')
            {
                res = a * b;
            }
            else if (oper == '/')
            {
                if (b != 0)
                    res = a / b;
                else Console.WriteLine("Делить на 0 нельзя");
            }
            else
            {
                Console.WriteLine("Неизвестный оператор");
            }
            Console.WriteLine("\nРезультат: {0}",res);
            Console.ReadLine();
        }
    }
}
