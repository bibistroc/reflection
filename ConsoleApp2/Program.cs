using DBAccess;
using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var coolRepository = new Repository<CoolTable>();

            string coolTableSelect = coolRepository.Select();

            Console.WriteLine("Select for table {0} is: {1}", coolRepository.TableName, coolTableSelect);
        }
    }
}
