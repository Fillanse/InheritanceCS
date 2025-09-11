using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Human[] group = {
                new Teacher("Immanuel", "Kant", 79, "Philosophy", 40),
                new Teacher("Georg", "Hegel", 61, "Philosophy", 40),
                new Teacher("Jean-Paul ", "Sartre", 74, "Philosophy", 30),
                new Teacher("Albert", "Camus", 46, "Philosophy", 20),
                new Teacher("Stephen ", "Hawking", 76, "Physics", 40),
                new Teacher("Albert", "Einstein", 76, "Physics", 40),
                new Graduate("Vincent", "Vega", 40, "Crimilal", "Pulp Fiction", 70, 30, "Stupidity"),
                new Graduate("Jules", "Winnfield", 42, "Criminal", "Pulp Fiction", 100, 100, "Walk the Earth"),
                new Student("Michael", "Scott", 43, "Management", "The Office", 100, 10),
                new Student("Dwight", "Schrute", 39, "Sales", "The Office", 60, 100),
                new Student("Jim", "Halpert", 26, "Sales", "The Office", 100, 60),
                new Human("Ozzy", "Osbourne", 76),
                new Human("John", "Bonham", 32),
                new Human("Eddie", "Van Halen", 65),
                new Human("Chris", "Cornell", 52),
            };

            string fileSorted = ".\\groupByType.txt";
            string file = ".\\group.txt";

#if !PRINT
            Console.WriteLine("\n=== ORIGINAL GROUPS ===");

            Console.WriteLine("\n Sorted group:");
            Human.PrintSorted(group);

            Console.WriteLine("Unsorted group:");
            Human.Print(group);

            Human man = Human.Parse("Freddie Mercury 45 Rock 25");
            Console.WriteLine($"{man} | Type: {man.GetType().Name}");
            Console.WriteLine();
#endif

#if !WRITE_TO_FILE
            Human.WriteToFileSorted(group, fileSorted);
            Human.WriteToFile(group, file);

            man.AppendToFile(file);
#endif

#if !READ_FROM_FILE

            Human[] groupFromFileSorted = Human.ReadFromFile(fileSorted);
            Human[] groupFromFile = Human.ReadFromFile(file);

            Console.WriteLine("\n=== READ FROM FILES ===");
            
            Console.WriteLine("\nSorted group from file:");
            Human.PrintSorted(groupFromFileSorted);

            Console.WriteLine("Unsorted group from file:");
            Human.Print(groupFromFile);

            Human.ClearFile(fileSorted);
            Human.ClearFile(file);

#endif



        }
    }
}
