using System;

namespace ImplicitlyTypedLocalVariables
{
    class Program
    {
        static void Main(string[] args)
        {
            //неявно типизированные локальные переменные с помощью var
            var A = 0;
            var s = "String";//компилятор сам определяет тип переменной по первому значению
            //var используется для локальных переменных в методе или же свойств
            //var не может использовать null т.к. компилятор не сможет определить тип
        }
    }
}
