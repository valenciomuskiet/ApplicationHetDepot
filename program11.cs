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
                switch (Pagina)
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

        private static int StartMenuDepot()
        {
            while(true)
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

        private static int BezoekerMenu()
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
                        Rondleidingen();

                        List<Reservering> AlleReserveringen = new List<Reservering>();

                        int num1 = Convert.ToInt32(Console.ReadLine());

                        LeegPagina();
                        Console.WriteLine("Door u geselecteerd : " + GetTijdvak(num1));
                        Console.WriteLine("\n\nvoer jouw unieke ticket code in; ");

                        int code = Convert.ToInt32(Console.ReadLine());
                        int returnvalue = (DelenDoor17(code));

                        var huidigelijst = File.ReadAllText(@"reservering.Json");
                        AlleReserveringen = JsonConvert.DeserializeObject<List<Reservering>>(huidigelijst);


                        if (returnvalue == 0)
                        {
                            AlleReserveringen.Add (new Reservering()
                            {
                                Code = code,
                                Tijd = GetTijdvak(num1),
                            });
                            string collectionResult = JsonConvert.SerializeObject(AlleReserveringen);


                            Console.WriteLine("klik random toets en enter om te saven");
                            Console.ReadLine();

                            File.WriteAllText(@"reservering.Json", collectionResult);
                            LeegPagina();
                            Console.WriteLine("Opgeslagen !, klik een toets en enter om terug te gaan");
                            Console.ReadLine();

                        }
                        else
                        {
                            Console.WriteLine("Niet Opgeslagen, klik een toets en enter om terug te gaan !");
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

        private static int GidsMenu()
        {
            while(true)
            {
                LeegPagina();
                Console.WriteLine("Gids\n\n[0] om terug te gaan naar het start menu\n[1] om een overzicht te zien van de reserveringen");
                string invoergids = Console.ReadLine();

                switch (invoergids)
                {
                    case "1":
                        LeegPagina();
                        string strReservering = String.Empty;
                        strReservering = File.ReadAllText(@"reservering.Json");
                        Reservering reservering = JsonConvert.DeserializeObject<Reservering>(strReservering);
                        Console.WriteLine("\n" + strReservering);
                        Console.ReadLine();

                        break; 
                    case "0": return 0; 

                    default:
                        Console.WriteLine("Invoer onjuist, selecteer een van bovenstaande opties a.u.b.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void LeegPagina()
        {
            Console.Clear();
        }

        static int DelenDoor17(int code)
        {
            int answer = code % 17;

            if (answer == 0)
            {
                return 0;
            }
            else
                return answer;
        }

        static string GetTijdvak(int tijdOptie)
        {
            string Tijdvak;

            switch (tijdOptie)
            {
                case 1:
                    Tijdvak = "11:00-11:20";
                    break;
                case 2:
                    Tijdvak = "12:00-12:20";
                    break;
                case 3:
                    Tijdvak = "13:00-13:20";
                    break;
                case 4:
                    Tijdvak = "14:00-14:20";
                    break;
                case 5:
                    Tijdvak = "15:00-15:20";
                    break;
                case 6:
                    Tijdvak = "16:00-16:20";
                    break;
                case 7:
                    Tijdvak = "17:00-17:20";
                    break;
                default:
                    Tijdvak = "onjuiste keuze";
                    break;
            }
            return Tijdvak;
        }

        static void Rondleidingen()
        {
            var dateNu = DateTime.Now;
            Console.WriteLine("Huidige datum: " + dateNu);
            Console.WriteLine("Plekken vrij voor vandaag:");
            Console.WriteLine("Rondleidingen:\n\n[1] 11:00 - 11:20\n[2] 12:00 - 12:20\n[3] 13:00 - 13:20\n[4] 14:00 - 14:20\n[5] 15:00 - 15:20\n[6] 16:00 - 16:20\n[7] 17:00 - 17:20\n");
            Console.Write("\n\nSelecteer (getal) de Rondleiding naar keuze: ");

        }
    }
}
