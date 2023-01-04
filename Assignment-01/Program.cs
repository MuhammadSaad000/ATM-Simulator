using System;
using System.Data;
using ATM_View;

namespace Assignment_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--ATM Machine--");
            AtmView v = new AtmView();
            v.selectUser();

        } 
    }
}
