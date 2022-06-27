using System;
using System.IO;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Lab2
{
    /// <summary>
    /// This is a class dedicated to elements and how their usage proceeds 
    /// </summary>
    public partial class Form1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            string file1 = null;
            string file2 = null;
            if (FileUpload1.HasFile && FileUpload1.FileName.EndsWith(".txt") && FileUpload2.HasFile && FileUpload2.FileName.EndsWith(".txt"))
            {
                Session["file1"] = FileUpload1.FileName;
                file1 = Server.MapPath(Convert.ToString("App_Data/" + FileUpload1.FileName));
                Session["file2"] = FileUpload2.FileName;
                file2 = Server.MapPath(Convert.ToString("App_Data/" + FileUpload2.FileName));
            }
            else if (Session["file1"] != null && Session["file2"] != null)
            {
                file1 = Server.MapPath(Convert.ToString("App_Data/" + FileUpload1.FileName));
                file2 = Server.MapPath(Convert.ToString("App_Data/" + FileUpload2.FileName));
            }

            string pathToThemesFile = file2;
            string pathToScientistsFile = file1;

            if (TextBox4.Text.Length == 0)
            {
                Label10.Text = "Pavadinimo langelis tuščias";
            }
            else if (TaskUtils.ContainsCharacters(TextBox5.Text))
            {
                Label11.Text = "Įvestas mėnesio numeris turi tilpti į rėžius [1-12]";
            }
            else if (TextBox4.Text.Length == 0)
            {
                Label10.Text = "Tuščias pirmas duomenų failas";
            }
            else if (file1 == null || file2 == null || file1 == null && file2 == null)
            {
                Label19.Text = "Duomenų failai tušti!/Netinkamas duomenų failo formatas!";
            }
            else
            {
                string SearchedPublications = TextBox4.Text;
                int SearchedMonth = int.Parse(TextBox5.Text);
                File.Delete(Server.MapPath(@"App_Data/PradiniaiDuomenys.txt"));
                File.Delete(Server.MapPath(@"App_Data/Rezultatai.txt"));
                TextBox7.Text = "";
                TextBox6.Text = "";
                if (pathToScientistsFile == null || pathToThemesFile == null)
                {
                    TextBox7.Text += "Duomenų failas nepasiekiamas";
                }
                else
                {
                    LinkedList<Publications> list = new LinkedList<Publications>();
                    InOutUtils.ReadLifo1(list, pathToScientistsFile);
                    TextBox t = new TextBox();
                    TextBox7.Text += t.Text;

                    t.Text = "";
                    LinkedList<Subscribers> list1 = new LinkedList<Subscribers>();
                    InOutUtils.ReadLifo2(list1, pathToThemesFile);
                    PrintFirst(list);
                    PrintSecond(list1);

                    InOutUtils.Print(Server.MapPath(@"App_Data/Rezultatai.txt"), list, "Informacija apie leidinius", 43);
                    InOutUtils.Print(Server.MapPath(@"App_Data/Rezultatai.txt"), list1, "Informacija apie prenumeratorius", 77);
                    TextBox7.Text += t.Text;

                    LinkedList<Subscribers> resultList = new LinkedList<Subscribers>();
                    TaskUtils.AddToList(list, list1, resultList, SearchedPublications, SearchedMonth);
                    PrintResults(resultList, Server.MapPath(@"App_Data/Rezultatai.txt"));

                    List<string> firstList = TaskUtils.MonthlyIncomeMax(list1, list, Server.MapPath(@"App_Data/Rezultatai.txt"));
                    FirstTask(firstList);

                    LinkedList<decimal> Sum = TaskUtils.IncomeSum(list, list1);
                    InOutUtils.PrintSummedIncome(Sum, list, Server.MapPath(@"App_Data/Rezultatai.txt"));
                    SecondTask(Sum, list);

                    LinkedList<string> stringList = TaskUtils.LowIncome(list, list1, Server.MapPath(@"App_Data/Rezultatai.txt"));
                    ThirdTask(stringList, Server.MapPath(@"App_Data/Rezultatai.txt"));
                }
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/txt";
            Response.AppendHeader("Content-Disposition", "attachment; filename=Rezultatai.txt");
            Response.TransmitFile(Server.MapPath("App_Data/Rezultatai.txt"));
            Response.End();
        }
    }
}