using System;

namespace DataTypeConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            short a = 20000, b = 20000;
            short c = (short)Add(a, b);//(short) - сужение типа с потерей данных используя явное приведение типов
            Console.WriteLine("c = {0}",c);//неверный ответ т.к. макс. значение short 32767, а запихиваем 40000
            try {
                short d = checked((short)Add(a, b));//checked обеспечивает проверку на переполнение
                Console.WriteLine("d = {0}", c);
            }
            catch(OverflowException ex) {//OverflowException тип исключения, ех имя
                Console.WriteLine(ex.Message);//генерируем исключение если получаем переполнение/потерю данных
            }
            unchecked {//unchecked - отключает проверку на переполнение в данном блоке кода
                short e = (short)Add(a, b);
                Console.WriteLine("e = {0}", c);
            }
            Console.ReadLine();
        }
        static int Add (int a, int b)//передаем значения short несмотря на то, что метод принимает int-овые значения. Но short поглащается диапазоном int
        {
            return a + b;//возвращает int-овый ответ и помещает его в short (10 строка)
        }
    }
}
