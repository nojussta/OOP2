using System;
using System.Collections.Generic;

namespace Lab4
{
    /// <summary>
    /// This class is dedicated to put data to the web
    /// </summary>
    public partial class Form1
    {
        List<Register> allMembers;

        /// <summary>
        /// Puts input data to the web
        /// </summary>
        protected void StartingData()
        {
            string dashes = new string('-', 69) + '\n';
            allMembers = (List<Register>)Session["Members"];
            string header = string.Format("| {0, -15} | {1, -15} | {2} | {3, -15} |", "Pavarde", "Vardas", "Gimimo data", "Telefono Nr.");
            foreach (Register register in allMembers)
            {
                ResultBox.Text += register.StudyYear;
                ResultBox.Text += '\n';
                ResultBox.Text += dashes;
                ResultBox.Text += header + '\n';
                ResultBox.Text += dashes;
                for (int i = 0; i < register.AllMembers.Count; i++)
                {
                    ResultBox.Text += register.AllMembers[i].ToString() + '\n';
                }
                ResultBox.Text += dashes;
            }

        }

        /// <summary>
        /// Filters first task data
        /// </summary>
        /// <param name="flag">Boolean for checking</param>
        protected void FilterByExperience(out bool flag)
        {
            flag = true;
            allMembers = (List<Register>)Session["Members"];

            DateTime date = DateTime.Now;

            TaskUtils reference = new TaskUtils();

            List<Register> firstTask = new List<Register>();


            if (allMembers != null)
            {
                foreach (Register register in allMembers)
                {
                    if (reference.GetCurrentYearList(register, date) != null)
                        firstTask.Add(reference.GetCurrentYearList(register, date));
                }

                string path = (string)Session["FirstPath"];

                InOutUtils.FilterByExperienceToFile(firstTask, path);
                ExperienceToWeb(firstTask);
            }
            else
            {
                FirstTaskError();
                flag = false;
            }
        }

        /// <summary>
        /// Exception
        /// </summary>
        public void FirstTaskError()
        {
            TextBox3.Text += "Objekto masyvas yra tuščias, nurodyti duomenys neteisingi.";
        }

        /// <summary>
        /// Filters second task data
        /// </summary>
        protected void FilterByBirthdays()
        {
            allMembers = (List<Register>)Session["Members"];
            string filePath = (string)Session["ResultFile"];

            List<string> allLines = new List<string>();

            foreach (Register reg in allMembers)
            {
                string s = TaskUtils.GetBirthdays(reg);
                allLines.Add(s);
            }
            FilterByBirthdaysToWeb(allLines);
            InOutUtils.FilterByBirthdaysToFile(filePath, allLines);
        }

        /// <summary>
        /// Filters third task data
        /// </summary>
        protected void FilterSeniorsAndOldMembers()
        {
            allMembers = (List<Register>)Session["Members"];
            List<Member> reg = new List<Member>();
            string filePath = (string)Session["Senjorai"];

            foreach (Register register in allMembers)
            {
                for (int i = 0; i < register.AllMembers.Count; i++)
                {
                    if (register.AllMembers[i].OldStudent(register.AllMembers[i]))
                        reg.Add(register.AllMembers[i]);
                }
            }
            reg = TaskUtils.Sort(reg);
            reg = TaskUtils.Sort(reg);
            reg = TaskUtils.Sort(reg);
            InOutUtils.FilterSeniorsAndOldMembersToFile(reg, filePath);
            FilterSeniorsAndOldMembersToWeb(reg);
        }

        /// <summary>
        /// Filters whether there are old students who graduated
        /// </summary>
        /// <param name="list">Input of a register list</param>
        /// <param name="year">Input of a year</param>
        /// <param name="member">Input of a member object</param>
        /// <returns></returns>
        protected bool ExperienceCheck(List<Register> list, int year, Member member)
        {
            for (int i = year; i < list.Count; i++)
            {
                for (int j = 0; j < list[i].AllMembers.Count; j++)
                {
                    if (list[i].AllMembers[j].Equals(member) && list[i].AllMembers[j] is Graduate)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Filters fourth task data
        /// </summary>
        protected void FilterGraduators()
        {
            allMembers = (List<Register>)Session["Members"];
            List<Member> newReg = new List<Member>();
            string fileName = (string)Session["Seniai"];

            for (int year = 0; year < allMembers.Count; year++)
            {
                for (int indexM = 0; indexM < allMembers[year].AllMembers.Count; indexM++)
                {
                    if (allMembers[year].AllMembers[indexM] is Student && ExperienceCheck(allMembers, year + 1, allMembers[year].AllMembers[indexM]))
                        newReg.Add(allMembers[year].AllMembers[indexM]);
                }
            }
            InOutUtils.FilterGraduatorsToFile(newReg, fileName);
            FilterGraduatorsToWeb(newReg);
        }

        /// <summary>
        /// Puts first task data to the web
        /// </summary>
        /// <param name="register">Input of a register list</param>
        protected void ExperienceToWeb(List<Register> register)
        {
            string dashes = new string('-', 69) + '\n';
            if (true)
            {
                TextBox3.Text += "Patyrę nariai" + '\n';
                foreach (Register reg in register)
                {
                    TextBox3.Text += reg.StudyYear;
                    TextBox3.Text += '\n';
                    TextBox3.Text += dashes;
                    TextBox3.Text += string.Format("| {0, -15} | {1, -15} | {2} | {3, -15} |", "Pavarde", "Vardas", "Gimimo data", "Tel. Nr.") + '\n';
                    TextBox3.Text += dashes;
                    for (int i = 0; i < reg.AllMembers.Count; i++)
                    {
                        TextBox3.Text += reg.AllMembers[i].ToString() + '\n';
                    }
                }
                TextBox3.Text += dashes + '\n';
            }
            else
            {
                TextBox3.Text += TextBox3.Text += "Patyrusių narių nėra!" + '\n';
                //throw new Exception("Patyrusių narių nėra!");
            }
        }

        /// <summary>
        /// Puts second task data to the web
        /// </summary>
        /// <param name="list">Input of a string list</param>
        protected void FilterByBirthdaysToWeb(List<string> list)
        {
            string dashes = new string('-', 69) + '\n';
            try
            {
                TextBox3.Text += "Dažniausi gimtadieniai" + '\n';
                TextBox3.Text += dashes;
                foreach (string s in list)
                {
                    TextBox3.Text += s + '\n';
                }
                TextBox3.Text += dashes;
            }
            catch (Exception)
            {
                TextBox3.Text += "Antrasis sąrašas yra tuščias!";
            }
        }

        /// <summary>
        /// Puts third task data to the web
        /// </summary>
        /// <param name="register">Input of a member register list</param>
        protected void FilterSeniorsAndOldMembersToWeb(List<Member> register)
        {
            string dashes = new string('-', 69) + '\n';
            TextBox3.Text += '\n';
            TextBox3.Text += "Senjorai ir seniai" + '\n';
            TextBox3.Text += dashes;
            TextBox3.Text += string.Format("| {0, -15} | {1, -15} | {2} | {3,-15} |", "Pavardė", "Vardas", "Gimimo data", "Tel.Nr.") + '\n';
            TextBox3.Text += dashes;
            if (register.Count > 0)
            {
                foreach (Member member in register)
                {
                    TextBox3.Text += member.ToString() + '\n';
                }
            }
            else
            {
                TextBox3.Text += "Senjorų ir senių nėra!" + '\n';
            }
            TextBox3.Text += '\n';
        }
        /// <summary>
        /// Puts fourth task data to the web
        /// </summary>
        /// <param name="register">Input of a member register lis</param>
        protected void FilterGraduatorsToWeb(List<Member> register)
        {
            string dashes = new string('-', 69) + '\n';
            TextBox3.Text += "Buvę studentai" + '\n';
            TextBox3.Text += dashes;
            TextBox3.Text += string.Format("| {0, -15} | {1, -15} | {2} | {3,-15} |", "Pavarde", "Vardas", "Gimimo data", "Tel.Nr.") + '\n';
            TextBox3.Text += dashes;
            if (register.Count > 0)
            {
                foreach (Member member in register)
                {
                    TextBox3.Text += member.ToString() + '\n';
                }
            }
            else
            {
                throw new Exception(TextBox3.Text += "Nėra buvusių studentų!");
            }
            TextBox3.Text += dashes;
        }
    }
}