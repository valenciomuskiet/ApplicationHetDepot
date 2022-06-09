using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace sprint2testingthings
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
            while (true)
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
                Console.WriteLine("[0] om terug te gaan naar het start menu [7] reserveren");

                int invoerbezoeker = Convert.ToInt32(Console.ReadLine());
                switch (invoerbezoeker)
                {
                    case 1:
                        break;
                    case 0:
                        return 0;
                    case 7:
                        LeegPagina();

                        var dag1 = DateTime.Today; // ToString("dddd, dd MMMM yyyy")
                        var dag2 = dag1.AddDays(1);
                        var dag3 = dag1.AddDays(2);
                        var dag4 = dag1.AddDays(3);
                        var dag5 = dag1.AddDays(4);
                        var dag6 = dag1.AddDays(5);
                        var dag7 = dag1.AddDays(6);

                        Console.WriteLine("Huidige datum: " + dag1);
                        Console.WriteLine("Plekken vrij: volgende week bescikbaar");

                        var today = DateTime.Now;
                        Console.WriteLine("[1] " + dag1.ToString("dddd, dd MMMM yyyy"));
                        Console.WriteLine("[2] " + dag2.ToString("dddd, dd MMMM yyyy"));
                        Console.WriteLine("[3] " + dag3.ToString("dddd, dd MMMM yyyy"));
                        Console.WriteLine("[4] " + dag4.ToString("dddd, dd MMMM yyyy"));
                        Console.WriteLine("[5] " + dag5.ToString("dddd, dd MMMM yyyy"));
                        Console.WriteLine("[6] " + dag6.ToString("dddd, dd MMMM yyyy"));
                        Console.WriteLine("[7] " + dag7.ToString("dddd, dd MMMM yyyy"));


                        Console.Write("\n\nSelecteer (getal) de Rondleiding naar keuze: ");



                        int rondleidingnummer = Convert.ToInt32(Console.ReadLine());

                        switch (rondleidingnummer)
                        {












                        }



                        Console.WriteLine("Huidige datum : " + DateTime.Now + "\n" + "Door u geselecteerd : " + Tijdvak(rondleidingnummer));

                        List<Contact> myContacts = new List<Contact>();

                        Console.WriteLine("enter a name");
                        string aName = Console.ReadLine();
                        Console.WriteLine("enter a phonenumber");
                        int aPhoneNumber = Convert.ToInt32(Console.ReadLine());
                   
                        Console.WriteLine(aName  + aPhoneNumber + rondleidingnummer);
                        Console.WriteLine("press key+enter to save");
                        Console.ReadLine();

                        var huidigelijst = File.ReadAllText(@"Contacts.Json");
                        myContacts = JsonConvert.DeserializeObject<List<Contact>>(huidigelijst);
                        Console.ReadLine();

                        myContacts.Add(new Contact
                        {
                            Name = aName,
                            PhoneNumber = aPhoneNumber,
                            Tijd = Tijdvak(rondleidingnummer),
                        });
                        Console.WriteLine("saved");

                        foreach (var contact in myContacts)
                        {
                            Console.WriteLine(contact.Name);
                            Console.WriteLine(contact.PhoneNumber);
                            Console.WriteLine(contact.Tijd);
                            Console.WriteLine("-----------------------------");
                        }


                        string collectionResult = JsonConvert.SerializeObject(myContacts);
                        Console.WriteLine(collectionResult);
                        Console.WriteLine("klik random toets en enter om te storen");
                        Console.ReadLine();
                        File.WriteAllText(@"Contacts.Json", collectionResult);
                        Console.WriteLine("Stored!");

                        Console.WriteLine("Random toets en enter om door te gaan naar een net overzicht van de res");
                        Console.ReadLine();

                        string huidigelijst2 = File.ReadAllText(@"Contacts.Json");
                        var huidigelijst2normaal = JsonConvert.DeserializeObject<List<Contact>>(huidigelijst);
                        Console.WriteLine(huidigelijst2normaal);

                        Console.ReadLine();

                        break;

                    default:
                        Console.WriteLine("Invalid option. Please only enter the number of the option you would like to pick.\nPress 'Enter' to continue.");
                        Console.ReadLine();
                        break;
                }
            }

        }

        private static int GidsMenu()
        {
            while (true)
            {
                LeegPagina();
                Console.WriteLine("gids menu\n[0] keer terug te keren naar het start menu, try7");
                int invoergids = Convert.ToInt32(Console.ReadLine());

                switch (invoergids)
                {
                    case 1:
                        break;
                    case 7:

                        var huidigelijst = File.ReadAllText(@"Contacts.Json");
                        List<Contact> myContacts = new List<Contact>();
                        myContacts = JsonConvert.DeserializeObject<List<Contact>>(huidigelijst);

                        foreach (var contact in myContacts)
                        {
                            Console.WriteLine(contact.Name);
                            Console.WriteLine(contact.PhoneNumber);
                            Console.WriteLine(contact.Tijd);
                            Console.WriteLine("-----------------------------");
                        }


                        Console.ReadLine();

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

        static void LeegPagina()
        {
            Console.Clear();
        }



        static string Tijdvak(int rondleidingnummer)
        {
            string Tijdvak;

            string datenow = DateTime.Now.ToString("dddd, dd MMMM yyyy");
                //Convert.ToString(DateTime.Now);










            switch (rondleidingnummer)
            {

               

                case 1:
                    Tijdvak = datenow;
                    break;
                case 2:
                    Tijdvak = "12:00-13:00";
                    break;
                case 3:
                    Tijdvak = "13:00-14:00";
                    break;
                case 4:
                    Tijdvak = "14:00-15:00";
                    break;
                case 5:
                    Tijdvak = "15:00-16:00";
                    break;
                case 6:
                    Tijdvak = "16:00-17:00";
                    break;
                default:
                    Tijdvak = "onjuiste keuze";
                    break;
            }
            return Tijdvak;
        }







    }
}
/*
myContacts.Add(new Contact
{
Name = "bart",
PhoneNumber = 12345678,
Age = 88
});

myContacts.Add(new Contact
{
Name = "Jim",
PhoneNumber = 1235555,
Age = 88
});

myContacts.Add(new Contact
{
Name = "Yoshi",
PhoneNumber = 1235555,
Age = 88
});
*/
