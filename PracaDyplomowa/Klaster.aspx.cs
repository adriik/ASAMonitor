using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PracaDyplomowa
{
    public partial class Klaster : System.Web.UI.Page
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
        /// Metoda wywoływana podczas uruchamiania strony.
        /// </summary>
        /// <param name="sender">Źródło wydarzenia.</param>
        /// <param name="e">The <see cref="EventArgs"/> Obiekt przechowujący dane wydarzenia.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["client"] == null)
            {
                FormsAuthentication.RedirectToLoginPage();
                return;
            }
            else
            {
                RestClient client = (RestClient)Session["client"];
                var request = new RestRequest("/api/cli", Method.POST);
                Komenda komendy = new Komenda();

                komendy.commands.Add("show cluster info");

                //System.Diagnostics.Debug.WriteLine("\nJson: " + JsonConvert.SerializeObject(komendy));

                request.AddParameter("application/json", JsonConvert.SerializeObject(komendy), ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);

                var content = response.Content; // raw content as string
                                                //int dlugosc = content.Length;

                
                textareaCluster.InnerHtml = content.Substring(14, content.Length - 3 - 14).Replace("\\n", "&#10;");  //14 3
            }

            if (Application["Syslog"] != null)
            {
                List<Syslog> lista = new List<Syslog>((List<Syslog>)Application["Syslog"]);
                //lista.Add(new Syslog("<167>Jan 17 2018 06:32:09: %ASA-7-747005: Clustering: State machine notify event CLUSTER_EVENT_MEMBER_STATE (ASA-2,DISABLED,0x0000000000000000)"));
                //lista.Add(new Syslog("<167>Jan 17 2018 06:34:10: %ASA-7-747005: Clustering: State machine notify event CLUSTER_EVENT_MEMBER_STATE (ASA-2,SLAVE_COLD,0x0000000000000000)"));
                //lista.Add(new Syslog("<167>Jan 17 2018 06:34:10: %ASA-7-747005: Clustering: State machine notify event CLUSTER_EVENT_MEMBER_STATE (ASA-2,SLAVE_APP_SYNC,0x0000000000000000)"));
                //lista.Add(new Syslog("<167>Jan 17 2018 06:34:10: %ASA-7-747005: Clustering: State machine notify event CLUSTER_EVENT_MEMBER_STATE (ASA-2,SLAVE_CONFIG,0x0000000000000000)"));
                //lista.Add(new Syslog("<167>Jan 17 2018 06:34:13: %ASA-7-747005: Clustering: State machine notify event CLUSTER_EVENT_MEMBER_IFC_STATE (0x0000000000000001,0x00002aaac99a7a90,0x0000000000000001)"));
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ASA"].ConnectionString);
                conn.Open();

                foreach (var item in lista)
                {
                    if (item.Komunikat.Contains("Cluster"))
                    {
                        textareaKomunikaty.InnerText += item.Komunikat + "\n";

                        TableRow tRow = new TableRow();
                        TableCell id = new TableCell();
                        TableCell explanation = new TableCell();
                        TableCell action = new TableCell();
                        TableCell hiperlacza = new TableCell();
                        TableCell czas = new TableCell();
                        TableCell komunikat = new TableCell();
                        id.Text = item.NumerLogu.ToString();
                        czas.Text = item.Data;
                        komunikat.Text = item.Komunikat;

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
                        tRow.Cells.Add(komunikat);
                        tRow.Cells.Add(explanation);
                        tRow.Cells.Add(action);
                        tRow.Cells.Add(hiperlacza);
                        Table1.Rows.Add(tRow);
                    }
                }
                conn.Close();
                Page.DataBind();
            }
        }

        /// <summary>
        /// Metoda odpowiedzialna za wysłanie pliku tekstowego zawierającego raport do użytkownika.
        /// </summary>
        /// <param name="sender">Źródło wywołania.</param>
        /// <param name="e">The <see cref="EventArgs"/> Obiekt przechowujący dane wydarzenia.</param>
        protected void Pobierz(object sender, EventArgs e)
        {
            StreamWriter file = new StreamWriter(Server.MapPath("~/logfile.txt"), false);
            List<Syslog> lista = new List<Syslog>((List<Syslog>)Application["Syslog"]);
            foreach (var item in lista) 
            {
                if (item.Komunikat.Contains("Cluster"))
                {
                    file.WriteLine(item.Komunikat);
                }

            }
            file.Close();

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=logfile" + DateTime.Now + ".txt");


            Response.TransmitFile("~/logfile.txt");
            Response.End();
        
        }
    }
}