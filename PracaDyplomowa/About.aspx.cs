using System;
using System.Web.UI.WebControls;

namespace PracaDyplomowa
{
    /// <summary>
    /// Klasa reprezentująca back-end ekranu informacji o aplikacji
    /// </summary>
    /// <seealso cref="System.Web.UI.Page" />
    public partial class About : System.Web.UI.Page
    {
        /// <summary>
        /// Metoda wykonywana tuż przed renderowaniem strony.
        /// </summary>
        /// <param name="sender">Źródło wydarzenia.</param>
        /// <param name="e">The <see cref="EventArgs"/> Obiekt przechowujący dane wydarzenia.</param>
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (Session["client"] != null)
            {
                ((Button)Master.FindControl("wylogowanie")).Visible = true;
            }
            else
            {
                ((Button)Master.FindControl("zaloguj")).Visible = true;
            }
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}