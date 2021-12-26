using System;
using Core;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var da = new DataReceive();
            var bp = da.GetEmployees();
            Console.WriteLine(bp[0].Name);
        }
    }
}
