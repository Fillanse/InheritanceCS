using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Academy
{
    public class Graduate : Student
    {
        public const int SUBJECT_WIDTH = 16;
        string Subject { get; set; }
        public Graduate(string firstName, string lastName, int age, string speciality, string group, double raiting, double attendance, string subject) : base(firstName, lastName, age, speciality, group, raiting, attendance)
        {
            Subject = subject;
        }
        public override string ToString() => base.ToString() + $"{Subject,-SUBJECT_WIDTH}|";
        public new static string TypeHeader() => Student.TypeHeader() + $"{"SUBJECT",-Graduate.SUBJECT_WIDTH} ";

    }
}