using System;

namespace ManajemenKontak;

class Program
{
    public static void Main(string[] args)
    {
        MainMenu();         
    }

    public static void MainMenu()
    {
        ManageContact manageContact = new ManageContact();
        Contact cont = new Contact();

        manageContact.CreateContact("Rizki", "081-2524445", "rizki@gmail.com");
        manageContact.CreateContact("Atoi", "081-2345172", "Atoi@gmail.com");
        manageContact.CreateContact("ria", "081-1236789", "ria@gmail.com");

        while (true)
        {
            Console.Clear();

            Console.WriteLine("==========================================");
            Console.WriteLine("\t Menu Management Contact \t");
            Console.WriteLine("==========================================");
            Console.WriteLine("1. Management Contact");
            Console.WriteLine("2. Recycle bin kontak");
            Console.WriteLine("3. Exit");
            Console.Write("\nMasukkan Pilihan : ");
            string choiceMain = Console.ReadLine();

            switch (choiceMain)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("==========================");
                    Console.WriteLine("\t MANAGEMENT CONTACT \t");
                    Console.WriteLine("==========================");
                    Console.WriteLine("1. View Kontak");
                    Console.WriteLine("2. Create kontak");
                    Console.WriteLine("3. Search Kontak");
                    Console.WriteLine("4. Exit");
                    Console.Write("Input : ");
                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            Console.Clear();
                            Console.WriteLine("----- View Kontak -----");
                            manageContact.ViewContacts();

                            Console.WriteLine("--------------------------");

                            Console.WriteLine("1. Edit Kontak");
                            Console.WriteLine("2. Delete Kontak");
                            Console.WriteLine("3. Back Kontak");
                            string choiceCrud = Console.ReadLine();
                            
                            Console.ReadLine();
                            switch (choiceCrud)
                            {
                                case "1":
                                    Console.WriteLine("------- Edit Kontak -------");
                                    Console.Write("Masukkan Email : ");
                                    Console.ReadLine();


                                    break;
                                case "2":
                                    Console.WriteLine("------- Delete Kontak -------");
                                    break;
                                case "3":
                                    break;

                            }
                            break;
                        case "2":
                            Console.Clear();
                            Console.WriteLine("----- Create Kontak -----");

                            Console.Write("Masukkan Nama : ");
                            string nameContact = Console.ReadLine();
                            Console.Write("Masukkan Phone Number : ");
                            string numberPhone = Console.ReadLine();
                            Console.Write("Masukkan Email : ");
                            string email = Console.ReadLine();

                            manageContact.CreateContact(nameContact, numberPhone, email);

                            Console.ReadLine();
                            break;
                        case "3":
                            Console.Clear();
                            Console.WriteLine("----- Search Kontak -----");
                            Console.ReadLine();
                            break;
                        case "4":
                            break;
                    }

                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("RECYCLE BIN CONTACT");
                    Console.ReadLine();
                    break;
                case "3":
                Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Enter options correctly");
                    Console.ReadLine();
                    break;

            }
        }
    }
}
