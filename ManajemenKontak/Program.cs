using System;

namespace ManajemenKontak;

class Program
{
    public static void Main(string[] args)
    {
                
    }

    public void MainMenu()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("==========================");
            Console.WriteLine("\t Menu Managemen Kontak \t");
            Console.WriteLine("==========================");
            Console.WriteLine("1. Manajemen Kontak");
            Console.WriteLine("2. Recycle bin kontak");
            Console.WriteLine("3. Exit");
            Console.Write("\nMasukkan Pilihan : ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("==========================");
                    Console.WriteLine("\t Managemen Kontak \t");
                    Console.WriteLine("==========================");
                    Console.WriteLine("1. View Kontak");
                    Console.WriteLine("2. Create kontak");
                    Console.WriteLine("3. Update Kontak");
                    Console.WriteLine("4. Delete Kontak");
                    Console.WriteLine("5. Search Kontak");

                    break;
            }
        }
    }
}
