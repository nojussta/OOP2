using System.Collections.Generic;

namespace Lab1
{
    /// <summary>
    /// Register of Domino objects
    /// </summary>
    public class Register
    {
        /// <summary>
        /// Private list of all Domino objects
        /// </summary>
        private readonly List<Domino> AllDomino = new List<Domino>();

        public int DominoCount { get; set; }
        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="AllDomino">This is a paremeter of a list of dominoes</param>
        /// <param name="dominoCount">This is a paremeter of domino count</param>
        public Register(List<Domino> AllDomino, int dominoCount)
        {
            this.DominoCount = dominoCount;
            foreach (var domino in AllDomino)
            {
                this.AllDomino.Add(domino);
            }
        }
        public Domino Get(int index)
        {
            return AllDomino[index];
        }
        public int Count()
        {
            return AllDomino.Count;
        }
    }
}