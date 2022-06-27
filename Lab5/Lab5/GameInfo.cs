namespace Lab5
{
    public class GameInfo
    {
        public string TeamName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int TotalMin { get; set; }
        public int TotalPoints { get; set; }
        public int TotalFauls { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="teamname"></param>
        /// <param name="surname"></param>
        /// <param name="name"></param>
        /// <param name="totalMin"></param>
        /// <param name="totalPoints"></param>
        /// <param name="totalFauls"></param>
        public GameInfo(string teamname, string surname, string name, int totalMin, int totalPoints, int totalFauls)
        {
            TeamName = teamname;
            Name = name;
            Surname = surname;
            TotalMin = totalMin;
            TotalPoints = totalPoints;
            TotalFauls = totalFauls;
        }

        public override string ToString()
        {
            return string.Format("| {0, -15} | {1, -15} | {2, -15} | {3, -12} | {4, -12} | {5, 8} |", TeamName, Name, Surname, TotalMin, TotalPoints, TotalFauls);
        }
    }
}