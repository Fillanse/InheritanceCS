using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Academy
{
    public class Human
    {
        public const int TYPE_WIDTH = 10;
        public const int FIRST_NAME_WIDTH = 16;
        public const int LAST_NAME_WIDTH = 16;
        public const int AGE_WIDTH = 4;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Human(string firstName, string lastName, int age) { FirstName = firstName; LastName = lastName; Age = age; }

        #region STRINGS

        public override string ToString() => $"{FirstName,-FIRST_NAME_WIDTH}|{LastName,-LAST_NAME_WIDTH}|{Age,-AGE_WIDTH}|";
        public static string TypeHeader() => $"{"NAME",-FIRST_NAME_WIDTH} {"LASTNAME",-LAST_NAME_WIDTH} {"AGE",-AGE_WIDTH} ";
        public static Human Parse(string line)
        {
            string[] buffer = line.Contains('|')
            ? line.Split("|", StringSplitOptions.RemoveEmptyEntries)
            : line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            return Factory(buffer);
        }
        #endregion

        #region FACTORIES
        private static Human Factory(string[] args) => args.Length switch
        {
            3 => new Human(args[0], args[1], int.Parse(args[2])),
            5 => new Teacher(args[0], args[1], int.Parse(args[2]), args[3], int.Parse(args[4])),
            7 => new Student(args[0], args[1], int.Parse(args[2]), args[3], args[4], int.Parse(args[5]), int.Parse(args[6])),
            8 => new Graduate(args[0], args[1], int.Parse(args[2]), args[3], args[4], int.Parse(args[5]), int.Parse(args[6]), args[7]),
            _ => throw new Exception("Args error")
        };

        private static T[] SortByType<T>(Human[] group) => group.Where(human => human.GetType() == typeof(T)).Cast<T>().ToArray();
        #endregion

        #region CONSOLE
        public static void Print(Human[] group)
        {
            foreach (Human human in group) Console.WriteLine(human);
            Console.WriteLine();
        }
        private static void Print<T>(Human[] group, string header)
        {
            T[] humans = SortByType<T>(group);
            if (!humans.Any()) return;

            Console.WriteLine(header);
            foreach (T human in humans) Console.WriteLine(human);
            Console.WriteLine();
        }
        public static void PrintSorted(Human[] group)
        {
            Print<Teacher>(group, Teacher.TypeHeader());
            Print<Student>(group, Student.TypeHeader());
            Print<Graduate>(group, Graduate.TypeHeader());
            Print<Human>(group, TypeHeader());
        }

        #endregion

        #region FILE
        public void AppendToFile(string path) => File.AppendAllText(path, this + "\n");
        public static void WriteToFile(Human[] group, string path) => File.WriteAllLines(path, group.Select(h => h.ToString()));
        private static void WriteToFile<T>(Human[] group, string header, StreamWriter sw)
        {
            T[] humans = SortByType<T>(group);

            if (!humans.Any()) return;

            sw.WriteLine(header);
            foreach (T human in humans) sw.WriteLine(human);
            sw.WriteLine();
        }
        public static void WriteToFileSorted(Human[] group, string path)
        {
            using var sw = new StreamWriter(path);
            WriteToFile<Teacher>(group, Teacher.TypeHeader(), sw);
            WriteToFile<Student>(group, Student.TypeHeader(), sw);
            WriteToFile<Graduate>(group, Graduate.TypeHeader(), sw);
            WriteToFile<Human>(group, TypeHeader(), sw);
        }

        public static Human[] ReadFromFile(string path)
        {
            if (!File.Exists(path)) return Array.Empty<Human>();

            return File.ReadLines(path)
            .Where(line => !string.IsNullOrWhiteSpace(line) && !line.Contains("NAME")).Select(Parse).ToArray();
        }
        public static void ClearFile(string path)
        {
            File.WriteAllText(path, string.Empty);
        }
        #endregion
    }
}