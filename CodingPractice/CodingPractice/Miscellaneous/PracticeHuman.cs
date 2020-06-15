using System;
using System.Collections.Generic;
using System.Text;

namespace CodingPractice
{
    class PracticeHuman
    {
        public static void Test()
        {
            Man aMan = new Man("John", "Doe", Convert.ToDateTime("12/08/1994"));
            Console.WriteLine(aMan.Age());
            Console.WriteLine(aMan.Yell());
            Console.WriteLine(aMan.IsWorking);

            Console.WriteLine("");
            Console.WriteLine("A WOMAN!");
            Woman aWoman = new Woman("Jane", "Doe", Convert.ToDateTime("01/31/1997"));
            Console.WriteLine(aWoman.Age());
            Console.WriteLine(aWoman.Yell());
            Console.WriteLine(aWoman.IsWorking);
        }

    }

    abstract class Human
    {
        public string FirstName;
        public string LastName;
        public DateTime DateOfBirth;
        protected bool Working;
        public int Age()
        {
            return (int)((DateTime.Now - DateOfBirth).TotalDays / 365.2425);
        }
        public abstract string Yell();
        public abstract string FullName();
    }

    class Man : Human
    {
        public string Gender = "Male";
        public Man(string first, string last, DateTime dob)
        {
            this.FirstName = first;
            this.LastName = last;
            this.DateOfBirth = dob;
            this.Working = false;
        }
        public override string Yell()
        {
            return "YOO!";
        }
        public override string FullName()
        {
            return $"Mr. { FirstName} { LastName }";
        }
        public bool IsWorking { get => Working; }
    }

    class Woman : Human
    {
        public string Gender = "Female";
        public Woman(string first, string last, DateTime dob)
        {
            this.FirstName = first;
            this.LastName = last;
            this.DateOfBirth = dob;
            this.Working = true;
        }

        public override string Yell()
        {
            return "HEYY!";
        }
        public override string FullName()
        {
            return $"Ms. { FirstName} { LastName }";
        }
        public bool IsWorking { get => Working; }
    }
}
