using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PracaDyplomowa
{
    /// <summary>
    /// Klasa reprezentująca back-end ekranu Interpretacja.
    /// </summary>
    /// <seealso cref="System.Web.UI.Page" />
    public partial class Interpretacja : System.Web.UI.Page
    {
        /// <summary>
        /// Metoda wykonywana tuż przed renderowaniem strony.
        /// </summary>
        /// <param name="sender">Źródło wydarzenia.</param>
        /// <param name="e">The <see cref="EventArgs"/> Obiekt przechowujący dane wydarzenia.</param>
        protected void Page_PreRender(object sender, EventArgs e)
        {
            ((Button)Master.FindControl("wylogowanie")).Visible = true;
        }

        /// <summary>
        /// Metoda wykonywana poczas ładowania danej strony.
        /// </summary>
        /// <param name="sender">Źródło wydarzenia.</param>
        /// <param name="e">The <see cref="EventArgs"/>Obiekt przechowujący dane wydarzenia.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["client"] == null)
            {
                FormsAuthentication.RedirectToLoginPage();
                return;
            }


            var html = new HtmlDocument();


            if (Application["Syslog"] != null)
            {
                List<Syslog> lista = new List<Syslog>((List<Syslog>)Application["Syslog"]);
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ASA"].ConnectionString);
                conn.Open();

                foreach (var item in lista) 
                {
                    TableRow tRow = new TableRow();
                    TableCell id = new TableCell();
                    TableCell explanation = new TableCell();
                    TableCell action = new TableCell();
                    TableCell hiperlacza = new TableCell();
                    TableCell czas = new TableCell();
                    id.Text = item.NumerLogu.ToString();
                    czas.Text = item.Data;

                    string selectQuery = "select Id_na_stronie, Opis, Rozwiazanie, Id_strony  from Syslog where Numer = @numer";
                    SqlCommand cmd = new SqlCommand(selectQuery, conn);
                    cmd.Parameters.AddWithValue("@numer", item.NumerLogu.ToString());

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            explanation.Text = String.Format("{0}", reader["Opis"]);
                            action.Text = String.Format("{0}", reader["Rozwiazanie"]);
                            hiperlacza.Text = "<a href = \"" + "https://www.cisco.com/c/en/us/td/docs/security/asa/syslog/b_syslog/syslogs" + String.Format("{0}", reader["Id_strony"]) + ".html#" + String.Format("{0}", reader["Id_na_stronie"]) + "\" class=\"btn btn-info\" role=\"button\">Więcej</a>";
                        }
                    }
                    
                    switch (item.Waga)
                    {
                        case 1:
                           tRow.CssClass = "danger";
                            break;
                        case 2:
                            tRow.CssClass = "danger";
                            break;
                        case 3:
                            tRow.CssClass = "danger";
                            break;
                        case 4:
                            tRow.CssClass = "warning";
                            break;
                        case 5:
                            tRow.CssClass = "info";
                            break;
                        case 6:
                            tRow.CssClass = "info";
                            break;
                        case 7:
                            tRow.CssClass = "active";
                            break;
                    }
                    tRow.Cells.Add(czas);
                    tRow.Cells.Add(id);
                    tRow.Cells.Add(explanation);
                    tRow.Cells.Add(action);
                    tRow.Cells.Add(hiperlacza);
                    Table1.Rows.Add(tRow);
                }
                conn.Close();
                Page.DataBind();
            }
        }
    }
}