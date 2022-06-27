using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Lab5
{
    /// <summary>
    /// partial class for web
    /// </summary>
    public partial class Form1
    {
        /// <summary>
        /// Declaring TaskUtils and only list in class
        /// </summary>
        List<Register> allMembers;
        /// <summary>
        /// Sorted list to web
        /// </summary>
        /// <param name="p"></param>
        protected void SortedToWeb(List<Player> p)
        {
            if (p.Count != 0)
            {
                //string dashes = new string('-', 69) + '\n';
                //if (true)
                //{
                //    TextBox3.Text += "Rezultatai atitinkantys pasirinktus kriterijus:" + '\n';
                //    TextBox3.Text += dashes;
                //    TextBox3.Text += string.Format("| {0, -15} | {1, -15} | {2} | {3, -15} |", "Pavarde", "Vardas", "Gimimo data", "Tel. Nr.") + '\n';
                //    TextBox3.Text += dashes;
                //    foreach (var player in p)
                //    {
                //        TextBox3.Text += player.ToString() + '\n';
                //    }
                //    TextBox3.Text += dashes + '\n';
                //}
                Table t = new Table();
                TableRow row1 = new TableRow();
                TableCell title = new TableCell
                {
                    Text = "Rezultatai atitinkantys pasirinktus kriterijus:"
                };
                row1.Cells.Add(title);
                t.Rows.Add(row1);
                TableRow row = new TableRow();
                TableCell team = new TableCell
                {
                    Text = "Komanda"
                };
                row.Cells.Add(team);
                TableCell surname = new TableCell
                {
                    Text = "Pavardė"
                };
                row.Cells.Add(surname);
                TableCell name = new TableCell
                {
                    Text = "Vardas"
                };
                row.Cells.Add(name);
                TableCell faults = new TableCell
                {
                    Text = "Baudos"
                };
                row.Cells.Add(faults);
                TableCell time = new TableCell
                {
                    Text = "Minutės"
                };
                row.Cells.Add(time);
                TableCell points = new TableCell
                {
                    Text = "Taškai"
                };
                row.Cells.Add(points);
                t.Rows.Add(row);
                Panel1.Controls.Add(t);

                foreach (Player player in p)
                {
                    ToWEBB(player, t);
                }
            }
            else
            {
                Table t = new Table();
                TableRow row1 = new TableRow();
                TableCell pav = new TableCell
                {
                    Text = "Sąrašo sudaryti nepavyko!"
                };
                row1.Cells.Add(pav);
                t.Rows.Add(row1);
                Panel1.Controls.Add(t);
            }


        }
        /// <summary>
        /// Pradiniai duomenys
        /// </summary>
        /// <param name="list"></param>
        protected void PrintToWeb(List<Player> list)
        {

            if (list.Count != 0)
            {
                Table t = new Table();
                TableRow row1 = new TableRow();
                TableCell title = new TableCell
                {
                    Text = "Naudingiausi žaidėjai"
                };
                row1.Cells.Add(title);
                t.Rows.Add(row1);
                TableRow row = new TableRow();
                TableCell team = new TableCell
                {
                    Text = "Komanda"
                };
                row.Cells.Add(team);
                TableCell surname = new TableCell
                {
                    Text = "Pavardė"
                };
                row.Cells.Add(surname);
                TableCell name = new TableCell
                {
                    Text = "Vardas"
                };
                row.Cells.Add(name);
                TableCell faults = new TableCell
                {
                    Text = "Baudos"
                };
                row.Cells.Add(faults);
                TableCell time = new TableCell
                {
                    Text = "Minutės"
                };
                row.Cells.Add(time);
                TableCell points = new TableCell
                {
                    Text = "Taškai"
                };
                row.Cells.Add(points);
                t.Rows.Add(row);
                Panel1.Controls.Add(t);

                foreach (Player player in list)
                {
                    ToWEBB(player, t);
                }
            }
            else
            {
                Table t = new Table();
                TableRow row1 = new TableRow();
                TableCell pav = new TableCell
                {
                    Text = "Sąrašo sudaryti nepavyko!"
                };
                row1.Cells.Add(pav);
                t.Rows.Add(row1);
                Panel1.Controls.Add(t);
            }
        }


        /// <summary>
        /// Pradiniu duomenu ivedimas
        /// </summary>
        protected void StartingData()
        {
            allMembers = (List<Register>)Session["Members"];

            Table t = new Table();
            TableRow row1 = new TableRow();
            TableCell title = new TableCell
            {
                Text = "Pradiniai duomenys"
            };
            row1.Cells.Add(title);
            t.Rows.Add(row1);
            TableRow row = new TableRow();
            TableCell team = new TableCell
            {
                Text = "Komanda"
            };
            row.Cells.Add(team);
            TableCell surname = new TableCell
            {
                Text = "Pavardė"
            };
            row.Cells.Add(surname);
            TableCell name = new TableCell
            {
                Text = "Vardas"
            };
            row.Cells.Add(name);
            TableCell faults = new TableCell
            {
                Text = "Baudos"
            };
            row.Cells.Add(faults);
            TableCell time = new TableCell
            {
                Text = "Minutės"
            };
            row.Cells.Add(time);
            TableCell points = new TableCell
            {
                Text = "Taškai"
            };
            row.Cells.Add(points);
            t.Rows.Add(row);
            Panel1.Controls.Add(t);

            foreach (Register register in allMembers)
            {
                ToWEB(register.AllMembers, t, register.year);
            }
        }
        /// <summary>
        /// printing players info to web
        /// </summary>
        /// <param name="list"></param>
        protected void PlayersData(List<PlayerData> list)
        {
            Table t = new Table();
            TableRow row1 = new TableRow();
            TableCell title = new TableCell
            {
                Text = "Informacija apie žaidėjus"
            };
            row1.Cells.Add(title);
            t.Rows.Add(row1);
            TableRow row = new TableRow();
            TableCell team = new TableCell
            {
                Text = "Komanda"
            };
            row.Cells.Add(team);
            TableCell surname = new TableCell
            {
                Text = "Pavarde"
            };
            row.Cells.Add(surname);
            TableCell name = new TableCell
            {
                Text = "Vardas"
            };
            row.Cells.Add(name);
            TableCell position = new TableCell
            {
                Text = "Pozicija"
            };
            row.Cells.Add(position);
            t.Rows.Add(row);
            Panel1.Controls.Add(t);

            foreach (PlayerData pD in list)
            {
                ToWEBPlayers(pD, t);
            }
            TableRow row2 = new TableRow();
            TableCell space = new TableCell
            {
                Text = " "
            };
            row2.Cells.Add(space);



        }
        /// <summary>
        /// printing players info to web
        /// </summary>
        /// <param name="pD"></param>
        /// <param name="table"></param>
        protected void ToWEBPlayers(PlayerData pD, Table table)
        {
            TableRow row = new TableRow();
            TableCell team = new TableCell
            {
                Text = pD.TeamName
            };
            row.Cells.Add(team);
            TableCell surname = new TableCell
            {
                Text = pD.Surname
            };
            row.Cells.Add(surname);
            TableCell name = new TableCell
            {
                Text = pD.Name
            };
            row.Cells.Add(name);
            TableCell position = new TableCell
            {
                Text = pD.Position
            };
            row.Cells.Add(position);
            table.Rows.Add(row);

            Panel1.Controls.Add(table);
        }
        /// <summary>
        /// method printing list to web
        /// </summary>
        /// <param name="p"></param>
        /// <param name="table"></param>
        protected void ToWEBB(Player p, Table table)
        {
            TableRow row1 = new TableRow();

            TableCell teamName = new TableCell
            {
                Text = p.TeamName
            };
            row1.Cells.Add(teamName);
            TableRow row = new TableRow();
            TableCell team = new TableCell
            {
                Text = p.TeamName
            };
            row.Cells.Add(team);
            TableCell surname = new TableCell
            {
                Text = p.Surname
            };
            row.Cells.Add(surname);
            TableCell name = new TableCell
            {
                Text = p.Name
            };
            row.Cells.Add(name);
            TableCell faults = new TableCell
            {
                Text = string.Format("{0}", p.TotalFauls)
            };
            row.Cells.Add(faults);
            table.Rows.Add(row);
            TableCell time = new TableCell
            {
                Text = string.Format("{0}", p.TotalMin)
            };
            row.Cells.Add(time);
            TableCell points = new TableCell
            {
                Text = string.Format("{0}", p.TotalPoints)
            };
            row.Cells.Add(points);
            Panel1.Controls.Add(table);
        }
        /// <summary>
        /// Error printing method
        /// </summary>
        /// <param name="errorMess"></param>
        protected void PrintToWebError(string errorMess)
        {
            Label4.Text += errorMess + '\n';
        }

        /// <summary>
        /// function which creates tables and prints them to user interface
        /// </summary>
        /// <param name="p"></param>
        /// <param name="table"></param>
        /// <param name="yearr"></param>
        protected void ToWEB(List<Player> p, Table table, string year)
        {
            TableRow row1 = new TableRow();
            TableCell title = new TableCell
            {
                Text = "Varžybų data: " + year
            };
            row1.Cells.Add(title);
            table.Rows.Add(row1);

            if (p != null)
            {
                for (int i = 0; i < p.Count; i++)
                {
                    TableRow row = new TableRow();
                    TableCell team = new TableCell
                    {
                        Text = p[i].TeamName
                    };
                    row.Cells.Add(team);
                    TableCell surname = new TableCell
                    {
                        Text = p[i].Surname
                    };
                    row.Cells.Add(surname);
                    TableCell name = new TableCell
                    {
                        Text = p[i].Name
                    };
                    row.Cells.Add(name);
                    TableCell faults = new TableCell
                    {
                        Text = string.Format("{0}", p[i].TotalFauls)
                    };
                    row.Cells.Add(faults);
                    table.Rows.Add(row);
                    TableCell time = new TableCell
                    {
                        Text = string.Format("{0}", p[i].TotalMin)
                    };
                    row.Cells.Add(time);
                    TableCell points = new TableCell
                    {
                        Text = string.Format("{0}", p[i].TotalPoints)
                    };
                    row.Cells.Add(points);
                }
                Panel1.Controls.Add(table);
            }
        }
    }
}