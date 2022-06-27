using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Lab4
{
    /// <summary>
    /// This class is dedicated to how the website acts ant fullfills the task
    /// </summary>
    public partial class Form1 : System.Web.UI.Page
    {
        private readonly List<Register> Members = new List<Register>();
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string[] fileNames = Directory.GetFiles(Server.MapPath(@"App_Data/"), "*.txt", SearchOption.TopDirectoryOnly);
            string resultFile = Server.MapPath(@"App_Data/Rezultatai/Rezultatai.txt");
            string firstPath = Server.MapPath(@"App_Data/Rezultatai/Patirtis.csv");
            string senjoraiCSV = Server.MapPath(@"App_Data/Rezultatai/Senjorai.csv");
            string seniaiCSV = Server.MapPath(@"App_Data/Rezultatai/Seniai.csv");

            bool flag = true;

            File.Delete(resultFile);

            try
            {
                foreach (string fileName in fileNames)
                {
                    if (new FileInfo(fileName).Length == 0)
                        throw new FileNotFoundException();
                    Members.Add(InOutUtils.ReadFile(fileName));
                    InOutUtils.StartingDataToFile(resultFile, Members.Last());
                }
                Session["Flag"] = flag;
                Session["Members"] = Members;
                Session["ResultFile"] = resultFile;
                Session["FirstPath"] = firstPath;
                Session["Senjorai"] = senjoraiCSV;
                Session["Seniai"] = seniaiCSV;
                StartingData();
            }
            catch (FileNotFoundException)
            {
                InOutUtils.ErrorPrint(resultFile);
                foreach (var fileName in fileNames)
                {
                    ResultBox.Text = $"Klaidingi duomenys faile: {fileName}";
                }
            }

            FilterByExperience(out flag);
            if (flag)
            {
                FilterByBirthdays();
                FilterSeniorsAndOldMembers();
                FilterGraduators();
            }
        }
    }
}