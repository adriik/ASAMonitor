using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PracaDyplomowa
{
    /// <summary>
    /// Klasa reprezentująca back-end ekranu Syslog
    /// </summary>
    /// <seealso cref="System.Web.UI.Page" />
    public partial class StronaSyslog : Page
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
        /// Metoda wywoływana podczas startu strony.
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
        /// Metoda wywoływana podczas zamykania, opuszczania strony.
        /// </summary>
        /// <param name="sender">Źródło wydarzenia.</param>
        /// <param name="e">The <see cref="EventArgs"/> Obiekt przechowujący dane wydarzenia.</param>
        protected void Page_Dispose(object sender, EventArgs e) => ((Task)Session["Task"]).Dispose();

        /// <summary>
        /// Metoda wywoływana podczas odświeżania UpdatePanel.
        /// </summary>
        /// <param name="sender">Źródło wydarzenia</param>
        /// <param name="e">The <see cref="EventArgs"/> Obiekt przechowujący dane wydarzenia.</param>
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            if(Application["Syslog"] != null)
            {
                textarea.InnerHtml = "";
                List<Syslog> lista = new List<Syslog>((List<Syslog>)Application["Syslog"]);
                foreach (var item in lista)
                {
                    textarea.InnerHtml += item.Komunikat + "&#10;";
                    Page.DataBind();
                }
            }

        }
    }
}