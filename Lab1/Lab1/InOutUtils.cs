using System.IO;
using System.Collections.Generic;

namespace Lab1
{
    /// <summary>
    /// This is a class dedicated to input and output methods
    /// </summary>
    public static class InOutUtils
    {
        /// <summary>
        /// This method outputs input data to a .txt file
        /// </summary>
        /// <param name="DominoRegister">This is a paremeter of register input</param>
        /// <param name="fN">This is a paremeter of file name</param>
        public static void PrintDataToFile(Register DominoRegister, string fN)
        {
            string dashes = new string('-', 20);
            string output = "";
            using (StreamWriter wr = File.AppendText(fN))
            {
                wr.WriteLine(dashes);
                wr.WriteLine("{0, 19}", "Pradiniai duomenys");
                wr.WriteLine(dashes);
                for (int i = 0; i < DominoRegister.DominoCount; i++)
                {
                    Domino dominoes = DominoRegister.Get(i);
                    output += string.Format("{0}{1} ", dominoes.FirstDigit, dominoes.SecondDigit);
                }
                wr.WriteLine(output);
                wr.WriteLine(dashes);
                wr.WriteLine();
            }
        }
        /// <summary>
        /// This method outputs results to a .txt file
        /// </summary>
        /// <param name="Dominoes">This is a paremeter of a list of dominoes</param>
        /// <param name="fN">This is a paremeter of a file name</param>
        public static void PrintResultsToFile(List<int[]> Dominoes, string fN)
        {
            string dashes = new string('-', 20);
            string dashes1 = new string('-', 25);
            using (StreamWriter wr = File.AppendText(fN))
            {
                if (Dominoes.Count > 0)
                {
                    wr.WriteLine(dashes);
                    wr.WriteLine("{0, 15}", "Rezultatai");
                    wr.WriteLine(dashes);
                    for (int i = 0; i < Dominoes.Count; i++)
                    {
                        string line = "";
                        for (int j = 0; j < Dominoes[i].Length; j++)
                        {
                            if (Dominoes[i][j] < 10)
                            {
                                line += string.Format("{0}{1} ", 0, Dominoes[i][j]);
                            }
                            else
                            {
                                line += string.Format("{0} ", Dominoes[i][j]);
                            }
                        }
                        wr.WriteLine(line);
                    }
                }
                else
                {
                    wr.WriteLine(dashes1);
                    wr.WriteLine("Nėra tinkančių rezultatų!");
                    wr.WriteLine(dashes1);
                }
            }
        }
    }
}