using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;

namespace PracaDyplomowa
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Metoda wywoływane przez naciśnięcie przycisku wyloguj.
        /// </summary>
        /// <param name="sender"> obiekt wywołujący.</param>
        /// <param name="e">The <see cref="EventArgs"/> Obiekt przechowujący dane wydarzenia.</param>
        protected void Wyloguj(object sender, EventArgs e)
        {
            HttpContext.Current.Session.Remove("client");
            FormsAuthentication.RedirectToLoginPage();
        }

        /// <summary>
        /// Metoda wywoływane przez naciśnięcie przycisku zaloguj.
        /// </summary>
        /// <param name="sender">obiekt wywołujący.</param>
        /// <param name="e">The <see cref="EventArgs"/> Obiekt przechowujący dane wydarzenia.</param>
        protected void Zaloguj(object sender, EventArgs e)
        {
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}