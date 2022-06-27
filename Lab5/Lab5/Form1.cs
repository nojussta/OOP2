using System;
using System.Collections.Generic;

namespace Lab5
{
    /// <summary>
    /// This class is dedicated to placing data to web
    /// </summary>
    public partial class Form1
    {
        List<Register> allMembers;

        /// <summary>
        /// Places input data to web
        /// </summary>
        protected void PrintInputData()
        {
            allMembers = (List<Register>)Session["Members"];
            string dashes = new string('-', 96) + '\n';
            if (allMembers.Count != 0)
            {
                TextBox3.Text += "Duomenys apie įvykusias rungtynes bei jose dalyvavusius krepšininkus:" + '\n';
                TextBox3.Text += dashes;
                TextBox3.Text += string.Format("| {0, -15} | {1, -15} | {2, -15} | {3, -12} | {4, -12} | {5, 8} |", "Komanda", "Vardas", "Pavardė", "Laikas", "Taškai", "Baudos") + '\n';
                TextBox3.Text += dashes;
                foreach (var reg in allMembers)
                {
                    TextBox3.Text += String.Format($"Rungtynės vyko: {reg.Year}") + '\n';
                    TextBox3.Text += dashes;
                    for (int i = 0; i < allMembers.Count; i++)
                    {
                        TextBox3.Text += String.Format("| {0, -15} | {1, -15} | {2, -15} | {3, -12} | {4, -12} | {5, 8} |", reg.AllMembers[i].TeamName, reg.AllMembers[i].Surname,
                            reg.AllMembers[i].Name, reg.AllMembers[i].TotalFauls, reg.AllMembers[i].TotalMin, reg.AllMembers[i].TotalPoints) + '\n';
                    }
                    TextBox3.Text += dashes;
                    TextBox3.Text += '\n';
                }
            }
            else
                TextBox3.Text += "Sąrašo sudaryti nepavyko!";
        }

        /// <summary>
        /// Places player info to web
        /// </summary>
        /// <param name="list">Input list of player data</param>
        protected void PrintPlayersInfo(List<Player> list)
        {
            string dashes = new string('-', 73) + '\n';
            if (list.Count != 0)
            {
                TextBox3.Text += "Informacija apie žaidėjus:" + '\n';
                TextBox3.Text += dashes;
                TextBox3.Text += String.Format("| {0, -15} | {1, -15} | {2, -15} | {3, -15} |", "Komanda", "Pavardė", "Vardas", "Pozicija") + '\n';
                TextBox3.Text += dashes;
                foreach (var player in list)
                {
                    TextBox3.Text += player.ToString() + '\n';
                }
                TextBox3.Text += dashes + '\n';
            }
            else
                TextBox3.Text += "Informacijos apie žaidėjus nėra!";
        }

        /// <summary>
        /// Places chosen players by criteria to web
        /// </summary>
        /// <param name="p">Input of players list</param>
        protected void PrintByCriteria(List<GameInfo> p)
        {
            if (p.Count != 0)
            {
                string dashes = new string('-', 96) + '\n';
                if (true)
                {
                    TextBox3.Text += "Rezultatai atitinkantys pasirinktus kriterijus:" + '\n';
                    TextBox3.Text += dashes;
                    TextBox3.Text += string.Format("| {0, -15} | {1, -15} | {2, -15} | {3, -12} | {4, -12} | {5, 8} |", "Komanda", "Vardas", "Pavardė", "Laikas", "Taškai", "Baudos") + '\n';
                    TextBox3.Text += dashes;
                    foreach (var player in p)
                    {
                        TextBox3.Text += player.ToString() + '\n';
                    }
                    TextBox3.Text += dashes + '\n';
                    TextBox3.Text += '\n';
                }
            }
            else
                TextBox3.Text += "Sąrašo sudaryti nepavyko!";
        }

        /// <summary>
        /// Places best players to web
        /// </summary>
        /// <param name="list">Input of players list</param>
        protected void PrintBestPlayers(List<GameInfo> list)
        {

            if (list.Count != 0)
            {
                string dashes = new string('-', 96) + '\n';
                if (true)
                {
                    TextBox3.Text += "Naudingiausi žaidėjai:" + '\n';
                    TextBox3.Text += dashes;
                    TextBox3.Text += string.Format("| {0, -15} | {1, -15} | {2, -15} | {3, -12} | {4, -12} | {5, 8} |", "Komanda", "Vardas", "Pavardė", "Laikas", "Taškai", "Baudos") + '\n';
                    TextBox3.Text += dashes;
                    foreach (var player in list)
                    {
                        TextBox3.Text += player.ToString() + '\n';
                    }
                    TextBox3.Text += dashes + '\n';
                    TextBox3.Text += '\n';
                }
            }
            else
                TextBox3.Text += "Sąrašo sudaryti nepavyko, tiek naudingiausių žaidėjų nėra!";
        }

        /// <summary>
        /// Places exception text to web
        /// </summary>
        /// <param name="text"></param>
        public void PrintException(string text)
        {
            Label4.Text += text + '\n';
        }
    }
}