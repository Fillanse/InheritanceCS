using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Academy
{
    public class Teacher : Human
    {
        public const int SPECIALITY_WIDTH = 16;
        public const int EXPERIENCE_WIDTH = 3;
        public string Speciality { get; set; }
        public int Experience { get; set; }
        public Teacher(string firstName, string lastName, int age, string speciality, int experience) : base(firstName, lastName, age)
        {
            Speciality = speciality;
            Experience = experience;
        }
        public override string ToString() => base.ToString() + $"{Speciality,-SPECIALITY_WIDTH}|{Experience,-EXPERIENCE_WIDTH}|";
        public new static string TypeHeader() => Human.TypeHeader() + $"{"SPECIALITY",-Teacher.SPECIALITY_WIDTH} {"EXPERIENCE",-Teacher.EXPERIENCE_WIDTH} ";
    }
}
