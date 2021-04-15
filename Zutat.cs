using System;
using System.Collections.Generic;
using System.Text;

namespace Lieferservice
{
    public class Zutat
    {
        /// <summary>
        /// Names der Zutats
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Die Menge der Zutats
        /// </summary>
        public double Menge { get; set; }

        public double Preis { get; set; }

        public bool Extra { get; set; }

        public Zutat()
        {           
            
        }

        public Zutat(string name, double menge,double preis, bool extra = false)
        {
            Name = name;
            Menge = menge;
            Preis = preis;
            Extra = extra;
        }
    }
}
