using System;

namespace Cycles
{
    class Program
    {
        static void Main(string[] args)
        {
            //цикл for
            for(int u = 0; u<9; u++) { 
            Console.WriteLine("{0}",u);
            }
            //цикл foreach
            int[] digits = { 1, 2, 3, 4 };
            foreach (int o in digits) //int o должна быть того же типа что и массив, в неё будет получен элемент массива
                                        //после in указывается массив, ; не ставится
            Console.WriteLine("{0}", o);
            //циклы while do/while
            int i=0; //сначала необходимо объявить переменную
            while (i++ < 10)//после пишем условие. В данном случае увеличиваем i до тех пор пока она <10
                Console.WriteLine(i);
            do //цикл do/while
                Console.Write(i);//сначала выполняем условие
            while (i++ < 10);//потом проверяем и если оно true, то выполняем следущую итерацию
            Console.ReadLine();
        }
    }
}
