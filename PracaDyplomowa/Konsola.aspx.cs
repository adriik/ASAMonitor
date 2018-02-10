using Newtonsoft.Json;
using RestSharp;
using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PracaDyplomowa
{
    /// <summary>
    /// Klasa reprezentująca back-end ekranu Konsola
    /// </summary>
    /// <seealso cref="System.Web.UI.Page" />
    public partial class Konsola : Page
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
        /// Metoda wykonywana podczas uruchamiania strony.
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
        }


        /// <summary>
        /// Metoda wyłapująca kliknięcie przycisku.
        /// </summary>
        /// <param name="sender">Źródło wydarzenia.</param>
        /// <param name="e">The <see cref="EventArgs"/> Obiekt przechowujący dane wydarzenia.</param>
        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            RestClient client = (RestClient)Session["client"];
            var request = new RestRequest("/api/cli", Method.POST);
            Komenda komendy = new Komenda();
            komendy.commands.Add(TextBoxKomenda.Text);
            //System.Diagnostics.Debug.WriteLine("\nJson: " + JsonConvert.SerializeObject(komendy));
            request.AddParameter("application/json", JsonConvert.SerializeObject(komendy), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var content = response.Content; 
            textarea.InnerHtml += "#" + TextBoxKomenda.Text + "&#10;" + content.Substring(14, content.Length - 3 - 14).Replace("\\n", "&#10;");
        }
    }
}