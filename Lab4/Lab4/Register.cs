using System.Collections.Generic;

namespace Lab4
{
    /// <summary>
    /// This class is dedicated to a register
    /// </summary>
    public class Register
    {
        public int StudyYear { get; set; }
        public List<Member> AllMembers;

        /// <summary>
        /// Register constructor with one parameter
        /// </summary>
        /// <param name="studyYear">Input of the studying year</param>
        public Register(int studyYear)
        {
            this.StudyYear = studyYear;
            this.AllMembers = new List<Member>();
        }

        /// <summary>
        /// Register constructor with two parameters
        /// </summary>
        /// <param name="studyYear">Input of the studying year</param>
        /// <param name="allMembers">Input of a student list</param>
        public Register(int studyYear, List<Member> allMembers)
        {
            this.StudyYear = studyYear;
            this.AllMembers = allMembers;
        }
    }
}