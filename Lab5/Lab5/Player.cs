namespace Lab5
{
    /// <summary>
    /// class for holfing info about players positions
    /// </summary>
    public class Player
    {
        public string TeamName { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="teamName"></param>
        /// <param name="surname"></param>
        /// <param name="name"></param>
        /// <param name="position"></param>
        public Player(string teamName, string surname, string name, string position)
        {
            TeamName = teamName;
            Surname = surname;
            Name = name;
            Position = position;
        }
        public override string ToString()
        {
            return string.Format("| {0, -15} | {1, -15} | {2, -15} | {3, -15} |", TeamName, Surname, Name, Position);
        }
    }
}