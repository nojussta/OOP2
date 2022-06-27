using System;

namespace Lab4
{
    /// <summary>
    /// This class is dedicated to a partial class of Member
    /// </summary>
    public class Graduate : Member, IComparable<Graduate>, IEquatable<Graduate>
    {
        public double StartYear { get; set; }
        public string WorkPlace { get; set; }

        /// <summary>
        /// Graduate object constructor
        /// </summary>
        /// <param name="startingYear">Starting year</param>
        /// <param name="workPlace">Work place</param>
        /// <param name="Surname">Surname</param>
        /// <param name="Name">Name</param>
        /// <param name="birthDate">Birthday date</param>
        /// <param name="contact">Phone number</param>
        public Graduate(double startingYear, string workPlace, string Surname, string Name, DateTime birthDate, double contact) : base(Surname, Name, birthDate, contact)
        {
            this.StartYear = startingYear;
            this.WorkPlace = workPlace;
        }

        /// <summary>
        /// Comparing whether a graduate is an old one
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public override bool OldStudent(Member m)
        {
            DateTime date = new DateTime();
            if (m.BirthDate.Year + 25 <= date.Year)
                return true;
            return false;
        }

        /// <summary>
        /// Sorts graduates by their workplace
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public override int CompareTo(Member m)
        {
            Graduate s = (Graduate)m;
            if (this.WorkPlace.CompareTo(s.WorkPlace) != 0)
            {
                return this.WorkPlace.CompareTo(s.WorkPlace);
            }
            return 0;

        }

        public int CompareTo(Graduate other)
        {
            return 0;
        }

        public bool Equals(Graduate other)
        {
            return base.Equals(other) && this.StartYear.Equals(other.StartYear) && this.WorkPlace.Equals(other.WorkPlace);
        }

        /// <summary>
        /// Overriding a method of conversion to a .CSV format
        /// </summary>
        /// <returns></returns>
        public override string ToCSV()
        {
            return string.Join(";", "Senis", base.ToCSV(), StartYear, WorkPlace);
        }
    }
}