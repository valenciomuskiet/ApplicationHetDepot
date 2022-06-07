using System;
using System.IO;
using Newtonsoft.Json;

namespace HetDepotApplication
{
    class Program
    {
        static void Main(string[] args)
        {
           
       
            Console.Write("Het Depot\nTyp 'bezoeker' of 'gids' om verder te gaan: ");
            string gebruiker = Console.ReadLine();


            if (gebruiker == "bezoeker")
            {
                LeegPagina();
                var dateNu = DateTime.Now;
                Console.WriteLine("Huidige datum: " + dateNu);
                Console.WriteLine("Plekken vrij: volgende week bescikbaar");
                Console.WriteLine("Rondleidingen:\n\n[0] 11:00 - 11:20\n[1] 11:20 - 11:40\n[2] 11:40 - 12:00\n[3] 12:00 - 12:20\n[4] 12:20 - 12:40\n[5] 12:40 - 13:00\n[6] 13:00 - 13:20\n[7] 13:20 - 13:40\n[8] 13:40 - 14:00\n[9] 14:00 - 14:20\n[10] 14:20 - 14:40\n[11] 14:40 - 15:00\n[12] 15:00 - 15:20\n[13] 15:20 - 15:40\n[14] 15:40 - 16:00\n[15] 16:00 - 16:20\n[16] 16:20 - 16:40\n[17] 16:40 - 17:00\n[18] 17:00 - 17:20");
                Console.Write("\n\nSelecteer (getal) de Rondleiding naar keuze: ");



                int num1 = Convert.ToInt32(Console.ReadLine());

                LeegPagina();
                Console.WriteLine("Huidige datum: " + dateNu);
                Console.WriteLine("Door u geselecteerd : " + GetTijdvak(num1));
                Console.WriteLine("\n\nvoer jouw unieke ticket code in; ");

                int code = Convert.ToInt32(Console.ReadLine());
                int returnvalue = (DelenDoor17(code));


                if (returnvalue == 0)
                {
                    Reservering reservering1 = new Reservering()
                    {
                        Code = code,
                        Tijd = GetTijdvak(num1),
                    };

                    string strReservering1 = JsonConvert.SerializeObject(reservering1);
                    Console.WriteLine(strReservering1);
                    File.WriteAllText(@"reservering1.Json", strReservering1);
                    LeegPagina();
                    Console.WriteLine("Opgeslagen !");
                }
                else
                {

                }

            }
            else if (gebruiker == "gids")
            {
                LeegPagina();
                Console.WriteLine("Deze optie is per volgende week beschikbaar !");
            }

            else
            {
                LeegPagina();
                Console.Clear();
                Console.WriteLine("Input niet valid, probeer het opnieuw");
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
                    case 0:
                        Tijdvak = "11:00-11:20";
                        break;
                    case 1:
                        Tijdvak = "11:20-11:40";
                        break;
                    case 2:
                        Tijdvak = "11:40-12:00";
                        break;
                    case 3:
                        Tijdvak = "12:00-12:20";
                        break;
                    case 4:
                        Tijdvak = "12:20-12:40";
                        break;
                    case 5:
                        Tijdvak = "12:40-13:00";
                        break;
                    case 6:
                        Tijdvak = "13:00-13:20";
                        break;
                    case 7:
                        Tijdvak = "13:20-13:40";
                        break;
                    case 8:
                        Tijdvak = "13:40-14:00";
                        break;
                    case 9:
                        Tijdvak = "14:00-14:20";
                        break;
                    case 10:
                        Tijdvak = "14:20-14:40";
                        break;
                    case 11:
                        Tijdvak = "14:40-15:00";
                        break;
                    case 12:
                        Tijdvak = "15:00-15:20";
                        break;
                    case 13:
                        Tijdvak = "15:20-15:40";
                        break;
                    case 14:
                        Tijdvak = "15:40-16:00";
                        break;
                    case 15:
                        Tijdvak = "16:00-16:20";
                        break;
                    case 16:
                        Tijdvak = "16:20-16:40";
                        break;
                    case 17:
                        Tijdvak = "16:40-17:00";
                        break;
                    case 18:
                        Tijdvak = "17:00-17:20";
                        break;

                    default:
                        Tijdvak = "onjuiste keuze";
                        break;
                }
                return Tijdvak;

            }
        }
    }
}

