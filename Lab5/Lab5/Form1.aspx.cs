using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab5
{
    /// <summary>
    /// This class is dedicated to web functioning
    /// </summary>
    public partial class Form1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// First button function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            string[] fileNames = Directory.GetFiles(Server.MapPath(@"App_Data/"), "*.txt", SearchOption.TopDirectoryOnly);
            string playersInfo = Server.MapPath(@"App_Data/Rezultatai/playersInfo.txt");
            string resultFile = Server.MapPath(@"App_Data/Rezultatai/Rezultatai.txt");
            bool flag = true;

            File.Delete(resultFile);

            List<Register> allMatches = new List<Register>();

            List<Player> players;

            string position;
            DateTime start = DateTime.Now;
            DateTime end = DateTime.Now;
            int amount;


            position = TextBox4.Text;
            if (position.Length == 0)
                PrintException("Nepasirinkta pozicija!");

            try
            {
                start = DateTime.Parse(TextBox5.Text);
                end = DateTime.Parse(TextBox7.Text);
            }
            catch (Exception)
            {
                PrintException("Neteisingai įvesta data!");
            }
            try
            {
                amount = int.Parse(TextBox6.Text);
            }
            catch (Exception)
            {
                PrintException("Sąrašo dydis nurodytas neteisingai!");
            }

            foreach (string fileName in fileNames)
            {
                bool check = false;
                if (fileName.Length != 0)
                {
                    allMatches.Add(InOutUtils.ReadData(fileName, ref check));
                    if (!check)
                        InOutUtils.PrintInputDataToFile(resultFile, allMatches.Last());
                    else
                        PrintException($"Klaida duomenų faile {fileName}");
                }
            }
            players = InOutUtils.InputPlayers(playersInfo);
            Session["Flag"] = flag;
            Session["Members"] = allMatches;
            Session["resultFile"] = resultFile;
            PrintInputData();
            PrintPlayersInfo(players);
            InOutUtils.PrintPlayersInfoToFile(players, resultFile);

            List<GameInfo> AllPlayers = TaskUtils.AllPlayers(allMatches);
            List<GameInfo> Summed = TaskUtils.SumUp(AllPlayers);
            List<GameInfo> Time = TaskUtils.FilterByPeriod(allMatches, start, end);
            List<GameInfo> Criteria = TaskUtils.Sort(Time);

            PrintByCriteria(Criteria);
            InOutUtils.PrintByCriteriaToFile(Summed, resultFile);
        }

        /// <summary>
        /// Second button function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            string[] fileNames = Directory.GetFiles(Server.MapPath(@"App_Data/"), "*.txt", SearchOption.TopDirectoryOnly);
            string playersInfo = Server.MapPath(@"App_Data/Rezultatai/playersInfo.txt");
            string resultFile = Server.MapPath(@"App_Data/Rezultatai/Rezultatai.txt");
            bool flag = true;

            File.Delete(resultFile);

            List<Register> allMatches = new List<Register>();

            List<Player> players;

            int amount = 0;

            try
            {
                amount = int.Parse(TextBox6.Text);
            }
            catch (Exception)
            {
                PrintException("Sąrašo dydis nurodytas neteisingai!");
            }

            foreach (string fileName in fileNames)
            {
                bool check = false;
                allMatches.Add(InOutUtils.ReadData(fileName, ref check));
                InOutUtils.PrintInputDataToFile(resultFile, allMatches.Last());
            }
            players = InOutUtils.InputPlayers(playersInfo);
            Session["Flag"] = flag;
            Session["Members"] = allMatches;
            Session["Players"] = players;
            Session["resultFile"] = resultFile;

            List<GameInfo> AllPlayers = TaskUtils.AllPlayers(allMatches);
            List<GameInfo> Summed = TaskUtils.SumUp(AllPlayers);
            List<GameInfo> BestPlayers = TaskUtils.BestPlayers(Summed, amount);
            List<GameInfo> Sorted = TaskUtils.Sort(BestPlayers);

            PrintBestPlayers(Sorted);
            InOutUtils.PrintByCriteriaToFile(Summed, resultFile);
            InOutUtils.PrintBestPlayersToFile(Sorted, resultFile);
        }

        /// <summary>
        /// Third button function/Clears data from web
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button3_Click(object sender, EventArgs e)
        {
            string resultFile = Server.MapPath(@"App_Data/Rezultatai/Rezultatai.txt");
            Session.RemoveAll();
            Response.Redirect(Request.RawUrl);
            File.Delete(resultFile);
        }
    }
}