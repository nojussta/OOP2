using System;

namespace Lab2
{
    /// <summary>
    /// This class is dedicated to a subscriber object
    /// </summary>
    public class Subscribers : IComparable<Subscribers>, IEquatable<Subscribers>
    {
        public string Surname { get; set; }
        public string Adress { get; set; }
        public int RangeStart { get; set; }
        public int RangeDuration { get; set; }
        public string PublicationCode { get; set; }
        public int PublicationAmount { get; set; }

        /// <summary>
        /// This is a constructor of a subscriber
        /// </summary>
        /// <param name="surname">Subscribers surname</param>
        /// <param name="adress">Subscribers adress</param>
        /// <param name="rangeStart">Starting range</param>
        /// <param name="rangeDuration">Range duration</param>
        /// <param name="publicationCode">Publications' code</param>
        /// <param name="publicationAmount">Publications' amount</param>
        public Subscribers(string surname, string adress, int rangeStart, int rangeDuration, string publicationCode, int publicationAmount)
        {
            this.Surname = surname;
            this.Adress = adress;
            this.RangeStart = rangeStart;
            this.RangeDuration = rangeDuration;
            this.PublicationCode = publicationCode;
            this.PublicationAmount = publicationAmount;
        }

        /// <summary>
        /// Overriding a method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("| {0, 8} | {1, -15} | {2, -20} | {3, 5} | {4, 5} | {5, 5} |", 
                PublicationCode, Surname, Adress, RangeStart, RangeDuration, PublicationAmount);
        }

        /// <summary>
        /// Overriding a method
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Subscribers other)
        {
            if (PublicationCode[0] > other.PublicationCode[0])
                return 1;
            return -1;
        }

        /// <summary>
        /// Overriding a method
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Subscribers other)
        {
            return Surname.Equals(other.Surname);
        }
    }
}