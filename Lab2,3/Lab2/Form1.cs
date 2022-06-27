using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Lab2
{
    /// <summary>
    /// This is a class dedicated to placing data to the website
    /// </summary>
    public partial class Form1
    {
        /// <summary>
        /// This is a print to the website method dedicated to the first task
        /// </summary>
        /// <param name="list">Input of a list of strings which contains linked list items</param>
        public void FirstTask(List<string> list)
        {
            string dashes = new string('-', 44);
            TextBox6.Text += "\n";
            TextBox6.Text += "\n";
            TextBox6.Text += string.Format("{0}", "Leidinių egzistencija per mėnesius") + "\n";
            TextBox6.Text += string.Format(dashes) + "\n";
            TextBox6.Text += string.Format("{0, -20} | {1, -20}|", "Mėnuo", "Leidinio pavadinimas") + "\n";
            for (int i = 0; i < 12; i++)
            {
                TextBox6.Text += string.Format(dashes) + "\n";
                TextBox6.Text += string.Format("{0, -20} | {1, -20}|", CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i + 1), list[i]) + "\n";
            }
        }

        /// <summary>
        /// This is a print to the website method dedicated to the second task
        /// </summary>
        /// <param name="sum">Input of a linked decimal list </param>
        /// <param name="list">Input of an object linked list</param>
        public void SecondTask(LinkedList<decimal> sum, LinkedList<Publications> list)
        {
            string dashes = new string('-', 44);
            list.Sort();
            List<string> listt = TaskUtils.GetList(list);
            TextBox6.Text += "\n";
            TextBox6.Text += "\n";
            TextBox6.Text += string.Format("{0}", "Leidinių uždarbiai") + "\n";
            TextBox6.Text += string.Format(dashes) + "\n";
            TextBox6.Text += string.Format("{0, -20} | {1, -20}|", "Pavadinimas", "Vidurkis") + "\n";
            for (int i = 0; i < sum.Count(); i++)
            {
                int n = 0;
                for (sum.Start(); sum.Exist(); sum.Next())
                {
                    if (n == i)
                    {
                        TextBox6.Text += string.Format(dashes) + "\n";
                        TextBox6.Text += string.Format("{0, -20} | {1, -20}|", listt[i], sum.TakeData()) + "\n";
                    }
                    n++;
                }
            }
        }

        /// <summary>
        /// This is a print to the website method dedicated to the third task
        /// </summary>
        /// <param name="list">Input of a linked list</param>
        public void ThirdTask(LinkedList<string> list, string fileName)
        {
            if (list.Count() > 0)
            {
                TextBox6.Text += "\n";
                TextBox6.Text += string.Format("Duomenys tenkinantys kriterijus") + "\n";
                TextBox6.Text += string.Format(new string('-', 69)) + "\n";
                TextBox6.Text += string.Format("| {0, 25} | {1, -20} | {2, 15}|", "Kodas", "Pavadinimas", "Pajamos") + "\n";
                TextBox6.Text += string.Format(new string('-', 69)) + "\n";
                for (list.Start(); list.Exist(); list.Next())
                {
                    TextBox6.Text += list.TakeData();
                }
            }
            else
            {
                TextBox6.Text += string.Format("Sąlygą tenkinančių duomenų nėra!");
                using (StreamWriter writer = File.AppendText(fileName))
                {
                    writer.WriteLine();
                    writer.WriteLine(string.Format("{0,35}     ", "Sąlygą tenkinančių duomenų nėra!"));
                }
            }
        }

        /// <summary>
        /// This is a print to a .txt file method dedicated to the first task
        /// </summary>
        /// <param name="list1"></param>
        public void PrintFirst(LinkedList<Publications> list1)
        {
            string dashes = new string('-', 43);
            TextBox7.Text += "Informacija apie leidinius" + "\n";
            TextBox7.Text += dashes + "\n";
            TextBox7.Text += string.Format("| {0, 8} | {1, -15} | {2, 10} |", "Kodas", "Pavadinimas", "Kaina") + "\n";
            TextBox7.Text += dashes + "\n";
            for (list1.Start(); list1.Exist(); list1.Next())
            {
                string n;
                n = string.Format("| {0, 8} | {1, -15} | {2, 10} |", 
                    list1.TakeData().Code, list1.TakeData().Title, list1.TakeData().Price) + "\n";
                TextBox7.Text += n;
            }
            TextBox7.Text += dashes + "\n";
            TextBox7.Text += "\n";
        }

        /// <summary>
        /// This is a print to a .txt file method dedicated to the second task
        /// </summary>
        /// <param name="list1"></param>
        public void PrintSecond(LinkedList<Subscribers> list1)
        {
            string dashes = new string('-', 75);
            TextBox7.Text += "Informacija apie prenumeratorius" + "\n";
            TextBox7.Text += dashes + "\n";
            TextBox7.Text += string.Format("| {0, 10} | {1, -25} | {2, -30} |", "Kodas", "Vardas", "Adresas") + "\n";
            TextBox7.Text += dashes + "\n";
            for (list1.Start(); list1.Exist(); list1.Next())
            {
                string n;
                n = string.Format("| {0, 10} | {1, -25} | {2, -30} | {3}", 
                    list1.TakeData().PublicationCode, list1.TakeData().Surname, list1.TakeData().Adress, "\n");
                TextBox7.Text += n;
            }
            TextBox7.Text += dashes + "\n";
        }

        /// <summary>
        /// This is a print to the website method
        /// </summary>
        /// <param name="list">Input of an object linked list</param>
        /// <param name="fileName">Input string of a file name</param>
        public void PrintResults(LinkedList<Subscribers> list, string fileName)
        {
            if (list.Count() > 0)
            {
                TextBox6.Text += string.Format("{0}", "Sąlygą tenkinantys duomenys atrinkti!") + "\n";
                TextBox6.Text += string.Format(new string('-', 55)) + "\n";
                TextBox6.Text += string.Format("| {0, 5} | {1, -20} | {2, -20} |", "Kodas", "Pavardė", "Adresas") + "\n";
                for (list.Start(); list.Exist(); list.Next())
                {
                    TextBox6.Text += string.Format(new string('-', 55)) + "\n";
                    TextBox6.Text += string.Format("| {0, 5} | {1, -20} | {2, -20} |",
                        list.TakeData().PublicationCode, list.TakeData().Surname, list.TakeData().Adress) + "\n";
                }
            }
            else
            {
                TextBox6.Text += string.Format("Sąlygą tenkinančių duomenų nėra!");
                using (StreamWriter writer = File.AppendText(fileName))
                {
                    writer.WriteLine();
                    writer.WriteLine(string.Format("{0,35}     ", "Sąlygą tenkinančių duomenų nėra!"));
                }
            }
        }
    }
}