using System;
using System.IO;
using System.Collections.Generic;

namespace Lab5
{
    /// <summary>
    /// This class is dedicated to input/output data
    /// </summary>
    public static class InOutUtils
    {
        /// <summary>
        /// Reads input data from file
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <param name="erorr">Bool check</param>
        /// <returns></returns>
        public static Register ReadData(string fileName, ref bool erorr)
        {
            List<GameInfo> MemberRegister = new List<GameInfo>();
            string year;

            using (StreamReader reader = new StreamReader(fileName))
            {
                try
                {
                    year = reader.ReadLine();

                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        GameInfo currMem = InputGameData(line);
                        if (currMem != null && !MemberRegister.Contains(currMem))
                        {
                            MemberRegister.Add(currMem);
                        }
                    }
                }
                catch (Exception)
                {
                    erorr = true;
                    return new Register();
                }
                return new Register(year, MemberRegister);
            }
        }


        /// <summary>
        /// Inputs players from file
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <returns></returns>
        public static List<Player> InputPlayers(string fileName)
        {
            List<Player> p = new List<Player>();

            string[] lines = File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                string[] Values = line.Split(';');
                string team = Values[0];
                string surname = Values[1];
                string name = Values[2];
                string position = Values[3];

                Player publication = new Player(team, surname, name, position);
                p.Add(publication);
            }
            return p;
        }

        /// <summary>
        /// Inputs game data from file
        /// </summary>
        /// <param name="line">Input line for splitting</param>
        /// <returns></returns>
        private static GameInfo InputGameData(string line)
        {
            string[] Values = line.Split(';');
            string teamName = Values[0];
            string surname = Values[1];
            string name = Values[2];
            int TotalMin = int.Parse(Values[3]);
            int TotalPoints = int.Parse(Values[4]);
            int TotalFauls = int.Parse(Values[5]);

            return new GameInfo(teamName, name, surname, TotalMin, TotalPoints, TotalFauls);
        }

        /// <summary>
        /// Prints input data to file
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <param name="register">Input of a register</param>
        public static void PrintInputDataToFile(string fileName, Register register)
        {
            using (StreamWriter writer = File.AppendText(fileName))
            {
                if (register.AllMembers.Count != 0)
                {
                    string dashes = new string('-', 96);
                    writer.WriteLine("Duomenys apie įvykusias rungtynes bei jose dalyvavusius krepšininkus:");
                    writer.WriteLine(dashes);
                    writer.WriteLine(register.Year);
                    writer.WriteLine(dashes);
                    writer.WriteLine(string.Format("| {0, -15} | {1, -15} | {2, -15} | {3, -12} | {4, -12} | {5, 8} |", "Komanda", "Pavardė", "Vardas", "Laikas", "Taškai", "Klaidos"));
                    writer.WriteLine(dashes);
                    foreach (GameInfo player in register.AllMembers)
                    {
                        writer.WriteLine(player.ToString());
                    }
                    writer.WriteLine(dashes);
                    writer.WriteLine();
                }
                else
                    writer.WriteLine("Sąrašo sudaryti nepavyko!");
            }
        }

        /// <summary>
        /// Prints player info to file
        /// </summary>
        /// <param name="list">Input of a player list</param>
        /// <param name="fileName">File name</param>
        public static void PrintPlayersInfoToFile(List<Player> list, string fileName)
        {
            string dashes = new string('-', 73);
            using (StreamWriter writer = File.AppendText(fileName))
            {
                if (list.Count != 0)
                {
                    writer.WriteLine();
                    writer.WriteLine("Informacija apie žaidėjus");
                    writer.WriteLine(dashes);
                    writer.WriteLine(string.Format("| {0, -15} | {1, -15} | {2, -15} | {3, -15} |", "Komanda", "Pavardė", "Vardas", "Pozicija"));
                    writer.WriteLine(dashes);
                    foreach (Player playerData in list)
                    {
                        writer.WriteLine(playerData.ToString());
                    }
                    writer.WriteLine(dashes);
                    writer.WriteLine();
                }
                else
                    writer.WriteLine("Sąrašo sudaryti nepavyko!");
            }
        }

        /// <summary>
        /// Prints player list filtered by criteria to file
        /// </summary>
        /// <param name="p">Input of a player list</param>
        /// <param name="fileName">File name</param>
        public static void PrintByCriteriaToFile(List<GameInfo> p, string fileName)
        {
            using (StreamWriter writer = File.AppendText(fileName))
            {
                if (p.Count != 0)
                {
                    string dashes = new string('-', 96);
                    writer.WriteLine();
                    writer.WriteLine("Rezultatai atitinkantys pasirinktus kriterijus:");
                    writer.WriteLine(dashes);
                    writer.WriteLine(string.Format("| {0, -15} | {1, -15} | {2, -15} | {3, -12} | {4, -12} | {5, -8} |", "Komanda", "Pavardė", "Vardas", "Laikas", "Taškai", "Klaidos"));
                    writer.WriteLine(dashes);
                    foreach (GameInfo player in p)
                    {
                        writer.WriteLine(player.ToString());
                    }
                    writer.WriteLine(dashes);
                    writer.WriteLine();
                }
                else
                {
                    writer.WriteLine("Sąrašo sudaryti nepavyko!");
                }
            }
        }

        /// <summary>
        /// Prints best players to file
        /// </summary>
        /// <param name="list">Input of a player list</param>
        /// <param name="fileName">File name</param>
        public static void PrintBestPlayersToFile(List<GameInfo> list, string fileName)
        {
            using (StreamWriter writer = File.AppendText(fileName))
            {
                if (list.Count != 0)
                {
                    string dashes = new string('-', 96);
                    if (list.Count != 0)
                    {
                        writer.WriteLine("Naudingiausi žaidėjai:");
                        writer.WriteLine(dashes);
                        writer.WriteLine(string.Format("| {0, -15} | {1, -15} | {2, -15} | {3, -12} | {4, -12} | {5, 8} |", "Komanda", "Vardas", "Pavardė", "Laikas", "Taškai", "Baudos"));
                        writer.WriteLine(dashes);
                        foreach (var player in list)
                        {
                            writer.WriteLine(player.ToString());
                        }
                        writer.WriteLine(dashes);
                    }
                }
                else
                    writer.WriteLine("Sąrašo sudaryti nepavyko!");
            }
        }
    }
}