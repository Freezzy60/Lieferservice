using System;
using System.Collections.Generic;
using System.Text;

namespace Lieferservice
{
    public class Menu
    {
        /// <summary>
        /// Alles Speisen um Menu
        /// </summary>
        public List<Speise> Speisen { get; set; } = new List<Speise>();

        public Menu() 
        {

            var eineSpeise = new Speise();
            eineSpeise.Name = "Pizza Salami (Salami)";
            eineSpeise.Preis = 8.30;
            eineSpeise.Menge = 1;
            Speisen.Add(eineSpeise);
            

            var zweiteSpeise = new Speise();
            zweiteSpeise.Name = "Pizza Tonno (Tuna, Onion)";
            zweiteSpeise.Preis = 9.20;
            zweiteSpeise.Menge = 1;
            Speisen.Add(zweiteSpeise);
            

            var dritteSpeise = new Speise();
            dritteSpeise.Name = "Pizza Margherita";
            dritteSpeise.Preis = 7.20;
            dritteSpeise.Menge = 1;
            Speisen.Add(dritteSpeise);


            var vierteSpeise = new Speise();
            vierteSpeise.Name = "Pizza Calabrese (Salami, Mushrooms, Ham)";
            vierteSpeise.Preis = 8.90;
            vierteSpeise.Menge = 1;
            Speisen.Add(vierteSpeise);

            var fuenfteSpeise = new Speise();
            fuenfteSpeise.Name = "Pizza Prosciutto (Ham, Mushrooms)";
            fuenfteSpeise.Preis = 8.70;
            fuenfteSpeise.Menge = 1;
            Speisen.Add(fuenfteSpeise);

        }

        public void MenuAnzeigen()
        {
            int position = 0;
            foreach(var speise in Speisen)
            {
                Console.WriteLine($"{position++} ................... {speise.Name} {speise.Preis}Euro");
                
            }
        }
    }
}
