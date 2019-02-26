using System;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            //Массивы
            //Массив это набор элементов данных одного типа
            //После объявления массива необходимо установить его размер
            int[] digital = new int[5]; //int -тип массива, digita - имя, через new указываем тип и размерность
            digital[0] = 10; //заполнил 1й элемент массива числом
            int[] digitalism = new int[] { 10, 20, 30, 40, 50, 60 };//заполнение использую фигурные скобки
            object[] arrOfObjects = { true, 10, "Ну возьмите меня", 1.4 };//массив объектов

            int[] ints = { 10, 20, 30, 40, 50, 60 };
            Console.WriteLine("\n Обычный массив");
            for (int i = 0; i < ints.Length; i++) {
                Console.WriteLine(ints[i]);
            }           

            //Двумерные массивы
            int[,] Arrats = new int [5, 5];//двумерный массив 5х5
            Random randGen = new Random();//генератор случайных чисел
            Console.WriteLine("\n Двумерный массив");
            for (int i = 0; i<5; i++)
            {
                for(int j = 0; j<5; j++)
                {
                    Arrats[i, j] = randGen.Next(1, 100);//заполняет массив случайными числами от 1 до 100
                    Console.Write("{0}\t", Arrats[i, j]);// \t -табуляция
                }
            }
            Console.WriteLine("\n \n Ступенчатый массив");
           
            //Ступенчатый массив
            //это массив массивов
            //форма- тип [][] имя массива = new тип [размер] [];
            int g = 0;
            int[][] stepArray = new int[3][];//объявил ступенчатый массив
            //заполняю ступенчатый массив массивами
            stepArray[0] = new int[3];//первый массив равен 3м элементам
            stepArray[1] = new int[4];
            stepArray[2] = new int[5];

            //инициализирую ступенчатый массив через цикл
            for (g = 0; g <3; g++)
            {
                stepArray[0][g] = g;//заполняю элементы первого массива с помощью цикла
                Console.WriteLine("{0} \t", stepArray[0][g]);
            }
            Console.WriteLine("\n");

            for (g = 0; g < 4; g++)
            {
                stepArray[1][g] = g;
                Console.WriteLine("{0} \t", stepArray[1][g]);
            }
            Console.WriteLine(" \n");

            for (g = 0; g < 4; g++)
            {
                stepArray[1][g] = g;
                Console.WriteLine("{0} \t", stepArray[1][g]);
            }
            Console.ReadLine();
        }
    }
}
