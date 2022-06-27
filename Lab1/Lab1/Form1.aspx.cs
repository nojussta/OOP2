using System;
using System.IO;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Lab1
{
    /// <summary>
    /// This is a class of the web page
    /// </summary>
    public partial class Form1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// This is a method which begins to work after the button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            string CFr = Server.MapPath(@"App_Data/Rezultatai.txt");
            File.Delete(CFr);
            Register register = InputData();
            if (register.Count() == 0)
            {
                Label3.Text = "Neteisingas duomenų formatas!";
            }
            else
            {
                InOutUtils.PrintDataToFile(register, CFr);
                string line = "";
                for (int i = 0; i < register.Count(); i++)
                {
                    line += string.Format(" {0}{1}", register.Get(i).FirstDigit, register.Get(i).SecondDigit);
                }
                List<int[]> dominos = TaskUtils.DominoesSolve(register);
                PrintResultsToWebsite(dominos);
                TableRow row = new TableRow();
                TableCell cell = new TableCell
                {
                    Text = line
                };
                row.Cells.Add(cell);
                Table1.Rows.Add(row);
                InOutUtils.PrintResultsToFile(dominos, CFr);
                if (dominos.Capacity <= 0)
                {
                    Label3.Text = "Neįmanoma sudaryti grandinės!";
                }
            }
        }
    }
}