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

        manageContact.CreateContact("Rizki", "0811234567", "rizki@gmail.com");
        manageContact.CreateContact("Atoi", "0812345172", "Atoi@gmail.com");
        manageContact.CreateContact("ria", "0811236789", "ria@gmail.com");

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
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("==========================");
                        Console.WriteLine("   MANAGEMENT CONTACT");
                        Console.WriteLine("==========================");
                        Console.WriteLine("1. View Kontak");
                        Console.WriteLine("2. Create kontak");
                        Console.WriteLine("3. Search Kontak");
                        Console.WriteLine("4. Back");
                        Console.Write("Input : ");
                        string choice = Console.ReadLine();

                        switch (choice)
                        {
                            case "1":
                                Console.Clear();
                                Console.WriteLine("------------- View Kontak -------------");
                                manageContact.ViewContacts();
                                Console.WriteLine("---------------------------------------");
                                Console.WriteLine("1. Edit Kontak");
                                Console.WriteLine("2. Delete Kontak");
                                Console.WriteLine("3. Back Kontak");
                                Console.Write("Pilih : ");
                                string choiceCrud = Console.ReadLine();

                                switch (choiceCrud)
                                {
                                    case "1":
                                        Console.WriteLine("------------- Edit Kontak -------------");
                                        Console.Write("Masukkan email yang ingin di edit : ");
                                        string mail = Console.ReadLine();
                                        Contact searchMail = manageContact.FindUserEmail(mail);

                                        if (searchMail != null)
                                        {
                                            Console.Write("Masukkan Nama Baru : ");
                                            string newName = Console.ReadLine();
                                            Console.Write("Masukkan Phone Number Baru : ");
                                            string newNumber = Console.ReadLine();
                                            Console.Write("Masukkan Email Baru : ");
                                            string newEmail = Console.ReadLine();

                                            manageContact.EditContact(newName, newNumber, newEmail, mail);
                                            Console.Write("press enter if you want to go back ! ");
                                        }
                                        else
                                        {
                                            Console.WriteLine($"\n{mail} Not found. Please try again!");
                                            Console.Write("press enter if you want to go back ! ");
                                        }
                                        Console.ReadLine();
                                        continue;

                                    case "2": // Delete Kontak
                                        Console.WriteLine("------------- Delete Kontak -------------");
                                        Console.Write("Masukkan email yang ingin dihapus : ");
                                        string emailToDelete = Console.ReadLine();
                                        Contact contactToDelete = manageContact.FindUserEmail(emailToDelete);

                                        if (contactToDelete != null)
                                        {
                                            manageContact.DeleteContact(contactToDelete);
                                            Console.Write("press enter if you want to go back ! ");
                                            Console.ReadLine();
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nContact not found.");
                                            Console.Write("press enter if you want to go back ! ");
                                            Console.ReadLine();
                                        }
                                        continue;
                                    case "3":
                                        break;
                                }
                                continue;

                            case "2":
                                Console.Clear();
                                Console.WriteLine("------------- Create Kontak -------------");
                                Console.WriteLine("No Hp minimal 8 angka example 0811234567 ");
                                Console.Write("Masukkan Nama : ");
                                string nameContact = Console.ReadLine();
                                Console.Write("Masukkan Phone Number : ");
                                string numberPhone = Console.ReadLine();
                                Console.Write("Masukkan Email : ");
                                string email = Console.ReadLine();
                                manageContact.CreateContact(nameContact, numberPhone, email);
                                Console.ReadLine();
                                continue;

                            case "3":
                                Console.Clear();
                                Console.WriteLine("------------ Search Kontak ------------");
                                Console.Write("Masukkan nama yang dicari : ");
                                string search = Console.ReadLine();
                                manageContact.FindAllUser(search);
                                Console.Write("\npress enter if you want to go back ! ");
                                Console.ReadLine();
                                continue;

                            case "4":
                                break;
                        }
                        break;
                    }
                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("------------ RECYCLE BIN CONTACT ------------");
                    manageContact.ShowDeletedContacts();
                    Console.Write("press enter if you want to go back ! ");
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
