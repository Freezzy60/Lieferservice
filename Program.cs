using System;
using System.Collections.Generic;

namespace Lieferservice
{
    class Program
    {


        static void Main(string[] args)
        {
            List<Bestellung> bestellungen = new List<Bestellung>();
            List<Speise> speisen = new List<Speise>();
            List<Zutat> zutaten = new List<Zutat>();
            var menu = new Menu();

            zutaten.Add(new Zutat() { Name = "Tuna,", Menge = 1, Preis = 1, Extra = true });
            zutaten.Add(new Zutat() { Name = "Ham,", Menge = 1, Preis = 1, Extra = true });
            zutaten.Add(new Zutat() { Name = "Salami,", Menge = 1, Preis = 1, Extra = true });
            zutaten.Add(new Zutat() { Name = "Mushrooms,", Menge = 1, Preis = 1, Extra = true });
            zutaten.Add(new Zutat() { Name = "Onion,", Menge = 1, Preis = 1, Extra = true });
            zutaten.Add(new Zutat() { Name = "Chilipeppers", Menge = 1, Preis = 1, Extra = true });

            AuswahlAnzeigen();

            while (true)
            {
                int eingabe = int.Parse(Console.ReadLine());

                switch (eingabe)
                {
                    case 0:
                        Console.Clear();
                        AuswahlAnzeigen();
                        menu.MenuAnzeigen();
                        Console.WriteLine("==============================================================================");
                        break;
                    case 1:
                        Console.Clear();
                        Console.WriteLine("==========================");
                        menu.MenuAnzeigen();
                        Console.WriteLine("==========================");
                        Console.WriteLine("Choose your order:([0],[1],[2],[3},[4])");
                        speisen.Add(Bestellen(menu.Speisen, zutaten));
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("==========================");
                        Console.WriteLine($"Contents of the basket.:\n{WarenKorb.Inhalt} ");
                        Console.WriteLine($"Topping price EUR:{WarenKorb.ToppingPreis}");
                        Console.WriteLine($"Total price:{WarenKorb.GesamtPreis} Euro");
                        Console.WriteLine("==========================");
                        Console.WriteLine("[0]Menu, [1]Order, [2]Shopping cart, [3]Kassa, [4]Exit");
                        break;
                    case 3:
                        var x = LieferGebührAbfrage();
                        Console.Clear();
                        KassaBonAnzeigen(x);
                        Environment.Exit(1);
                        break;
                    case 4:
                        Environment.Exit(1);
                        return;
                    default:
                        break;
                }
            }

        }
        public static void KassaBonAnzeigen(double x)
        {
            Console.Clear();
            Console.WriteLine("\t*Pizza Pablo*");
            Console.WriteLine("\tKlostergasse 7");
            Console.WriteLine("\t6850 Dornbirn");
            Console.WriteLine("\t+43 5572 372316");
            Console.WriteLine("\tSt.Nr.: 079/211/08170");
            Console.WriteLine($"\t{DateTime.Now}");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine(Kassa.Inhalt);
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"Delivery charge EUR: {x}");
            Console.WriteLine("-----------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\tSumme EUR:{Kassa.SummePreis + x}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Thank you for your purchase!\n\tVisit us again.\n\t    Goodbye!");
        }

        public static void AuswahlAnzeigen()
        {
            Console.WriteLine($"\t     ++Welcome to Pizza Pablo!++");
            Console.WriteLine("\t  =================================");
            Console.WriteLine("[0]Menu, [1]Order, [2]Shopping cart, [3]Kassa, [4]Exit");
        }

        public static List<Zutat> ZutatAuswahl(List<Zutat> zutaten)
        {
            var resultat = new List<Zutat>();
            int anzahl = zutaten.Count;
            int position = 0;
            foreach (var zutat in zutaten)
            {
                Console.WriteLine($"{ position++} ...... {zutat.Name}+ {zutat.Preis}Euro");
            }

            Console.WriteLine("Choose your toppings: ...if no selection/continue press: F/f ");

            bool weiter = true;
            while (weiter)
            {

                var eingabe = Console.ReadLine();
                if (eingabe == "F" || eingabe == "f")
                {
                    weiter = false;
                    Console.WriteLine("[0]Menu, [1]Order, [2]Shopping cart, [3]Kassa, [4]Exit");
                    return resultat;
                }

                int auswahl = int.Parse(eingabe);

                position = 0;
                foreach (var zutat in zutaten)
                {
                    if (auswahl == position++)
                    {
                        resultat.Add(zutat);
                    }
                }
            }

            return resultat;
        }

        public static Speise Bestellen(List<Speise> speisen, List<Zutat> zutaten)
        {

            int pizzaAuswahl = int.Parse(Console.ReadLine());

           Speise speiseOriginal = speisen.ToArray()[pizzaAuswahl];

            Speise speise = new Speise(speiseOriginal.Name, speiseOriginal.Preis, speiseOriginal.Menge, new List<Zutat>());

            var zutatenAuswahl = ZutatAuswahl(zutaten);
            foreach (var item in zutatenAuswahl)
            {
                speise.Zutaten.Add(item);
            }

            WarenKorb.Inhalt = string.Concat(WarenKorb.Inhalt, speise.Name, $"*({speise.GetExtras()})\n");

            WarenKorb.GesamtPreis = WarenKorb.GesamtPreis + speise.Preis + speise.GetExtrasPreis();

            WarenKorb.ToppingPreis += speise.GetExtrasPreis();

            Kassa.Inhalt = string.Concat(Kassa.Inhalt, $"*{ speise.Name}\n\t**{speise.GetExtras()}\n");

            speise.Preis = speise.Preis + speise.GetExtrasPreis();

            Kassa.SummePreis = Kassa.SummePreis + speise.Preis;

            return speise;
        }

        public static double LieferGebührAbfrage()
        {
            double gebuer = 2.50;
            Console.WriteLine("Please specify place of delivery:");
            var ort = Console.ReadLine().ToLower();

            if ("dornbirn" != ort)
            {
                return gebuer;
            }
            return 0.0;
        }
    }
}
