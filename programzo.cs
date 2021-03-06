using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace HetDepotApplication
{
    class Program
    {
        static void Main()
        {
            int Pagina = 0;
            while (Pagina != -1)
            {
                switch (Pagina)                                                 /// Switch statement voor de menu's
                {
                    case 0:
                        Pagina = StartMenuDepot();
                        break;
                    case 1:
                        Pagina = BezoekerMenu();
                        break;
                    case 2:
                        Pagina = GidsMenu();
                        break;
                }
            }
        }

        private static int StartMenuDepot()                                     /// Startmenu 
        {
            while (true)
            {
                LeegPagina();
                Console.WriteLine("Het Depot Boijmans Van Beuningen\n\n[1] Bezoeker\n[2] Gids");

                string invoergebruiker = Console.ReadLine();
                switch (invoergebruiker)
                {
                    case "1":
                        return 1;
                    case "2":
                        return 2;
                    default:
                        Console.WriteLine("Invoer onjuist, selecteer een van bovenstaande opties a.u.b.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        public static int BezoekerMenu()                                       /// bezoekersmenu
        {
            while (true)
            {
                LeegPagina();
                Console.WriteLine("Bezoeker\n\n[1] om een reservering te maken \n[0] om terug te gaan ");

                string invoerbezoeker = Console.ReadLine();
                switch (invoerbezoeker)
                {

                    case "0":
                        return 0;

                    case "1":
                        LeegPagina();

                        var dateNu = DateTime.Now;
                        Console.WriteLine("Huidige datum: " + dateNu + "\n");

                        //var bezoekerslimit = 13;
                        var bezoekerslimit11uur = 14; 
                        var bezoekerslimit12uur = 13;
                        var bezoekerslimit13uur = 13;
                        var bezoekerslimit14uur = 13;
                        var bezoekerslimit15uur = 13;
                        var bezoekerslimit16uur = 13;
                        var bezoekerslimit17uur = 13;

                        var Vandaag = DateTime.Today;
                        var reservering11uur = Vandaag.AddHours(11);
                        var reservering12uur = Vandaag.AddHours(12);
                        var reservering13uur = Vandaag.AddHours(13);
                        var reservering14uur = Vandaag.AddHours(14);
                        var reservering15uur = Vandaag.AddHours(15);
                        var reservering16uur = Vandaag.AddHours(16);
                        var reservering17uur = Vandaag.AddHours(17);


                        var huidigelijst = File.ReadAllText(@"reservering.Json");
                        var Reserveringenvoorcount = JsonConvert.DeserializeObject<List<Reservering>>(huidigelijst);

                        foreach (var Reservering in Reserveringenvoorcount)
                        {
                            if (Reservering.tijd == reservering11uur)
                            {
                                --bezoekerslimit11uur;
                            }
                            else if (Reservering.tijd == reservering12uur)
                            {
                                --bezoekerslimit12uur;
                            }
                            else if (Reservering.tijd == reservering13uur)
                            {
                                --bezoekerslimit13uur;
                            }
                            else if (Reservering.tijd == reservering14uur)
                            {
                                --bezoekerslimit14uur;
                            }
                            else if (Reservering.tijd == reservering15uur)
                            {
                                --bezoekerslimit15uur;
                            }
                            else if (Reservering.tijd == reservering16uur)
                            {
                                --bezoekerslimit16uur;
                            }
                            else if (Reservering.tijd == reservering17uur)
                            {
                                --bezoekerslimit17uur;
                            }
                        }
                        //Console.WriteLine("plekken vrij voor vandaag: " + (13 - Reserveringenvoorcount.Count));
                        Console.WriteLine("[1] Rondleiding van 11:00" + " || plekken vrij: " + bezoekerslimit11uur);
                        Console.WriteLine("[2] Rondleiding van 12:00" + " || plekken vrij: " + bezoekerslimit12uur);
                        Console.WriteLine("[3] Rondleiding van 13:00" + " || plekken vrij: " + bezoekerslimit13uur);
                        Console.WriteLine("[4] Rondleiding van 14:00" + " || plekken vrij: " + bezoekerslimit14uur);
                        Console.WriteLine("[5] Rondleiding van 15:00" + " || plekken vrij: " + bezoekerslimit15uur);
                        Console.WriteLine("[6] Rondleiding van 16:00" + " || plekken vrij: " + bezoekerslimit16uur);
                        Console.WriteLine("[7] Rondleiding van 17:00" + " || plekken vrij: " + bezoekerslimit17uur);

                        List<Reservering> LijstVanReserveringen = new List<Reservering>();

                        Console.Write("\n\nSelecteer (getal) de Rondleiding naar keuze: ");
                        int num1 = Convert.ToInt32(Console.ReadLine());

                        LeegPagina();
                        Console.WriteLine("Door u geselecteerd : " + GeselecteerdeTijd(num1));
                        Console.WriteLine("\nVoer uw unieke ticket code in: ");

                        int Acode = Convert.ToInt32(Console.ReadLine());
                        int returnvalue = (CodeControle(Acode));

                        // annuleer 
                        var LijstReserveringenJson = File.ReadAllText(@"reservering.Json");
                        LijstVanReserveringen = JsonConvert.DeserializeObject<List<Reservering>>(LijstReserveringenJson);


                        if (returnvalue == 0)
                        {
                            Reservering reserveringmuseum = (new Reservering(Acode, GeselecteerdeTijd(num1)));
                            LijstVanReserveringen.Add(reserveringmuseum);

                            string NieuweLijstVanReserveringen = JsonConvert.SerializeObject(LijstVanReserveringen);
                            File.WriteAllText(@"reservering.Json", NieuweLijstVanReserveringen);
                            LeegPagina();

                            Console.WriteLine("Opgeslagen, toets [Enter] om terug te gaan.");
                            Console.ReadLine();

                        }
                        else
                        {
                            Console.WriteLine("Code onjuist, toets [Enter] om terug te gaan !");
                            Console.ReadLine();
                        }
                        break;

                    default:
                        Console.WriteLine("Invoer onjuist, selecteer een van bovenstaande opties a.u.b.");
                        Console.ReadLine();
                        break;

                }
            }
        }

        private static int GidsMenu()                                           /// Gidsmenu 
        {
            while (true)
            {
                LeegPagina();
                Console.WriteLine("Gids\n\n[0] om terug te gaan naar het start menu\n[1] start rondleiding 11 uur\n[2] start rondleiding 12 uur\n[3] start rondleiding 13 uur\n[4] start rondleiding 14 uur\n[5] start rondleiding 15 uur\n[6] start rondleiding 16 uur \n[7] start rondleiding 17 uur\n[10] overzicht van alle gemaakte reserveringen ");
                string invoergids = Console.ReadLine();


                var tijdinvul= Convert.ToInt32(Console.ReadLine());

                var Vandaag = DateTime.Today;
                var reservering11uur = Vandaag.AddHours(11);
                var reservering12uur = Vandaag.AddHours(12);
                var reservering13uur = Vandaag.AddHours(13);
                var reservering14uur = Vandaag.AddHours(14);
                var reservering15uur = Vandaag.AddHours(15);
                var reservering16uur = Vandaag.AddHours(16);
                var reservering17uur = Vandaag.AddHours(17);

                //string stringjson1 = File.ReadAllText(@"reservering.Json");
                //var LijstVanReserveringen1 = JsonConvert.DeserializeObject<List<Reservering>>(stringjson1);
                switch (invoergids)
                {
                    case "1":
                        codesgids(11);
                        break;

                    case "2":
                        codesgids(12);

                        break;
                    case "3":
                        codesgids(13);

                        break;

                    case "4":
                        codesgids(14);
                        break;

                    case "5":
                        codesgids(15);

                        break;

                    case "6":
                        codesgids(16);

                        break;

                    case "7":
                        codesgids(17);
                        break;

                    case "10":
                        LeegPagina();
                        Console.WriteLine("Lijst van alle reserveringen");

                        string stringjson2 = File.ReadAllText(@"reservering.Json");
                        var LijstVanReserveringen2 = JsonConvert.DeserializeObject<List<Reservering>>(stringjson2);

                        foreach(var Reservering in LijstVanReserveringen2)
                        {
                            Console.WriteLine(Reservering.code);
                            Console.WriteLine(Reservering.tijd);
                            Console.WriteLine("--------------");
                        }
                    
                        Console.WriteLine("[0] om terug te gaan");
                        Console.ReadLine();

                        break;
                    case "0":
                        return 0;
                    default:
                        Console.WriteLine("Invoer onjuist, selecteer een van bovenstaande opties a.u.b.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void codesgids(int time )
        {
            var Vandaag = DateTime.Today;
            var tijdinvul = Convert.ToInt32(Console.ReadLine());

            var reservering11uur = Vandaag.AddHours(time);

            string stringjson1 = File.ReadAllText(@"reservering.Json");
            var LijstVanReserveringen1 = JsonConvert.DeserializeObject<List<Reservering>>(stringjson1);  // uitgelezen

            Console.Clear();
            Console.WriteLine("Rondleiding "+ Vandaag.AddHours(time) + " uur\nvul jouw code in");
            int aCode = Convert.ToInt32(Console.ReadLine());

            int indexcode = LijstVanReserveringen1.FindIndex(Reservering => Reservering.code == aCode);
            int indextijd = LijstVanReserveringen1.FindIndex(Reservering => Reservering.tijd == reservering11uur);

            if (indexcode >= 0)
            {
                var yeahtijd = LijstVanReserveringen1[indexcode].tijd;
                if (yeahtijd == reservering11uur)
                {
                    Console.WriteLine("Je mag een labjas");
                }
                else
                {
                    Console.WriteLine("je mag geen labjas, je hebt gereserveerd voor een ander tijdvak");
                }
            }

            if (indexcode < 0)
            {
                Console.WriteLine("je mag geen labjas, code ongeldig");
            }
            Console.ReadLine();

        }

        static void LeegPagina()                                                /// static method voor pagina legen
        {
            Console.Clear();
        }

        static int CodeControle(int code)
        {
            int answer = code % 17;

            if (answer == 0)
            {
                return 0;
            }
            else
                return answer;
        }

        static DateTime GeselecteerdeTijd(int tijdOptie)                        /// static method voor de juiste geselecteerde tijd ophalen
        {
            DateTime Tijdvak;

            var Vandaag = DateTime.Today;
            var reservering11uur = Vandaag.AddHours(11);
            var reservering12uur = Vandaag.AddHours(12);
            var reservering13uur = Vandaag.AddHours(13);
            var reservering14uur = Vandaag.AddHours(14);
            var reservering15uur = Vandaag.AddHours(15);
            var reservering16uur = Vandaag.AddHours(16);
            var reservering17uur = Vandaag.AddHours(17);

            switch (tijdOptie)
            {
                case 1:
                    Tijdvak = reservering11uur;
                    break;
                case 2:
                    Tijdvak = reservering12uur;
                    break;
                case 3:
                    Tijdvak = reservering13uur;
                    break;
                case 4:
                    Tijdvak = reservering14uur;
                    break;
                case 5:
                    Tijdvak = reservering15uur;
                    break;
                case 6:
                    Tijdvak = reservering16uur;
                    break;
                case 7:
                    Tijdvak = reservering17uur;
                    break;
                default:
                    Tijdvak = Vandaag;
                    break;
            }
            return Tijdvak;
        }


        public static void WeergaveRondleidingen()                                     /// static methode voor het ophalen van de rondleidingen
        {
            var dateNu = DateTime.Now;
            Console.WriteLine("Huidige datum: " + dateNu);

            var huidigelijst = File.ReadAllText(@"reservering.Json");
            var Reserveringenvoorcount = JsonConvert.DeserializeObject<List<Reservering>>(huidigelijst);

            //var bezoekerslimit = 13;
            var bezoekerslimit11uur = 13;
            var bezoekerslimit12uur = 13;
            var bezoekerslimit13uur = 13;
            var bezoekerslimit14uur = 13;
            var bezoekerslimit15uur = 13;
            var bezoekerslimit16uur = 13;
            var bezoekerslimit17uur = 13;

            var Vandaag = DateTime.Today;
            var reservering11uur = Vandaag.AddHours(11);
            var reservering12uur = Vandaag.AddHours(12);
            var reservering13uur = Vandaag.AddHours(13);
            var reservering14uur = Vandaag.AddHours(14);
            var reservering15uur = Vandaag.AddHours(15);
            var reservering16uur = Vandaag.AddHours(16);
            var reservering17uur = Vandaag.AddHours(17);

           
            foreach (var Reservering in Reserveringenvoorcount)
            {
                if ( Reservering.tijd == reservering11uur )
                {
                    --bezoekerslimit11uur;
                }
                else if (Reservering.tijd == reservering12uur)
                {
                    --bezoekerslimit12uur;
                }
                else if (Reservering.tijd == reservering13uur)
                {
                    --bezoekerslimit13uur;
                }
                else if (Reservering.tijd == reservering14uur)
                {
                    --bezoekerslimit14uur;
                }
                else if (Reservering.tijd == reservering15uur)
                {
                    --bezoekerslimit15uur;
                }

                else if (Reservering.tijd == reservering16uur)
                {
                    --bezoekerslimit16uur;
                }
                else if (Reservering.tijd == reservering17uur)
                {
                    --bezoekerslimit17uur;
                }
            }
            //Console.WriteLine("plekken vrij voor vandaag: " + (13 - Reserveringenvoorcount.Count));
            Console.WriteLine("[1] 11:00 - 11:20" + "|| plekken vrij: " + bezoekerslimit11uur);
            Console.WriteLine("[2] 12:00 - 12:20" + "|| plekken vrij: " + bezoekerslimit12uur);
            Console.WriteLine("[3] 13:00 - 12:20" + "|| plekken vrij: " + bezoekerslimit13uur);
            Console.WriteLine("[4] 14:00 - 11:20" + "|| plekken vrij: " + bezoekerslimit14uur);
            Console.WriteLine("[5] 15:00 - 12:20" + "|| plekken vrij: " + bezoekerslimit15uur);
            Console.WriteLine("[6] 16:00 - 12:20" + "||plekken vrij: " + bezoekerslimit16uur);
            Console.WriteLine("[7] 17:00 - 12:20" + "||plekken vrij: " + bezoekerslimit17uur);
        }
    }
}
