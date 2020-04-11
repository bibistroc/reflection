using DBAccess;
using DBAccess.Models;
using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var coolRepository = new Repository<CoolTable>();

            var selectWithWhere = new CoolTable {
                Name = "asd",
                Status = StatusEnum.Active
            };

            string selectWithWhereOut = coolRepository.Select(selectWithWhere);

            Console.WriteLine("selectWithWhere: {0}", selectWithWhereOut);

            var selectWithoutWhere = new CoolTable();

            string selectWithoutWhereOut = coolRepository.Select(selectWithoutWhere);

            Console.WriteLine("selectWithoutWhere: {0}", selectWithoutWhereOut);

            var update = new CoolTable
            {
                Id = 1,
                Name = "asd",
                Status = StatusEnum.Active
            };

            string updateOut = coolRepository.Update(update);

            Console.WriteLine("update: {0}", updateOut);
        }
    }
}
