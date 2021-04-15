using System;
using System.Collections.Generic;
using System.Text;

namespace Lieferservice
{
    /// <summary>
    /// beschreibt eine Bestellung
    /// </summary>
    public class Bestellung
    {
        public List<Speise> Speisen { get; set; }

        public double Preis { get; set; }

        public Bestellung() { }

        public void BestellungAnzeigen()
        {
            int position = 0;
            foreach (var speise in Speisen)
            {
                Console.WriteLine($"{position++} ................... {speise.Name} [{speise.Preis}]");
            }
        }
    }
}
