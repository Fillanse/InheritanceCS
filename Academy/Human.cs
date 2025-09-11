using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.AccessControl;
using System.Text;
using System.Text.Unicode;
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

        private static List<Human>? SortByType<T>(Human[] group)
        {
            if (typeof(T) == typeof(Teacher)) return group.Where(human => human.GetType() == typeof(Teacher)).Cast<Human>().ToList();
            if (typeof(T) == typeof(Student)) return group.Where(human => human.GetType() == typeof(Student)).Cast<Human>().ToList();
            if (typeof(T) == typeof(Graduate)) return group.Where(human => human.GetType() == typeof(Graduate)).Cast<Human>().ToList();
            if (typeof(T) == typeof(Human)) return group.Where(human => human.GetType() == typeof(Human)).Cast<Human>().ToList();
            return null;
        }
        #endregion

        #region CONSOLE
        public static void Print(Human[] group)
        {
            foreach (Human human in group) Console.WriteLine(human.ToString());
            Console.WriteLine();
        }
        public static void PrintByType(Human[] group)
        {
            List<Human>? teachers = SortByType<Teacher>(group);
            List<Human>? students = SortByType<Student>(group);
            List<Human>? graduates = SortByType<Graduate>(group);
            List<Human>? humans = SortByType<Human>(group);
            if (teachers != null && teachers.Any())
            {
                Console.WriteLine(Teacher.TypeHeader());
                foreach (Human human in teachers) Console.WriteLine(human);
            }

            if (students != null && students.Any())
            {
                Console.WriteLine(Student.TypeHeader());
                foreach (Human human in students) Console.WriteLine(human);
            }
            if (graduates != null && graduates.Any())
            {
                Console.WriteLine(Graduate.TypeHeader());
                foreach (Human human in graduates) Console.WriteLine(human);
            }
            if (humans != null && humans.Any())
            {
                Console.WriteLine(TypeHeader());
                foreach (Human human in humans) Console.WriteLine(human);
            }
            Console.WriteLine();
        }
        #endregion

        #region FILE
        public void AppendToFile(string path)
        {
            if (!File.Exists(path)) using (File.Create(path)) { }
            ;
            using (StreamWriter sw = File.AppendText(path)) { sw.WriteLine(ToString()); }
        }
        public static void WriteToFile(Human[] group, string path)
        {
            using (StreamWriter sw = File.CreateText(path))
            {
                foreach (Human human in group) sw.WriteLine(human.ToString());
            }
        }
        public static void WriteToFileByType(Human[] group, string path)
        {
            using (StreamWriter sw = File.CreateText(path))
            {
                List<Human>? teachers = SortByType<Teacher>(group);
                List<Human>? students = SortByType<Student>(group);
                List<Human>? graduates = SortByType<Graduate>(group);
                List<Human>? humans = SortByType<Human>(group);

                if (teachers != null && teachers.Any())
                {
                    sw.WriteLine(Teacher.TypeHeader());
                    foreach (Human human in teachers) sw.WriteLine(human);
                    sw.WriteLine();
                }

                if (students != null && students.Any())
                {
                    sw.WriteLine(Student.TypeHeader());
                    foreach (Human human in students) sw.WriteLine(human);
                    sw.WriteLine();
                }

                if (graduates != null && graduates.Any())
                {
                    sw.WriteLine(Graduate.TypeHeader());
                    foreach (Human human in graduates) sw.WriteLine(human);
                    sw.WriteLine();
                }

                if (humans != null && humans.Any())
                {
                    sw.WriteLine(TypeHeader());
                    foreach (Human human in humans) sw.WriteLine(human);
                    sw.WriteLine();
                }
            }
        }
        public static Human[] ReadFromFile(string path)
        {
            if (!File.Exists(path)) return Array.Empty<Human>();

            List<Human> humans = new List<Human>();

            using (StreamReader sr = new StreamReader(path))
            {
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains("NAME") || string.IsNullOrWhiteSpace(line)) continue;
                    humans.Add(Parse(line));
                }
            }
            return humans.ToArray();
        }
        public static void ClearFile(string path)
        {
            File.WriteAllText(path,string.Empty);
        }
        #endregion
    }
}