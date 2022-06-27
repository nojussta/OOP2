using System;
using System.Collections.Generic;

namespace Lab2
{
    /// <summary>
    /// This is a class dedicated to solving the task
    /// </summary>
    public class TaskUtils : System.Web.UI.Page
    {
        /// <summary>
        /// This method calculates the value of subscribers using a publication
        /// </summary>
        /// <param name="list"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static decimal CalculateValue(LinkedList<Publications> list, Subscribers publication)
        {
            decimal value = 0;
            for (list.Start(); list.Exist(); list.Next())
            {
                if (list.TakeData().Code == publication.PublicationCode)
                {
                    value = publication.RangeDuration * list.TakeData().Price * publication.PublicationAmount;
                }
            }
            return value;
        }

        /// <summary>
        /// This method searches for the highest value of subscribers per month
        /// </summary>
        /// <param name="MonthlySubs">Input list of string which contains linked list data</param>
        /// <param name="list1">Input of a publications linked list data</param>
        /// <param name="list">Input of a publications linked list data</param>
        /// <returns></returns>
        public static string SearchForHighest(LinkedList<string> MonthlySubs, LinkedList<Subscribers> list1, LinkedList<Publications> list)
        {
            decimal biggest = 0;
            string oneString = "";
            for (MonthlySubs.Start(); MonthlySubs.Exist(); MonthlySubs.Next())
            {
                decimal value = 0;
                for (list1.Start(); list1.Exist(); list1.Next())
                {
                    if (MonthlySubs.TakeData() == list1.TakeData().PublicationCode)
                    {
                        value += CalculateValue(list, list1.TakeData());
                    }

                }
                if (value > biggest)
                {
                    oneString = string.Format("{0}", MonthlySubs.TakeData());
                    biggest = value;
                }
                else if (value == biggest)
                {
                    oneString += string.Format(" {0}", MonthlySubs.TakeData());
                }
            }
            return oneString;
        }

        /// <summary>
        /// This method gets the highest value
        /// </summary>
        /// <param name="i">Input int of an index</param>
        /// <param name="list">Input of a publications linked list data</param>
        /// <param name="list1">Input of a subscribers linked list data</param>
        /// <returns></returns>
        public static string GetHighest(int i, LinkedList<Publications> list, LinkedList<Subscribers> list1)
        {
            LinkedList<string> monthlyPublications = new LinkedList<string>();
            for (list.Start(); list.Exist(); list.Next())
            {
                for (list1.Start(); list1.Exist(); list1.Next())
                {
                    if (list.TakeData().Code == list1.TakeData().PublicationCode && list1.TakeData().RangeStart <= i + 1 && list1.TakeData().RangeStart + list1.TakeData().RangeDuration >= i + 1)
                    {
                        string currVal = list.TakeData().Code;
                        monthlyPublications.Add(currVal);
                    }
                }
            }
            string highest = SearchForHighest(monthlyPublications, list1, list);
            return highest;
        }

        /// <summary>
        /// This method adds certain chosen objects to a list
        /// </summary>
        /// <param name="list">Input of a publications linked list data</param>
        /// <param name="list1">Input of a subscribers linked list data</param>
        /// <param name="results">Input of a subscribers linked list data</param>
        /// <param name="Title">Input string of an object title</param>
        /// <param name="index">Input int of an index</param>
        public static void AddToList(LinkedList<Publications> list, LinkedList<Subscribers> list1, LinkedList<Subscribers> results, string Title, int index)
        {
            for (list1.Start(); list1.Exist(); list1.Next())
            {
                for (list.Start(); list.Exist(); list.Next())
                {
                    if (list.TakeData().Title == Title && list.TakeData().Code == list1.TakeData().PublicationCode && Contains(index, list1.TakeData()))
                    {
                        results.Add(list1.TakeData());
                    }
                }
            }
        }

        /// <summary>
        /// This method outputs a list which contains certain chosen data
        /// </summary>
        /// <param name="list1">Input of a publications linked list data</param>
        /// <returns></returns>
        public static List<string> GetList(LinkedList<Publications> list1)
        {
            List<string> allPublications = new List<string>();
            for (list1.Start(); list1.Exist(); list1.Next())
            {
                if (!allPublications.Contains(list1.TakeData().Title))
                {
                    allPublications.Add(list1.TakeData().Title);
                }
            }
            return allPublications;
        }

        /// <summary>
        /// This is a method which gets all the incomes of publications and puts it into a decimal list
        /// </summary>
        /// <param name="list1">Input of a publications linked list data</param>
        /// <param name="list2">Input of a subscribers linked list data</param>
        /// <returns></returns>
        public static LinkedList<decimal> IncomeSum(LinkedList<Publications> list1, LinkedList<Subscribers> list2)
        {
            List<string> allPublications = GetList(list1);
            LinkedList<decimal> SummedIncome = GetIncomeSum(allPublications, list1, list2);
            return SummedIncome;
        }

        /// <summary>
        /// This method calculates the maximum income per month
        /// </summary>
        /// <param name="list1">Input of a subscribers linked list data</param>
        /// <param name="list">Input of a publications linked list data</param>
        /// <param name="fileName">Input string of a file name</param>
        /// <returns></returns>
        public static List<string> MonthlyIncomeMax(LinkedList<Subscribers> list1, LinkedList<Publications> list, string fileName)
        {
            List<string> newList = new List<string>();

            for (int i = 0; i < 12; i++)
            {
                string Title = GetHighest(i, list, list1);
                newList.Add(Title);
            }
            InOutUtils.PrintMonthlyIncome(newList, fileName);
            return newList;
        }

        /// <summary>
        /// This method calculates the lowest income per month
        /// </summary>
        /// <param name="list1">Input of a publications linked list data</param>
        /// <param name="list2">Input of a subscribers linked list data</param>
        /// <param name="fileName">Input string of a file name</param>
        /// <returns></returns>
        public static LinkedList<string> LowIncome(LinkedList<Publications> list1, LinkedList<Subscribers> list2, string fileName)
        {
            decimal average = GetAverageIncome(list1, list2);
            List<string> Titles = GetList(list1);
            List<string> newTitles = new List<string>();
            for (int i = 0; i < Titles.Count; i++)
            {
                decimal av = GetAverage(Titles[i], list2, list1);
                if (av < average)
                {
                    newTitles.Add(Titles[i]);
                }
            }
            list1.Sort();
            InOutUtils.PrintChosenList(newTitles, list1, fileName);
            LinkedList<string> list = InOutUtils.PrintChosenList(newTitles, list1);
            return list;
        }

        /// <summary>
        /// This method calculates the average income per month
        /// </summary>
        /// <param name="Title">Input string of an object title</param>
        /// <param name="list2">Input of a subscribers linked list data</param>
        /// <param name="list1">Input of a publications linked list data</param>
        /// <returns></returns>
        public static decimal GetAverage(string Title, LinkedList<Subscribers> list2, LinkedList<Publications> list1)
        {
            decimal ave = 0;
            int n = 0;
            for (list1.Start(); list1.Exist(); list1.Next())
            {
                for (list2.Start(); list2.Exist(); list2.Next())
                {
                    if (list1.TakeData().Title == Title && list1.TakeData().Code == list2.TakeData().PublicationCode)
                    {
                        ave += list1.TakeData().Price * list2.TakeData().PublicationAmount;
                        n++;
                    }
                }
            }
            if (n != 0)
                return ave / n;
            else
                return ave;
        }

        /// <summary>
        /// This method calculates the average income per month
        /// </summary>
        /// <param name="list1">Input of a publications linked list data</param>
        /// <param name="list2">Input of a subscribers linked list data</param>
        /// <returns></returns>
        public static decimal GetAverageIncome(LinkedList<Publications> list1, LinkedList<Subscribers> list2)
        {
            decimal sum = 0;
            int allPublicationss = 0;
            for (list1.Start(); list1.Exist(); list1.Next())
            {
                for (list2.Start(); list2.Exist(); list2.Next())
                {
                    sum += list1.TakeData().Price * list2.TakeData().PublicationAmount;
                    allPublicationss += list2.TakeData().PublicationAmount;
                }
            }
            return sum / allPublicationss;
        }

        /// <summary>
        /// This method calculates the average income sum per month
        /// </summary>
        /// <param name="allPublications">Input list of string which contains linked list data</param>
        /// <param name="list1">Input of a publications linked list data</param>
        /// <param name="list2">Input of a subscribers linked list data</param>
        /// <returns></returns>
        public static LinkedList<decimal> GetIncomeSum(List<string> allPublications, LinkedList<Publications> list1, LinkedList<Subscribers> list2)
        {
            LinkedList<decimal> sum = new LinkedList<decimal>();
            decimal price = 0;
            for (int i = 0; i < allPublications.Count; i++)
            {
                for (list1.Start(); list1.Exist(); list1.Next())
                {
                    for (list2.Start(); list2.Exist(); list2.Next())
                    {
                        if (list1.TakeData().Title == allPublications[i] && list2.TakeData().PublicationCode == list1.TakeData().Code)
                        {
                            price += list1.TakeData().Price * list2.TakeData().PublicationAmount;
                        }
                    }
                }
                sum.Add(price);
                price = 0;
            }
            return sum;
        }

        /// <summary>
        /// Bool method to check whether contains
        /// </summary>
        /// <param name="index">Input int of a certain number</param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool Contains(int index, Subscribers subscriber)
        {

            int n = subscriber.RangeDuration + subscriber.RangeStart;
            if (n < 13 && subscriber.RangeStart < index && subscriber.RangeStart + subscriber.RangeDuration >= index)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Bool method to check whether an item contains characters
        /// </summary>
        /// <param name="str">Input string</param>
        /// <returns></returns>
        public static bool ContainsCharacters(string input)
        {
            foreach (char i in input)
            {
                if (Char.IsDigit(i))
                    return false;
            }
            return true;
        }
    }
}