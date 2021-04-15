using System;
using System.Collections.Generic;
using System.Text;

namespace Lieferservice
{
    /// <summary>
    /// Beschreibt eine Speise
    /// </summary>
    public class Speise
    {
        #region Public Parameters

        /// <summary>
        /// Der Name der Speise
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Der Preis der Speise
        /// </summary>
        public double Preis { get; set; }

        public int Menge { get; set; }

        /// <summary>
        /// Die Zutaten der Speisek
        /// </summary>
        public List<Zutat> Zutaten { get; set; } = new List<Zutat>();

        #endregion

        #region Constrctors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Speise() { }

        public Speise(string name, double preis,int menge, List<Zutat> zutaten)
        {
            Name = name;
            Preis = preis;
            Menge = menge;
            Zutaten = zutaten;
        }

        #endregion

        

        /// <summary>
        /// gibt die exrta zutaten zur speise dazu.
        /// </summary>
        /// <returns></returns>
        public string GetExtras()
        {
            string extras = default(string);

            Zutaten.ForEach(x =>
            {
                if (x.Extra == true)
                    extras += x.Name;
            });

            return extras;
        }

        public double GetExtrasPreis()
        {
            double extrasPreis = default(double);

            Zutaten.ForEach(x =>
            {
                if (x.Extra == true)
                    extrasPreis += x.Preis;
            });

            return extrasPreis;
        }

    }
}
