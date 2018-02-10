using Newtonsoft.Json;
using RestSharp;
using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PracaDyplomowa
{
    /// <summary>
    /// Klasa reprezentująca back-end ekranu strony głównej.
    /// </summary>
    /// <seealso cref="System.Web.UI.Page" />
    public partial class _StronaGlowna : Page
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
            else if (!IsPostBack && !IsCallback)
            {
                RestClient client = (RestClient)Session["client"];
                var request2 = new RestRequest("/api/monitoring/device/components/version", Method.GET);
                IRestResponse response2 = client.Execute(request2);

                var content = response2.Content;
                dynamic stuff = JsonConvert.DeserializeObject(content);
                Label1.Text = "Urządzenie jest uruchmione od: " + (float)stuff.upTimeinSeconds / 60 + " minut";
                Label2.Text = "Wersja systemu: " + stuff.asaVersion;
                Label3.Text = "Tryb firewalla: " + stuff.firewallMode;

                request2 = new RestRequest("/api/monitoring/clock", Method.GET);
                response2 = client.Execute(request2);

                content = response2.Content; 
                stuff = JsonConvert.DeserializeObject(content);
                LabelGodzina.Text = "Ustawiona data: " + stuff.date + "  " + stuff.time;
                var request4 = new RestRequest("/api/interfaces/physical", Method.GET);
                IRestResponse response4 = client.Execute(request4);
                content = response4.Content;
                Interfejs interfejsy = JsonConvert.DeserializeObject<Interfejs>(content);


                if (interfejsy != null && interfejsy.items != null)
                {
                    foreach (var item in interfejsy.items)
                    {
                        var request5 = new RestRequest("api/monitoring/ipaddress/", Method.GET);
                        IRestResponse response5 = client.Execute(request5);
                        content = response5.Content;
                        Interfejs2 interfejsyZIp = JsonConvert.DeserializeObject<Interfejs2>(content);

                        TableRow tRow = new TableRow();
                        TableCell interfejs = new TableCell();
                        TableCell ip = new TableCell();
                        TableCell maska = new TableCell();
                        TableCell mtu = new TableCell();
                        TableCell status = new TableCell();
                        TableCell ccl = new TableCell();

                        interfejs.Text = item.hardwareID;
                        ip.Text = " ";
                        maska.Text = " ";

                        if (interfejsyZIp != null && interfejsyZIp.items != null)
                        {
                            foreach (var inter in interfejsyZIp.items)
                            {
                                if (inter.interfejs.objectId == item.objectId)
                                {
                                    ip.Text = inter.ipAddress;
                                    maska.Text = inter.netmask;
                                    ccl.Text = string.Format("<span class='{0}'></span>", inter.isClusterInterface == false ? "glyphicon glyphicon-remove-circle text-danger" : "glyphicon glyphicon-ok-circle text-success");
                                }
                            }
                        }


                        mtu.Text = item.mtu.ToString();
                        status.Text = string.Format("<span class='{0}'></span>", item.shutdown.ToString() == "False" ? "glyphicon glyphicon-arrow-up text-success" : "glyphicon glyphicon-arrow-down text-danger");
                        tRow.Cells.Add(interfejs);
                        tRow.Cells.Add(ip);
                        tRow.Cells.Add(maska);
                        tRow.Cells.Add(mtu);
                        tRow.Cells.Add(ccl);
                        tRow.Cells.Add(status);
                        Table1.Rows.Add(tRow);
                    }
                }
                Page.DataBind();
            }
        }

        /// <summary>
        /// Metoda wykonywana do odświeżania informacji dotyczących ASA.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Timer_Tick(object sender, EventArgs e)
        {

            RestClient client = (RestClient)Session["client"];
            var request2 = new RestRequest("/api/monitoring/device/components/version", Method.GET);
            IRestResponse response2 = client.Execute(request2);

            var content = response2.Content;
            dynamic stuff = JsonConvert.DeserializeObject(content);
            Label1.Text = "Urządzenie jest uruchmione od: " + (float)stuff.upTimeinSeconds / 60 + " minut";
            Label2.Text = "Wersja systemu: " + stuff.asaVersion;
            Label3.Text = "Tryb firewalla: " + stuff.firewallMode;

            request2 = new RestRequest("/api/monitoring/clock", Method.GET);
            response2 = client.Execute(request2);

            content = response2.Content;
            stuff = JsonConvert.DeserializeObject(content);
            LabelGodzina.Text = "Ustawiona data: " + stuff.date + "  " + stuff.time;

            Page.DataBind();
        }
    }
}