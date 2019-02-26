using System;

namespace ArithmeticOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("increment Example");
            int numA = 0; //numA++ равна записи numА + 1
            int numB = 1;
            numA = numB++;  //numA = 1, numB = 2
            Console.WriteLine(numA);
            Console.WriteLine(numB);
            Console.ReadLine();
          //  numA = 0; numB = 1;//исходные значения
          //  numA = ++numB; //numA = 2; numB = 2;
        }
        /*
        + сложение
        - вычитание, унарный минус
        * умножение
        / деление без остатка
        % деление с остатком
        -- декремент. уменьшает операнд на 1
        ++ инкремент. увеличивает операнд на 1
        */
    }
}
