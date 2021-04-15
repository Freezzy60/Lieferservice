using System;
using System.Collections.Generic;
using System.Text;

namespace Lieferservice
{
    public static class WarenKorb
    {
        public static List<Bestellung> Bestellungen = new List<Bestellung>();

        public static string Inhalt { get; set; }

        public static double ToppingPreis { get; set; }

        public static double GesamtPreis { get; set; }

        
    }
}
