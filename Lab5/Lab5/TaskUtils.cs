using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab5
{
    /// <summary>
    /// This class is dedicated to fullfilling tasks
    /// </summary>
    public class TaskUtils : System.Web.UI.Page
    {
        /// <summary>
        /// Filter player list by a certain period
        /// </summary>
        /// <param name="r">Register list</param>
        /// <param name="t1">Selected period from</param>
        /// <param name="t2">Selected period to</param>
        /// <returns></returns>
        public static List<GameInfo> FilterByPeriod(List<Register> r, DateTime t1, DateTime t2)
        {

            List<GameInfo> allPlayers = new List<GameInfo>();
            List<GameInfo> chosenPlayers = new List<GameInfo>();
            try
            {
                foreach (Register x in r)
                {
                    if (DateTime.Parse(x.Year) >= t1 && DateTime.Parse(x.Year) <= t2)
                        allPlayers = (from L in x.AllMembers select L).ToList<GameInfo>();
                    chosenPlayers.AddRange(allPlayers);
                }
            }
            catch (Exception)
            {
                return chosenPlayers;
            }
            chosenPlayers = chosenPlayers.Distinct().ToList();
            return chosenPlayers;
        }

        /// <summary>
        /// Sums players from different years for best players list
        /// </summary>
        /// <param name="players">Input list of players</param>
        /// <returns></returns>
        public static List<GameInfo> SumUp(List<GameInfo> players)
        {
            List<GameInfo> newList = new List<GameInfo>();
            int a = 0;
            int n = 0;
            foreach (GameInfo player in players)
            {
                if (HasMore(player, n, players))
                {

                    for (int i = n + 1; i < players.Count; i++)
                    {
                        if (player.Name == players[i].Name && player.Surname == players[i].Surname)
                        {
                            a++;
                            player.TotalFauls += players[i].TotalFauls;
                            player.TotalMin += players[i].TotalMin;
                            player.TotalPoints += players[i].TotalPoints;
                        }
                    }
                }
                n++;
                if (!HasMore(player, newList))
                {
                    newList.Add(player);
                }

            }
            return newList;
        }

        /// <summary>
        /// Checks if a certain list has more of requested values
        /// </summary>
        /// <param name="p">Input of a player object</param>
        /// <param name="n">Input certain amount</param>
        /// <param name="players">Input of players list</param>
        /// <returns></returns>
        public static bool HasMore(GameInfo p, int n, List<GameInfo> players)
        {
            for (int i = n + 1; i < players.Count; i++)
            {
                if (p.Name == players[i].Name && p.Surname == players[i].Surname)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if a certain list has more of requested values
        /// </summary>
        /// <param name="p">Input of a player object</param>
        /// <param name="players">Input of players list</param>
        /// <returns></returns>
        public static bool HasMore(GameInfo p, List<GameInfo> players)
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (p.Name == players[i].Name && p.Surname == players[i].Surname)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Returns a list of all existant players
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public static List<GameInfo> AllPlayers(List<Register> r)
        {

            List<GameInfo> allPlayers = new List<GameInfo>();
            List<GameInfo> chosenPlayers = new List<GameInfo>();

            foreach (Register x in r)
            {
                allPlayers = (from L in x.AllMembers select L).ToList<GameInfo>();
                chosenPlayers.AddRange(allPlayers);
            }
            return chosenPlayers;
        }

        /// <summary>
        /// Filters input list by a certain position
        /// </summary>
        /// <param name="playerData">Input of a player data list</param>
        /// <param name="position">Input of a position string</param>
        /// <param name="register">Input of a register list</param>
        /// <returns></returns>
        public static List<GameInfo> FilterByPositions(List<Player> playerData, string position, List<GameInfo> register)
        {
            List<GameInfo> list = new List<GameInfo>();
            if (position == "centras" || position == "gynėjas" || position == "puolėjas")
            {
                foreach (Player data in playerData)
                {
                    foreach (GameInfo player in register)
                    {
                        if (data.Position == position && data.Name == player.Surname)
                        {
                            list.Add(player);
                        }
                    }
                }
            }
            else
                throw new Exception("Tokios pozicijos nėra!");
            //list.Distinct();
            return list;
        }

        /// <summary>
        /// LINQ sort by certain criterias
        /// </summary>
        /// <param name="register"></param>
        /// <returns></returns>
        public static List<GameInfo> Sort(List<GameInfo> register)
        {
            List<GameInfo> allPlayers = (from L in register orderby L.TeamName, L.Name select L).ToList<GameInfo>();
            return allPlayers;
        }

        /// <summary>
        /// Returns a list of best players
        /// </summary>
        /// <param name="playerPos">Input list of players by positions</param>
        /// <param name="amount">Input of a certain number</param>
        /// <returns></returns>
        public static List<GameInfo> BestPlayers(List<GameInfo> playerPos, int amount)
        {
            List<GameInfo> p = (from L in playerPos orderby L.TotalFauls, L.TotalMin, L.TotalPoints select L).ToList<GameInfo>();
            List<GameInfo> resultList = new List<GameInfo>();
            if (playerPos.Count >= amount)
            {
                for (int i = 0; i < amount; i++)
                {
                    resultList.Add(playerPos[i]);
                }
            }
            else
                return resultList;
            return resultList;
        }
    }
}