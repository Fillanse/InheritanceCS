
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Academy
{
    public class Student : Human
    {
        public const int SPECIALITY_WIDTH = 16;
        public const int GROUP_WIDTH = 16;
        public const int RATING_WIDTH = 8;
        public const int ATTENDANCE_WIDTH = 12;
        public string Speciality { get; set; }
        public string Group { get; set; }
        public double Rating { get; set; }
        public double Attendance { get; set; }

        public Student(string firstName, string lastName, int age, string speciality, string group, double raiting, double attendance) : base(firstName, lastName, age)
        {
            Speciality = speciality;
            Group = group;
            Rating = raiting;
            Attendance = attendance;
        }

        public override string ToString() => base.ToString() + $"{Speciality,-SPECIALITY_WIDTH}|{Group,-GROUP_WIDTH}|{Rating,-RATING_WIDTH}|{Attendance,-ATTENDANCE_WIDTH}|";
        public new static string TypeHeader() => Human.TypeHeader() + $"{"SPECIALITY",-Student.SPECIALITY_WIDTH} {"GROUP",-Student.GROUP_WIDTH} {"RATING",-Student.RATING_WIDTH} {"ATTENDANCE",-Student.ATTENDANCE_WIDTH} ";
    }
}