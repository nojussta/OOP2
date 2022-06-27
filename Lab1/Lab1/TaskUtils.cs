using System.Collections.Generic;
using System.Linq;

namespace Lab1
{
    /// <summary>
    /// This is a class of methods which solve the task
    /// </summary>
    public static class TaskUtils
    {
        /// <summary>
        /// Recursive method of solving the task, pairing dominoes, exchanging positions
        /// </summary>
        /// <param name="Pairs">This is a parameter of pairs</param>
        /// <param name="Visitors">This is a paremeter of pairs which have been used</param>
        /// <param name="Combinations">This is a paremeter of domino combinations</param>
        /// <param name="register">This is a paremeter of register input</param>
        /// <returns></returns>
        private static void DominoSolve(List<int> Pairs, List<int> Visitors, List<int[]> Combinations, Register register)
        {
            int index = 0;
            if (Visitors.Count() == register.DominoCount)
            {
                int[] Dominoes = new int[Pairs.Count()];
                Pairs.CopyTo(Dominoes);
                Combinations.Add(Dominoes);
                return;
            }
            for (int i = 0; i < register.DominoCount; i++)
            {
                if (Visitors.Contains(index))
                {
                    index++;
                    continue;
                }
                int Pairing = register.Get(i).SecondDigit * 10 + register.Get(i).FirstDigit;
                Visitors.Add(index);
                if ((Pairs[Pairs.Count() - 1] % 10) == register.Get(i).FirstDigit)
                {
                    Pairs.Add(register.Get(i).FirstDigit * 10 + register.Get(i).SecondDigit);
                    DominoSolve(Pairs, Visitors, Combinations, register);
                    Pairs.RemoveAt(Pairs.Count() - 1);
                }
                if ((Pairs[Pairs.Count() - 1] % 10) == (Pairing / 10))
                {
                    Pairs.Add(Pairing);
                    DominoSolve(Pairs, Visitors, Combinations, register);
                    Pairs.RemoveAt(Pairs.Count() - 1);
                }
                Visitors.RemoveAt(Visitors.Count() - 1);
                index++;
            }
        }
        /// <summary>
        /// Recursive method which sums up the overall task
        /// </summary>
        /// <param name="register">This is a paremeter of register input</param>
        /// <returns></returns>
        public static List<int[]> DominoesSolve(Register register)
        {
            List<int> Pairs = new List<int>();
            List<int> Used = new List<int>();
            List<int[]> Combinations = new List<int[]>();
            int index = 0;

            for (int i = 0; i < register.DominoCount; i++)
            {
                Used.Add(index);
                Pairs.Add(register.Get(i).FirstDigit * 10 + register.Get(i).SecondDigit);
                DominoSolve(Pairs, Used, Combinations, register);
                Pairs.RemoveAt(Pairs.Count() - 1);
                Pairs.Add(register.Get(i).SecondDigit * 10 + register.Get(i).FirstDigit);
                DominoSolve(Pairs, Used, Combinations, register);
                Pairs.RemoveAt(Pairs.Count() - 1);
                Used.RemoveAt(Used.Count - 1);
                index++;
            }
            return Combinations;
        }
    }
}