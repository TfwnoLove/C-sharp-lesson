using System;

namespace SortingArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            //создаю массив типа string, длинной 3 используя класс Array
            Array strn = Array.CreateInstance(typeof(string), 3);//CreateInstance cтатический метод
                                                                 //используется если неизвестен тип элементов массива

            //инициализирую первые два поля массива
            strn.SetValue("Brand", 0);
            strn.SetValue("Model", 1);

            //cчитываем данные из массива
            string s = (string)strn.GetValue(1);
            Console.WriteLine("Value s it is {0}", s);

            //пример вызовов Clone и Copy
            string[] arr1 = (string[])strn.Clone();//Clone создает новый массив. strn копируется в arr1
            Array.Copy(strn, arr1, strn.Length);//Copy требует наличие уже объявленного массива arr1

            //Сортировка массива методом Sort()
            Console.WriteLine("\n Сортировка массива методом Sort()");
            int[] vs = { -15, -10, 25, 14, -1, 32 };

            Console.WriteLine("До сортировки: ");
            foreach (int i in vs)
                Console.Write("\t {0}", i);

            Console.WriteLine("\nПосле сортировки: ");
            Array.Sort(vs);
            foreach (int i in vs)
                Console.Write("\t {0}", i);
            Console.ReadLine();
        }

        //Массив как параметр (пример)
        static Array arrChange(Array vs)
        {
            //меняем что-то в массиве
            return vs;
        }
    }
}
