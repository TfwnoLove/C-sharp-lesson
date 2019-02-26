using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariableContext
{
    class Program
    {
        static string uname = "name";
        const int cnstnt = 10; //это констатнта. Её значение нельзя изменять при выполнении кода.Инициализируется при объявлении
                //константы неявно статические. Объявлять её как static не нужно
        static void Main(string[] args)
        {
            string uname = "myName";//локальные переменные в приоритете
            Console.WriteLine(uname);//потому консоль выведет myName
            Console.ReadLine();
            return;
        }
    }
}
