using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Lab2
{
    /// <summary>
    /// This is a class to store input and output data
    /// </summary>
    public static class InOutUtils
    {
        /// <summary>
        /// This is a print method dedicated to print a certain task with a type parameter 
        /// </summary>
        /// <typeparam name="type">This is a type parameter</typeparam>
        /// <param name="fileName">Input string of a file name</param>
        /// <param name="types">This is a type parameter</param>
        /// <param name="header">Input string of a header</param>
        /// <param name="length">Input int of a certain symbol length</param>
        public static void Print<type>(string fileName, IEnumerable<type> types, string header, int length) where type : IComparable<type>, IEquatable<type>
        {
            using (StreamWriter writer = File.AppendText(fileName))
            {
                string dashes = new string('-', length);
                writer.WriteLine(header);
                writer.WriteLine(dashes);
                foreach (type one in types)
                {
                    writer.WriteLine(one);
                }
                writer.WriteLine(dashes);
                writer.WriteLine();
            }
        }

        /// <summary>
        /// This is a method dedicated to read input1 data
        /// </summary>
        /// <param name="list">This is an object storing linked list</param>
        /// <param name="fileName">Input string of a file name</param>
        public static void ReadLifo1(LinkedList<Publications> list, string fileName)
        {
            string[] lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in lines)
            {
                string[] Values = line.Split(';');
                string code = Values[0];
                string name = Values[1];
                decimal price = decimal.Parse(Values[2]);
                Publications publication = new Publications(code, name, price);
                list.Add(publication);
            }
        }

        /// <summary>
        /// This is a method dedicated to read input2 data
        /// </summary>
        /// <param name="list">This is an object storing linked list</param>
        /// <param name="fileName">Input string of a file name<</param>
        public static void ReadLifo2(LinkedList<Subscribers> list, string fileName)
        {
            string[] lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in lines)
            {
                string[] Values = line.Split(';');
                string Surname = Values[0];
                string Adress = Values[1];
                int StartingPoint = int.Parse(Values[2]);
                int PeriodRange = int.Parse(Values[3]);
                string Code = Values[4];
                int PublicationCount = int.Parse(Values[5]);
                Subscribers publication = new Subscribers(Surname, Adress, StartingPoint, PeriodRange, Code, PublicationCount);
                list.Add(publication);
            }
        }

        /// <summary>
        /// This is a method which prints out monthly income
        /// </summary>
        /// <param name="title">Input list of strings of publication titles</param>
        /// <param name="filename">Input string of a header</param>
        public static void PrintMonthlyIncome(List<string> title, string filename)
        {
            using (StreamWriter writer = File.AppendText(filename))
            {
                string dashes = new string('-', 42);
                writer.WriteLine(string.Format(dashes));
                writer.WriteLine(string.Format("| {0, -38} | ", "Leidinių egzistencija per mėnesius"));
                writer.WriteLine(string.Format(dashes));
                writer.WriteLine(string.Format("| {0, -15} | {1, 20} |", "Mėnuo", "Leidinio kodas"));
                writer.WriteLine(string.Format(dashes));
                for (int i = 0; i < 12; i++)
                {
                    writer.WriteLine(string.Format("| {0, -15} | {1, 20} |", CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i + 1), title[i]));
                }
                writer.WriteLine();
            }
        }

        /// <summary>
        /// This is a method which prints out summed monthly income
        /// </summary>
        /// <param name="incomeSum">This is an input linked list of incomes</param>
        /// <param name="list">This is an input linked list of an object</param>
        /// <param name="fileName">Input string of a file name</param>
        public static void PrintSummedIncome(LinkedList<decimal> incomeSum, LinkedList<Publications> list, string fileName)
        {
            List<string> names = TaskUtils.GetList(list);
            list.Sort();
            using (StreamWriter writer = File.AppendText(fileName))
            {
                string dashes = new string('-', 50);
                writer.WriteLine(string.Format(dashes));
                writer.WriteLine(string.Format("| {0, -46} | ", "Leidinių uždarbiai"));
                writer.WriteLine(string.Format(dashes));
                writer.WriteLine(string.Format("| {0, -35} | {1, 8} |", "Leidinio pavadinimas", "Uždarbis"));
                writer.WriteLine(string.Format(dashes));
                for (int i = 0; i < names.Count; i++)
                {
                    int n = 0;
                    for (incomeSum.Start(); incomeSum.Exist(); incomeSum.Next())
                    {
                        if (n == i)
                            writer.WriteLine(string.Format("| {0, -35} | {1, 8} |", names[i], incomeSum.TakeData()));
                        n++;
                    }
                }
                writer.WriteLine();
            }
        }

        /// <summary>
        /// This methods prints out certain chosen items from a linked list
        /// </summary>
        /// <param name="titles">Inputing a list of strings of titles</param>
        /// <param name="list">This is an input linked list of an object</param>
        /// <param name="fileName">Input string of a file name</param>
        public static void PrintChosenList(List<string> titles, LinkedList<Publications> list, string fileName)
        {
            using (StreamWriter writer = File.AppendText(fileName))
            {
                if (list.Count() > 0)
                {
                    string dashes = new string('-', 69);
                    writer.WriteLine(string.Format(dashes));
                    writer.WriteLine(string.Format("{0, -45}", "Duomenys tenkinantys kriterijus"));
                    writer.WriteLine(string.Format(dashes));
                    writer.WriteLine(string.Format("| {0, 25} | {1, -20} | {2, 15}|", "Leidinio kodas", "Leidinio pavadinimas", "Kaina"));
                    writer.WriteLine(string.Format(dashes));
                    for (int i = 0; i < titles.Count; i++)
                    {
                        for (list.Start(); list.Exist(); list.Next())
                        {
                            if (list.TakeData().Title == titles[i])
                            {
                                writer.WriteLine(string.Format("| {0, 25} | {1, -20} | {2, 15}|", list.TakeData().Code, list.TakeData().Title, list.TakeData().Price));
                            }
                        }
                    }
                    writer.WriteLine();
                }
                else
                {
                    writer.WriteLine();
                    writer.WriteLine(string.Format("{0,35}     ", "Sąlygą tenkinančių duomenų nėra!"));
                }
            }
        }

        /// <summary>
        /// This methods prints out certain chosen items from a linked list
        /// </summary>
        /// <param name="titles">Inputing a list of strings of titles</param>
        /// <param name="list">This is an input linked list of an object</param>
        /// <returns></returns>
        public static LinkedList<string> PrintChosenList(List<string> titles, LinkedList<Publications> list)
        {
            LinkedList<string> newStringList = new LinkedList<string>();
            for (int i = 0; i < titles.Count; i++)
            {
                for (list.Start(); list.Exist(); list.Next())
                {
                    if (list.TakeData().Title == titles[i])
                    {
                        string tempLine = "";
                        tempLine += string.Format("| {0, -25} | {1, 20} | {2, 15}|", list.TakeData().Code, list.TakeData().Title, list.TakeData().Price) + "\n";
                        newStringList.Add(tempLine);
                    }
                }
            }
            return newStringList;
        }
    }
}