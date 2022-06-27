using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Lab4
{
    /// <summary>
    /// This class is dedicated for input/output data
    /// </summary>
    public static class InOutUtils
    {
        /// <summary>
        /// Reads data from a certain file
        /// </summary>
        /// <param name="line">Input string which has to be split into parts</param>
        /// <returns></returns>
        private static Member GetData(string line)
        {
            string[] part = line.Split(';');
            switch (part[0])
            {
                case "Student":
                    return new Student(part[1], double.Parse(part[2]), part[3], part[4], DateTime.Parse(part[5]), double.Parse(part[6]));
                case "Graduate":
                    return new Graduate(double.Parse(part[1]), part[2], part[3], part[4], DateTime.Parse(part[5]), double.Parse(part[6]));
                default:
                    return null;
            }
        }

        /// <summary>
        /// Puts data from a certain file to a register
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <returns></returns>
        public static Register ReadFile(string fileName)
        {
            List<Member> MemberRegister = new List<Member>();

            using (StreamReader reader = new StreamReader(fileName))
            {
                int year = int.Parse(reader.ReadLine());
                string line;
                if (year > 2022)
                {
                    throw new Exception("Nurodytas nelogiškas studijų metų skaičius!");
                }
                while ((line = reader.ReadLine()) != null)
                {
                    Member currMem = GetData(line);
                    if (currMem != null && !MemberRegister.Contains(currMem))
                    {
                        MemberRegister.Add(currMem);
                    }
                }

                if (MemberRegister.Count == 0)
                    throw new Exception("Studentų sąrašas nesusidaro!");
                return new Register(year, MemberRegister);
            }
        }

        /// <summary>
        /// Exception
        /// </summary>
        /// <param name="fileName">File name</param>
        public static void ErrorPrint(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine("Klaida duomenų faile!");
                //throw new Exception("Klaida duomenų faile!");
            }
        }

        /// <summary>
        /// Prints starting data to a file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="register"></param>
        /// <param name="header"></param>
        public static void StartingDataToFile(string fileName, Register register)
        {
            using (StreamWriter writer = File.AppendText(fileName))
            {
                string dashes = new string('-', 69);
                writer.WriteLine(register.StudyYear);
                writer.WriteLine(dashes);
                writer.WriteLine(String.Format("| {0, 15} | {1, 15} | {2} | {3, 15} |", "Pavarde", "Vardas", "Gimimo data", "Tel. Nr."));
                writer.WriteLine(dashes);
                foreach (Member m in register.AllMembers)
                {
                    writer.WriteLine("{0}", m.ToString());
                }
                writer.WriteLine(dashes);
                writer.WriteLine();
            }
        }

        /// <summary>
        /// Prints members filtered by experience as a .CSV file
        /// </summary>
        /// <param name="FirstTask">Members input list</param>
        /// <param name="fileName">File name</param>
        public static void FilterByExperienceToFile(List<Register> firstTask, string fileName)
        {
            File.Delete(fileName);
            string dashes = new string('-', 69);
            using (StreamWriter writer = new StreamWriter(new FileStream(fileName, FileMode.Create), Encoding.UTF8))
            {
                writer.WriteLine("Patyrę nariai");
                writer.WriteLine(String.Join(";", "Tipas", "Pavarde", "Vardas", "Gimimo data", "Tel. Nr.", "Kodas/Darbo startas", "Darbo vieta/Kursas"));
                if (firstTask.Count < 2)
                {
                    writer.WriteLine(dashes);
                    writer.WriteLine("Patyrusių narių nėra!");
                    writer.WriteLine(dashes);
                }
                else
                {
                    foreach (Register r in firstTask)
                    {
                        writer.WriteLine(r.StudyYear);
                        for (int i = 0; i < r.AllMembers.Count; i++)
                        {
                            writer.WriteLine(r.AllMembers[i].ToCSV());
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Prints data filtered by birthdays as a .CSV file 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="list"></param>
        public static void FilterByBirthdaysToFile(string filePath, List<string> list)
        {
            string dashes = new string('-', 69);
            using (StreamWriter writer = File.AppendText(filePath))
            {
                try
                {
                    writer.WriteLine("Dažniausi gimtadieniai");
                    writer.WriteLine(dashes);
                    for (int i = 0; i < list.Count; i++)
                    {
                        writer.WriteLine(list[i]);
                    }
                    writer.WriteLine(dashes);
                }
                catch (Exception)
                {
                    writer.WriteLine(dashes);
                    writer.WriteLine("Dažniausių gimtadienių nėra!");
                    writer.WriteLine(dashes);
                }
            }
        }

        /// <summary>
        /// Prints fildered senior and old members data as a .CSV file
        /// </summary>
        /// <param name="allMembers">Members input list</param>
        /// <param name="fileName">File name</param>
        public static void FilterSeniorsAndOldMembersToFile(List<Member> allMembers, string fileName)
        {
            string dashes = new string('-', 69);
            using (StreamWriter writer = new StreamWriter(new FileStream(fileName, FileMode.Create), Encoding.UTF8))
            {
                if (allMembers.Count > 0)
                {
                    writer.WriteLine("Senjorai ir seniai");
                    writer.WriteLine(String.Join(";", "Tipas", "Pavarde", "Vardas", "Gimimo data", "Tel. Nr.", "Kodas/Darbo startas", "Darbo vieta/Kursas"));
                    foreach (Member register in allMembers)
                    {
                        writer.WriteLine(register.ToCSV());
                    }
                }
                else
                {
                    writer.WriteLine(dashes);
                    writer.WriteLine("Senjorų ir senių nėra!");
                    writer.WriteLine(dashes);
                }
            }
        }

        /// <summary>
        /// Prints filtered graduators data as a .CSV file
        /// </summary>
        /// <param name="list"></param>
        /// <param name="fileName"></param>
        public static void FilterGraduatorsToFile(List<Member> list, string fileName)
        {
            string dashes = new string('-', 69);
            try
            {
                using (StreamWriter writer = new StreamWriter(new FileStream(fileName, FileMode.Create), Encoding.UTF8))
                {
                    if (list.Count > 0)
                    {
                        foreach (Member M in list)
                        {
                            writer.WriteLine("Seniai");
                            writer.WriteLine(String.Join(";", "Tipas", "Pavardė", "Vardas", "Gimimo data", "Tel. Nr.", "Kodas/Darbo startas", "Darbo vieta/Kursas"));
                            writer.WriteLine(M.ToCSV());
                        }
                    }
                    else
                    {
                        writer.WriteLine(dashes);
                        writer.WriteLine("Senių nėra!");
                        writer.WriteLine(dashes);
                    }
                }
            }
            catch (System.IO.IOException)
            {
                using (StreamWriter writer = new StreamWriter(new FileStream(fileName, FileMode.Create), Encoding.UTF8))
                {
                    writer.WriteLine("Atidarytas rezultatų failas!");
                }
            }
        }
    }
}