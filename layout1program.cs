using System;
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
                Console.Clear();
                Console.WriteLine("Het Depot Boijmans Van Beuningen\n\n[1] Bezoeker\n[2] Gids");

                int invoergebruiker = Convert.ToInt32(Console.ReadLine());
                switch (invoergebruiker)
                {
                    case 1:
                        return 1; 
                    case 2:
                        return 2;
                    case 6:
                        Console.WriteLine("Closing the application. See you next time!");
                        return -1;
                    default:
                        Console.WriteLine("Invalid option. Please only enter the number of the option you would like to pick.\nPress 'Enter' to continue.");
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
                Console.WriteLine("Bezoeker");
                Console.WriteLine("[0] om terug te gaan naar het start menu ");

                int invoerbezoeker = Convert.ToInt32(Console.ReadLine());
                switch (invoerbezoeker)
                {
                    case 1:
                        break; 
                    case 0:
                        return 0; 

                    default:
                        Console.WriteLine("Invalid option. Please only enter the number of the option you would like to pick.\nPress 'Enter' to continue.");
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
                Console.WriteLine("gids menu\n[0] keer terug te keren naar het start menu");
                int invoergids = Convert.ToInt32(Console.ReadLine());

                switch (invoergids)
                {
                    case 1: break; 
                    case 0: return 0; 

                    default:
                        Console.WriteLine("Invalid option. Please only enter the number of the option you would like to pick.\nPress 'Enter' to continue.");
                        Console.ReadLine();
                        break;
                }

            }
        }

        static void LeegPagina()
        {
            Console.Clear();
        }
    }
}
