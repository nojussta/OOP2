using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace Lab1
{
    /// <summary>
    /// This is a class of methods which are related to website inputs/outputs
    /// </summary>
    public partial class Form1
    {
        /// <summary>
        /// This method inputs data from a file
        /// </summary>
        /// <returns>This method returns a register object</returns>
        public Register InputData()
        {
            string CFd1 = Server.MapPath("App_Data/Kur3.txt");
            string[] Lines = File.ReadAllLines(CFd1);
            List<Domino> ListOfDomino = new List<Domino>();
            for (int i = 0; i < Lines.Count(); i++)
            {
                string[] Values = Lines[i].Split(' ');
                for (int j = 0; j < Values.Count(); j++)
                {
                    if (Regex.IsMatch(Values[j], @"\D"))
                    {
                        Label3.Text += "Duomenys nurodyti neteisingu formatu!";
                        Register emptyReg = new Register(ListOfDomino, 0);
                        return emptyReg;
                    }
                    else
                    {
                        int firstDigit = int.Parse(Values[j]) / 10;
                        int secondDigit = int.Parse(Values[j]) % 10;
                        Domino parts = new Domino(firstDigit, secondDigit);
                        Console.WriteLine(firstDigit);
                        ListOfDomino.Add(parts);
                    }
                }
            }
            Register dominoes = new Register(ListOfDomino, 7);
            return dominoes;
        }
        /// <summary>
        /// This method outputs results to the website
        /// </summary>
        /// <param name="Dominoes">This is a paremeter of a list of dominoes</param>
        private void PrintResultsToWebsite(List<int[]> Dominoes)
        {
            for (int i = 0; i < Dominoes.Count; i++)
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                for (int j = 0; j < Dominoes[i].Length; j++)
                {
                    if (Dominoes[i][j] < 10)
                    {
                        cell.Text += string.Format("{0}{1} ", 0, Dominoes[i][j]);
                    }
                    else
                    {
                        cell.Text += Dominoes[i][j] + " ";
                    }
                }
                row.Cells.Add(cell);
                Table2.Rows.Add(row);
            }
        }
    }
}