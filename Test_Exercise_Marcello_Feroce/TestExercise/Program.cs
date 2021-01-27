using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestExercise
{
    class Program
    {
        public static void Main(string[] args)
        {
            ManagementFadace system = new ManagementFadace();
            system.AddPerson("T", "Benny", 45, 100000);
            system.AddPerson("T", "Allan", 99, 100000);
            system.AddPerson("T", "Bjørk", 99, 100000);
            system.AddPerson("S", "My Name", 28, 5941);
            system.AddPerson("S", "Lone", 25, 5941);
            List<IPerson> allTeachers = system.GetAllTeachers();
            foreach (IPerson p in allTeachers)
            {
                Console.WriteLine(p.GetName() + " " + p.GetRole());
            }
            Console.ReadKey();

        }
    }
}
