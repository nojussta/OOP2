using System.Collections.Generic;

namespace Lab5
{
    /// <summary>
    /// This class is dedicated to a register
    /// </summary>
    public class Register
    {
        public string Year { get; set; }
        public List<GameInfo> AllMembers;
        
        /// <summary>
        /// Base register constructor
        /// </summary>
        /// <param name="year">Input of a year</param>
        public Register(string year)
        {
            this.Year = year;
            AllMembers = new List<GameInfo>();
        }

        /// <summary>
        /// Base register constructor
        /// </summary>
        /// <param name="year">Input of a year</param>
        /// <param name="allMembers">Input list of members</param>
        public Register(string year, List<GameInfo> allMembers)
        {
            this.Year = year;
            AllMembers = allMembers;
        }

        /// <summary>
        /// Empty base constructor
        /// </summary>
        public Register()
        {

        }
    }
}