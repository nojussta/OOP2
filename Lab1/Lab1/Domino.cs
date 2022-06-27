namespace Lab1
{
    /// <summary>
    /// Class of a Domino object
    /// </summary>
    public class Domino
    {
        public int FirstDigit { get; set; }
        public int SecondDigit { get; set; }
        /// <summary>
        /// Domino constructor
        /// </summary>
        /// <param name="firstDigit">This is a paremeter of a first digit</param>
        /// <param name="secondDigit">This is a paremeter of a second digit</param>
        public Domino(int firstDigit, int secondDigit)
        {
            this.FirstDigit = firstDigit;
            this.SecondDigit = secondDigit;
        }
    }
}