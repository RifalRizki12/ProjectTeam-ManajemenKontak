using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ManajemenKontak
{
    public class ManageContact
    {
        private List<Contact> contacts = new List<Contact>();

        public void ViewContacts()
        {
            Console.WriteLine("==========================");
            Console.WriteLine("     Daftar Contact");
            Console.WriteLine("==========================\n");
            foreach (var contact in contacts)
            {
                Console.WriteLine(contact);
            }
        }

        public void CreateContact(string name, string phoneNumber, string emailAddress)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(phoneNumber) || string.IsNullOrWhiteSpace(emailAddress))
            {
                Console.WriteLine("\nInput tidak valid. Pastikan semua kolom diisi !\n");
                return; // Jika input tidak valid, keluar dari metode.
            }

            Contact newContact = new Contact(name, phoneNumber, emailAddress);
            contacts.Add(newContact);
            Console.WriteLine("Contact created successfully.");
            Console.WriteLine("--------------------");
        }

        public void DataDummy(string name, string phoneNumber, string emailAddress) //pembuatan data dummy
        {
            Contact newContact = new Contact(name, phoneNumber, emailAddress);

            contacts.Add(newContact);
        }

        public void FindUser(string find)
        {
            // Mencari pengguna yang cocok berdasarkan nama yang mengandung kata kunci
            var searchContact = contacts.Where(u => Regex.IsMatch(u.Name, find, RegexOptions.IgnoreCase) ||
                                              Regex.IsMatch(u.PhoneNumber, find, RegexOptions.IgnoreCase) ||
                                              Regex.IsMatch(u.EmailAddress, find, RegexOptions.IgnoreCase)).ToList();

            if (searchContact.Count == 0)
            {
                Console.WriteLine("Tidak ada contact yang cocok dengan kata kunci yang diberikan !");
            }
            else
            {
                Console.WriteLine("--------------------------");
                foreach (var item in searchContact)
                {
                    Console.WriteLine($"\nNama : {item.Name}");
                    Console.WriteLine($"Phone Number : {item.PhoneNumber}");
                    Console.WriteLine($"Email Address : {item.EmailAddress}");
                }
            }
        }

        public void DeleteContact(string name)
        {

            List<Contact> contactsToDelete = contacts.FindAll(contact => contact.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            List<Contact> toDelete = new List<Contact>;
            
            
            string remItem;
            if (contactsToDelete.Count == 0)
            {
                Console.WriteLine("Contact not found.");
            }
            else if (contactsToDelete.Count == 1)
            {
                var cekDelete1 = contacts.FirstOrDefault(u => u.Name == name && u.PhoneNumber == numberPhone);
                if (contacts.Contains(cekDelete1))
                {
                    toDelete.Add(cekDelete1);
                    contacts.Remove(cekDelete1);
                }
                contacts.Remove(contactsToDelete[0]);
                Console.WriteLine("Contact deleted successfully.");
            }
              
            else
            {
                Console.WriteLine("Multiple contacts dengan nama yang sama. mohon inputan lebih spesifik untuk menghapus :");
                for (int i = 0; i < contactsToDelete.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {contactsToDelete[i]}");
                }

                Console.Write("Masukkan nomor contact yang ingin dihapus : ");
                if (int.TryParse(Console.ReadLine(), out int selectedIndex) && selectedIndex > 0 && selectedIndex <= contactsToDelete.Count)
                {
                    var cekDelete2 = contacts.FirstOrDefault(u => u.Name == name && u.PhoneNumber == numberPhone);
                    if (contacts.Contains(cekDelete2))
                    {
                        remItem = cekDelete2;
                        contacts.Remove(cekDelete2);
                    }
                    contacts.Remove(contactsToDelete[selectedIndex - 1]);
                    Console.WriteLine("Contact berhasil menghapus !");
                }
                else
                {
                    Console.WriteLine("Invalid . No contact deleted.");
                }
            
            
            
            }

            



        }


        /*public void deleteContact(int email)
        {
            Contact contactToDelete = contacts.Find(contact => contact.EmailAddress.Equals(email, StringComparison.OrdinalIgnoreCase));
            if (userDelete != null)
            {
                contacts.Remove(userDelete);
                Console.WriteLine($"Contact dengan id {id} berhasil dihapus ! \n");
            }
            else
            {
                Console.WriteLine($"Data dengan id {id} tidak ada !");
            }
        }*/
    }
}
