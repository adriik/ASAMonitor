using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracaDyplomowa
{
    /// <summary>
    /// Klasa wykorzystywana przy przekształceniu JSON-Object.
    /// Reprezentuje komendy wysyłane do ASA.
    /// </summary>
    public class Komenda
    {
        /// <summary>
        /// Metody pobierające i zwracające listę komend.
        /// </summary>
        /// <value>
        /// Lista komend.
        /// </value>
        public List<string> commands { get; set; }

        /// <summary>
        /// Konstruktor nowego obiektu <see cref="Komenda"/> class.
        /// </summary>
        public Komenda()
        {
            this.commands = new List<string>();
        }
    }
}