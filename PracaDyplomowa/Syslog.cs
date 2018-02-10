using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracaDyplomowa
{
    /// <summary>
    /// Klasa reprezentująca pojedynczy komunikat odebrany z ASA.
    /// </summary>
    public class Syslog
    {
        /// <summary>
        /// Pobieranie, ustawianie Komunikatu.
        /// </summary>
        /// <value>
        /// Pełny komunikat odebrany z ASA.
        /// </value>
        public String Komunikat { get; set; }

        /// <summary>
        /// Pobieranie, ustawianie numeru komunikatu.
        /// </summary>
        /// <value>
        /// Atrybut przechowujący numer komunikatu.
        /// </value>
        public int NumerLogu { get; set; }
        /// <summary>
        /// Pobieranie, ustawianie wagi komunikatu.
        /// </summary>
        /// <value>
        /// Atrybut przechowujący wagę komunikatu.
        /// </value>
        public int Waga { get; set; }
        /// <summary>
        /// Pobieranie, ustawianie daty komunikatu.
        /// </summary>
        /// <value>
        /// Atrybut przechowujący datę wystawienia komunikatu.
        /// </value>
        public String Data { get; set; }

        /// <summary>
        /// Konstruktor komunikatu <see cref="Syslog"/>
        /// </summary>
        /// <param name="komunikat"> pełny komunikat z ASA.</param>
        public Syslog(string komunikat)
        {
            this.Komunikat = komunikat;
            string [] podzielone = komunikat.Split('%');
            //<166>Jan 14 2018 11:13:05: %ASA-6-725007: SSL session with client manage:10.0.0.1/51180 to 10.0.0.2/443 terminat
            try
            {
                NumerLogu = int.Parse(podzielone[1].Substring(podzielone[1].IndexOf('-') + 3, podzielone[1].IndexOf(':') - 6));
                Waga = int.Parse(podzielone[1].Substring(podzielone[1].IndexOf('-') + 1, 1));
                Data = podzielone[0].Substring(podzielone[0].IndexOf('>') + 1, podzielone[0].IndexOf(':') - podzielone[0].IndexOf('>') - 1 + 6);
            }
            catch (FormatException)
            {
                System.Diagnostics.Debug.WriteLine("Błąd podczas parsowania");
            }
        }
    }
}