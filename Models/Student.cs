using System;
using System.Collections.Generic;

namespace ClassroomApp.Model
{
    public class Department
    {
        public string Id {get; set;}
        public string Name {get; set;}
        public Professor Professor {get; set;}
        public IList<Student> Students  = new List<Student>();
    }

    public class Student:IPerson
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public double Height { get; set;} = 1.72d;
        public string Grade {get; set;}

        public IList<Subject>  Subjects = new List<Subject>();
    }

    public class Professor:IPerson
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public double Height { get; set;} = 1.72d;
        public EmploymentStatus Employment {get; set;}
    }
    public class Subject
    {
        public Guid Id {get; set;}
        public string Name {get; set;}
    }

    public enum Unit
    {
        Foot,
        Meters
    }
    public enum EmploymentStatus
    {
        FullTime,
        PartTime
    }
    public interface IPerson
    {
        /// <summary>
        /// The unique identifier for the character.
        /// </summary>
        int Id { get; }

        /// <summary>
        /// The name of the character.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The height of the character.
        /// </summary>
        double Height { get; }
    }
}