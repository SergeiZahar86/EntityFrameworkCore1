using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore1
{
    class Program
    {
        static void Main(string[] args)
        {
            using(incubeContext db = new incubeContext())
            {
                var tbpart = db.TbPart.ToList();
                Console.WriteLine("Список объектов партии");
                foreach(TbPart tb in tbpart)
                {
                    Console.WriteLine($"{tb.PartId}");
                }
            }
            Console.ReadLine();
        }
    }
}
