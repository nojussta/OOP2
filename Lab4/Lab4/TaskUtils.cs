using System;
using System.Collections.Generic;
using System.Globalization;

namespace Lab4
{
    /// <summary>
    /// This class is dedicated to complete tasks and calculations
    /// </summary>
    public class TaskUtils : System.Web.UI.Page
    {
        /// <summary>
        /// Students which are studying currently
        /// </summary>
        /// <param name="register">Not filtered student register</param>
        /// <param name="date">Input date</param>
        /// <returns></returns>
        public Register GetCurrentYearList(Register register, DateTime date)
        {
            Register r1 = new Register(register.StudyYear);
            double currD = date.Year;

            for (int i = 0; i < register.AllMembers.Count; i++)
            {
                if (register.AllMembers[i].GetType().Name.Equals("Student"))
                {
                    Student s = (Student)register.AllMembers[i];
                    if (s.StartDate + 2 <= currD)
                    {
                        r1.AllMembers.Add(register.AllMembers[i]);
                    }
                }
                else
                {
                    Graduate g = (Graduate)register.AllMembers[i];
                    if (g.StartYear + 2 <= currD)
                    {
                        r1.AllMembers.Add(register.AllMembers[i]);
                    }
                }
            }
            return r1;

        }

        /// <summary>
        /// Sorts by criteria
        /// </summary>
        /// <param name="list">Member register input list</param>
        /// <returns></returns>
        public static List<Member> Sort(List<Member> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[j].CompareTo(list[min]) < 0)
                        min = j;
                }
                Member temporary = list[min];
                list[min] = list[i];
                list[i] = temporary;
            }
            return list;
        }

        /// <summary>
        /// Gets birthday data by criteria
        /// </summary>
        /// <param name="register">Register input data</param>
        /// <returns></returns>
        public static string GetBirthdays(Register register)
        {
            int[] months = new int[12];
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < register.AllMembers.Count; j++)
                {
                    if (register.AllMembers[j].BirthDate.Month - 1 == i)
                        months[i]++;
                }
            }
            string result = BirthdaysToString(months, register);
            return result;
        }

        /// <summary>
        /// Puts birthdays value to a string
        /// </summary>
        /// <param name="months">Input number of months</param>
        /// <param name="register">Input register data</param>
        /// <returns></returns>
        public static string BirthdaysToString(int[] months, Register register)
        {
            int max = FindMaximum(months);
            string stringValue = string.Format("{0} : ", register.StudyYear);
            for (int i = 0; i < months.Length; i++)
            {
                if (months[i] == max)
                    stringValue += CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i + 1) + " ";
            }
            return stringValue;
        }

        /// <summary>
        /// Gets the biggest falue to correctly sort the data
        /// </summary>
        /// <param name="months">Input number of months</param>
        /// <returns></returns>
        public static int FindMaximum(int[] months)
        {
            int biggest = 0;
            for (int i = 0; i < months.Length; i++)
            {
                if (months[i] > biggest)
                    biggest = months[i];
            }
            return biggest;
        }
    }
}