using System;

namespace Tuples
{
    class Program
    {
        static void Main(string[] args)
        {
            var tplik = tpl(5, 273.1f, "Mark");//неявная переменная tplik заполняется кортежем tpl
            Console.WriteLine("{0} {1} {2} {3}",tplik.Item1, tplik.Item2, tplik.Item3, tplik.Item4);//доступ к элементам кортежа через Item. <имя кортежа>.Item
            Console.ReadKey();
        }
        static Tuple <int, float, string, char> tpl(int zAxis,float xAxis, string name)//кортеж с именем tpl
        { //<int, float, string, char> типы, что будут содержаться в кортеже
            int x = 4 * zAxis; //результат будет 20
            float y = (float)(Math.Sqrt(xAxis));
            string s = "Hello! I am tuple " + name;
            char ch = (char)(name[0]);
            return Tuple.Create<int, float, string, char>(x, y, s, ch);
        }
    }
}
