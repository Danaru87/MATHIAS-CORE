using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly thisAssem = Assembly.GetExecutingAssembly();
            List<Type> types = thisAssem.GetTypes().ToList();
            
            foreach (Type type in types)
            {
                Console.WriteLine(type.Name);
            }

            foreach (PropertyInfo prop in new test().GetType().GetProperties())
            {
                Console.WriteLine(prop.PropertyType.ToString());
            }

            Console.ReadLine();
        }
    }
}
