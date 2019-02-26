using System;
using System.Text;

namespace Hello
{
     class Program
     {

        static void Main(string[] args)
        {
            string strA = "STRING";
            string strB = "strings";

            string searchText = "aaa";//подстрочка
            string text = "This text contains 'aaa' string";//строка в которой ищем

            Console.WriteLine(string.Compare(strA, strB, StringComparison.CurrentCultureIgnoreCase ));
            //String.Compare cравнивает строки
                //StringComparison.CurrentCultureIgnoreCase сравнить без учета регистра
                //без StringComparison.CurrentCultureIgnoreCase учитывает регистр 
            //с кирилицей не работает (в данном коде)
            //-1 - strA предшествует strB в порядке сортировки.
            //0  - strA занимает ту же позицию в порядке сортировки, что и объект strB.
            //1  - strA следует за strB в порядке сортировки

            Console.WriteLine("Строки равны, когда они написаны заглавными буквами? {0}",
                string.Compare(strA.ToUpper(), strB.ToUpper()) == 0 ? "Да" : "Нет");

            if (text.Contains(searchText))//если текст СОДЕРЖИТ (переменная которую ищем в тексте)
            {
                Console.WriteLine("Содержит {0}", searchText);//в {0} подставляем searchText
            }
            else
            {
                Console.WriteLine("Не содержит {0}", searchText);
            }
            string s4 = string.Concat(strA,strB, "!!!");//конкатенация - складывает 2 строки слитно и добавляет "!!!"
            Console.WriteLine(s4);

            string s1 = "s1";
            string s2 = "s2";
            string s5 = "apple";
            string s6 = "a day";
            string s7 = "keeps";
            string s8 = "a doctor";
            string s9 = "away";
            string[] values = new string[] { s5, s6, s7, s8, s9 };

            String s10 = String.Join(" ", values);//Join складывает строки. Имеет 2 параметра: строку-разделитель (в данном случае пробел) и массив строк
            Console.WriteLine(s10);
            // результат: строка "apple a day keeps a doctor away"

            char ch = 'o';
            int indexOfChar = s8.IndexOf(ch); //найти в строке s8 значение символа сh
            Console.WriteLine(indexOfChar);// равно 3 т.к. отсчитывает символы игнорируя пробелы, а "о" является в строке 3м символом

            /*конкатенация строк (сложение строк)*/
            string sSumm = s5 + s6 + s7 + s8 + s9;//cкладывает строки без пробела
            Console.WriteLine(sSumm);

            /*разделение строк*/
            string strng = "Возьмите меня на работу";
            string[] words = strng.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);//

            foreach (string s in words)
            {
                Console.WriteLine(s);
            }
            /*обрезка строк*/
            //Для обрезки начальных или концевых символов используется функция Trim
            //strng = strng.Trim();
            strng = strng.Trim('В', 'у');//обрезаем В и р
            Console.WriteLine(strng);

            /*создание новой строки и присоеденение её к началу исходной*/
            //метод PadLeft
            string s11 = "Hello World!";
            Console.WriteLine(s11.PadLeft(20, '-'));

            /*создание новой строки и присоеденение её к концу исходной*/
            //метод PadRight
            string s12 = "Hello World!";
            Console.WriteLine(s12.PadRight(20, '-'));// String.PadRight создает новую строку, присоединяя в конец исходной строки заполняющие символы в количестве, необходимом для достижения указанной общей длины.

            /*вставка подстроки*/
            //метод Insert
            string s13 = "Хороший день";
            string subString = "замечательный ";

            s13 = s13.Insert(8, subString);//2 параметра. "8" это кол-во символов которое нужно отступить от начала строки. subString - подстрока которую нужно вставить
            Console.WriteLine(s13);

            /*удаление строк*/
            //метод Remove
            int index = s13.Length - 1;//индекс последнего символа
            s13 = s13.Remove(index);
            Console.WriteLine(s13);
            s13 = s13.Remove(0, 2);// вырезаем первые два символа
            Console.WriteLine(s13);

            /*получение подстроки из строки*/
            //метод Substring
            Console.WriteLine(s13.Substring(0, 5));//0-номер символа откуда начинать отсчет для создания подстроки, 5-номер символа до которого будет идти подстрока
            Console.WriteLine("Hello \n\n\a");//Вывод слова, 2 пустые строки (\n) и сигнал (\a)

            /*Cтроки и равенство*/
            //сравнение строк может осуществляться с помощью метода Equals или же оператором ==
            Console.WriteLine("s1 == s2: {0}", s1 == s2);//вместо  {0} будет подставлен true/false в зависимости от результата проверки

            /*типа System.Text.StringBuilder*/
            //Внутри пространства имен System.Text находится класс StringBuilder
            StringBuilder sb = new StringBuilder("Операционные системы:");
            sb.Append("\n");
            sb.AppendLine("Windows");//метод AppendLine автоматически добавляет \n
            sb.AppendLine("Linux");
            sb.AppendLine("Mac OS x");
            Console.WriteLine(sb.ToString());
            Console.WriteLine("B sb {0} cимволов", sb.Length);
            Console.ReadLine();
            //Когда мы выполняем какой-нибудь метод класса String, 
            //система создает новый объект в памяти с выделением ему достаточного места. Это сказывается на производительности
            //Потому лучше использовать класс StringBuilder, который представляет динамическую строку.
        }
    }
}
