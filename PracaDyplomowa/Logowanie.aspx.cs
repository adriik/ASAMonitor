using RestSharp;
using RestSharp.Authenticators;
using System;

namespace PracaDyplomowa
{
    /// <summary>
    /// Klasa reprezentująca back-end ekranu logowania
    /// </summary>
    /// <seealso cref="System.Web.UI.Page" />
    public partial class Logowanie : System.Web.UI.Page
    {
        /// <summary>
        /// Metoda wywoływana podczas uruchamiania strony.
        /// </summary>
        /// <param name="sender">Źródło wydarzenia.</param>
        /// <param name="e">The <see cref="EventArgs"/> Obiekt przechowujący dane wydarzenia.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }


        /// <summary>
        /// Metoda wyłapująca kliknięcie przycisku.
        /// </summary>
        /// <param name="sender">Źródło wydarzenia.</param>
        /// <param name="e">The <see cref="EventArgs"/> Obiekt przechowujący dane wydarzenia.</param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {

            var client = new RestClient("https://" + TextBoxIp.Text);
            client.Authenticator = new HttpBasicAuthenticator(TextBoxName.Text, TextBoxPassword.Text);
            var request = new RestRequest("/api/tokenservices", Method.POST);
            IRestResponse response = client.Execute(request);

            if (!response.IsSuccessful || response.ErrorException != null)
            {
                if (response.ErrorException != null)
                {
                    ValidatorBlad.ErrorMessage = "Podany adres nie odpowiada";
                }
                else
                {
                    ValidatorBlad.ErrorMessage = "Złe hasło lub nie ma takiego użytkownika";
                }
                ValidatorBlad.IsValid = false;
            }
            else
            {
                Session["client"] = client;
                Response.Redirect("StronaGlowna.aspx");
            }
        }
    }
}