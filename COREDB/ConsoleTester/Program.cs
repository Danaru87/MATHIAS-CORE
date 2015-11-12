using CoreDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTester
{
    class Program
    {
        static void Main(string[] args)
        {
            var sqlite = DBMANAGER.CONNECT();
            Console.ReadLine();
        }
    }
}
