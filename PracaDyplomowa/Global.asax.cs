using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace PracaDyplomowa
{
    /// <summary>
    /// Klasa odpowiedzialna za globalną konfigurację aplikacji.
    /// </summary>
    /// <seealso cref="System.Web.HttpApplication" />
    public class Global : HttpApplication
    {
        //string result = "";
        /// <summary>
        /// Lista przechowująca odebrane komunikaty z ASA.
        /// </summary>
        List<Syslog> lista;

        /// <summary>
        /// Atrybut przechowujący numer portu UDP na którego wysyłane są komuniakty z ASA. 
        /// </summary>
        const int portUDP = 2055;

        /// <summary>
        /// Metoda wywoływana podczas startu aplikacji.
        /// </summary>
        /// <param name="sender">Źródło wywołania.</param>
        /// <param name="e">The <see cref="EventArgs"/> Obiekt przechowujący dane wydarzenia.</param>
        void Application_Start(object sender, EventArgs e)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            IgnoreBadCertificates();
            Application["UDP"] = null;
            Application["Syslog"] = null;
            UdpClient udpc = new UdpClient(portUDP);
            Task task = new Task(async () => await PobieranieKomunikatow(udpc));
            task.Start();

            //Budowanie Bazy danych, wykonywane tylko jeżeli baza jest pusta.
            //BudowanieDB();
        }

        /// <summary>
        /// Metoda odpowiedzialna za budowanies bazy danych.
        /// </summary>
        public void BudowanieDB()
        {
            int licznik = 1;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ASA"].ConnectionString);
            conn.Open();
            var html = new HtmlDocument();
            for (int item = 1; item < 11; item++)
            {
                var lines = File.ReadLines(path: HttpContext.Current.Server.MapPath("~/App_Data/dokument" + item + ".txt"));
                foreach (var line in lines)
                {
                    string[] tablica = line.Split(':');
                    foreach (var item2 in tablica.Skip(1))
                    {
                        string insertQuery = "insert into Syslog(Id,Id_na_stronie,Numer,Opis,Rozwiazanie,Id_strony)values (@Id,@Id_na_stronie,@Numer,@Opis,@Rozwiazanie,@Id_strony)";
                        SqlCommand cmd = new SqlCommand(insertQuery, conn);
                        cmd.Parameters.AddWithValue("@Id_na_stronie", tablica[0]);
                        cmd.Parameters.AddWithValue("@Id", licznik);
                        licznik++;
                        cmd.Parameters.AddWithValue("@Numer", item2);

                        html.LoadHtml(new WebClient().DownloadString("https://www.cisco.com/c/en/us/td/docs/security/asa/syslog/b_syslog/syslogs" + item + ".html"));
                        
                        for (int j = 1; j < 5; j++)
                        {


                            var titleNode = html.DocumentNode.SelectSingleNode(xpath: "//*[@id=\"" + tablica[0] + "\"]/section/p[" + j + "]");
                            if (titleNode != null && titleNode.InnerText.Contains("Explanation"))
                            {
                                cmd.Parameters.AddWithValue("@Opis", titleNode.InnerText.Trim().Replace("Explanation ", ""));
                                break;
                            }
                            else if (j == 4)
                            {
                                cmd.Parameters.AddWithValue("@Opis", "Brak");
                            }
                        }

                        for (int j = 1; j < 5; j++)
                        {
                            var titleNode2 = html.DocumentNode.SelectSingleNode(xpath: "//*[@id=\"" + tablica[0] + "\"]/section/p[" + j + "]");
                            if (titleNode2 != null && titleNode2.InnerText.Contains("Recommended Action "))
                            {
                                cmd.Parameters.AddWithValue("@Rozwiazanie", titleNode2.InnerText.Trim().Replace("Recommended Action ", ""));
                                break;
                            }
                            else if(j == 4)
                            {
                                cmd.Parameters.AddWithValue("@Rozwiazanie", "Brak");
                            }
                        }
                        cmd.Parameters.AddWithValue("@Id_strony", item);
                        cmd.ExecuteNonQuery();
                    }
                }
                System.Diagnostics.Debug.WriteLine("\nStatus budowania bazy: " + item);
            }
            conn.Close();
        }

        /// <summary>
        /// Metoda odpowiedzialna za ignorowanie złych certyfikatów.
        /// </summary>
        public static void IgnoreBadCertificates()
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
        }


        /// <summary>
        /// Metoda odpowiedzialna za akceptację wszystkich certyfikatów.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="certification">The certification.</param>
        /// <param name="chain">The chain.</param>
        /// <param name="sslPolicyErrors">The SSL policy errors.</param>
        /// <returns></returns>
        private static bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        /// <summary>
        /// Metoda odpowiedzialna za równoległe pobieranie cały czas komunikatów z ASA.
        /// </summary>
        /// <param name="udpc">Obiekt klienta UDP</param>
        /// <returns></returns>
        protected Task PobieranieKomunikatow(UdpClient udpc)
        {
            byte[] rdata = null;
            lista = new List<Syslog>();

            while (true)
            {
                IPEndPoint ep = null;
                rdata = udpc.Receive(ref ep);
                lista.Add(new Syslog(System.Text.Encoding.UTF8.GetString(rdata)));
                Application["Syslog"] = lista;
            }

        }
    }
}