using System;

namespace Lab4
{
    /// <summary>
    /// This class is dedicated to a Member object
    /// </summary>
    public class Member : IComparable<Member>, IEquatable<Member>
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public double Contact { get; set; }

        /// <summary>
        /// Member object constructor
        /// </summary>
        /// <param name="Surname">Sruname</param>
        /// <param name="Name">Name</param>
        /// <param name="birthDate">Birthday date</param>
        /// <param name="contact">Telephone number</param>
        public Member(string Surname, string Name, DateTime birthDate, double contact)
        {
            this.Surname = Surname;
            this.Name = Name;
            this.BirthDate = birthDate;
            this.Contact = contact;

        }

        public virtual int CompareTo(Member other)
        {
            if (this.Surname.CompareTo(other.Surname) != 0)
            {
                return this.Surname.CompareTo(other.Surname);
            }
            else if (this.Name.CompareTo(other.Name) != 0)
            {
                return this.Name.CompareTo(other.Name);
            }
            return 0;
        }

        /// <summary>
        /// Comparing whether a student is an old one
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public virtual bool OldStudent(Member m)
        {
            return false;
        }

        public bool Equals(Member other)
        {
            return this.Surname.Equals(other.Surname) && this.Name.Equals(other.Name);
        }

        public override string ToString()
        {
            return string.Format("| {0, -15} | {1, -15} | {2:yyyy/MM/dd}  | {3, 15} |", Surname, Name, BirthDate, Contact);
        }

        /// <summary>
        /// Overriding a method of conversion to a .CSV format
        /// </summary>
        /// <returns></returns>
        public virtual string ToCSV()
        {
            return string.Join(";", Surname, Name, BirthDate, Contact);
        }
    }
}