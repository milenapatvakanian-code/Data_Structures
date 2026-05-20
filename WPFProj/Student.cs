using System;
using System.Collections.Generic;
using System.Text;

namespace WPFProj
{
    internal class Student : IComparable<Student>
    {
        public Student(int id, string name, Gender gender)
        {
            StudentID = id;
            Name = name;
            Gender = gender;
        }
        public int StudentID { get; private set; }
        public string Name { get; private set; }
        public Gender Gender { get; private set; }

        public int CompareTo(Student other)
        {
            
            return StudentID.CompareTo(other.StudentID);
        }


    }
 }
