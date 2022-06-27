using System;

namespace Lab2
{
    /// <summary>
    /// This class is dedicated to a publication object
    /// </summary>
    public class Publications : IComparable<Publications>, IEquatable<Publications>
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }

        /// <summary>
        /// This is a constructor of a publication
        /// </summary>
        /// <param name="code">Publication code</param>
        /// <param name="title">Publication title</param>
        /// <param name="price">Publication price</param>
        public Publications(string code, string title, decimal price)
        {
            Code = code;
            Title = title;
            Price = price;
        }

        /// <summary>
        /// Override of a method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("| {0, 8} | {1, -15} | {2, 10} |", Code, Title, Price);
        }

        /// <summary>
        /// Override of a method
        /// </summary>
        /// <returns></returns>
        public int CompareTo(Publications other)
        {
            if (Code[0] > other.Code[0])
                return 1;
            return -1;
        }

        /// <summary>
        /// Override of a method
        /// </summary>
        /// <returns></returns>
        public bool Equals(Publications other)
        {
            return Title == other.Title;
        }

        /// <summary>
        /// Override of an operator
        /// </summary>
        /// <returns></returns>
        public static bool operator <(Publications s, Publications s1)
        {
            if (s.Price != s1.Price)
                return s.Price < s1.Price;
            else
                return s.Title[0] > s1.Title[0];
        }

        /// <summary>
        /// Override of an operator
        /// </summary>
        /// <returns></returns>
        public static bool operator >(Publications s, Publications s1)
        {
            if (s.Price != s1.Price)
                return s.Price > s1.Price;
            else
                return s.Title[0] < s1.Title[0];
        }
    }
}