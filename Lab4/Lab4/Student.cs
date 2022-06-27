using System;

namespace Lab4
{
    /// <summary>
    /// This class is dedicated to a partial class of Member
    /// </summary>
    public class Student : Member, IComparable<Student>, IEquatable<Student>
    {
        public string CodeID { get; set; }
        public double StartDate { get; set; }

        /// <summary>
        /// This is a Student object constructor
        /// </summary>
        /// <param name="codeID">Individual student code</param>
        /// <param name="startDate">The start of studying year</param>
        /// <param name="Surname">Surname</param>
        /// <param name="Name">Name</param>
        /// <param name="birthDate">Birtday date</param>
        /// <param name="phoneContact">Phone number</param>
        public Student(string codeID, double startDate, string Surname, string Name, DateTime birthDate, double phoneContact) : base(Surname, Name, birthDate, phoneContact)
        {
            this.CodeID = codeID;
            this.StartDate = startDate;
        }

        /// <summary>
        /// Gets information about studying length
        /// </summary>
        /// <returns></returns>
        public double GetCourse()
        {
            DateTime date = new DateTime();
            return date.Year - StartDate;
        }

        /// <summary>
        /// Comparing whether a graduate is an old one
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public override bool OldStudent(Member m)
        {
            DateTime date = new DateTime();
            if (m.BirthDate.Year + 22 <= date.Year)
                return true;
            return false;
        }

        public override int CompareTo(Member m)
        {
            Student s = (Student)m;
            if (this.GetCourse().CompareTo(s.GetCourse()) != 0)
            {
                return this.Surname.CompareTo(s.Surname);
            }
            else if (this.GetCourse().CompareTo(s.GetCourse()) != 0)
            {
                return this.GetCourse().CompareTo(s.GetCourse());
            }
            return 0;
        }

        /// <summary>
        /// Overriding a method of conversion to a .CSV format
        /// </summary>
        /// <returns></returns>
        public override string ToCSV()
        {
            return string.Join(";", "Studentas", base.ToCSV(), CodeID, GetCourse());
        }

        public bool Equals(Student other)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(Student other)
        {
            return 0;
        }
    }
}