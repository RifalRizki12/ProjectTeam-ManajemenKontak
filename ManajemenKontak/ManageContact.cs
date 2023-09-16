using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        private Stack<Contact> deletedContacts = new Stack<Contact>(); //menggunakan collection stack untuk menampung data yang telah di delete

        /*private static HashSet<string> usedPhoneNumbers = new HashSet<string>();
        private static HashSet<string> usedEmailAddresses = new HashSet<string>();*/
        Contact cont = new Contact();

        public void ViewContacts()
        {
            foreach (var contact in contacts)
            {
                Console.WriteLine("---------------------------------------");
                Console.WriteLine($"" +
                    $"Nama                : {contact.Name} " +
                    $"\nPhone Number        : {contact.PhoneNumber} " +
                    $"\nEmail Address       : {contact.EmailAddress}\n");
            }
        }
        public void CreateContact(string name, string phoneNumber, string emailAddress)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(phoneNumber) || string.IsNullOrWhiteSpace(emailAddress))
            {
                Console.WriteLine("\nInvalid input. Make sure all columns are filled in!\n");
                return; // Jika input tidak valid, keluar dari metode.
            }
            // Validasi nomor telepon/email sesuai format "XXX-XXXXXXX"
            if (!cont.IsValidPhoneNumber(phoneNumber) || !cont.IsValidEmail(emailAddress))
            {
                Console.WriteLine("\nInvalid phone number/email format!\n");
                return;
            }
            // Cek apakah nomor telepon atau alamat email yang baru sudah ada dalam data user yang lain
            if (contacts.Any(c => (c.PhoneNumber == phoneNumber || c.EmailAddress == emailAddress)))
            {
                Console.WriteLine("\nThe phone number or email address is already in use by another contact.");
                return;
            }
            Contact newContact = new Contact(name, phoneNumber, emailAddress);
            contacts.Add(newContact);

            Console.WriteLine("\nContact created successfully.");
            Console.WriteLine("-------------------------------");
        }

        public Contact FindUserEmail(string findEmail)
        {
            return contacts.FirstOrDefault(u => u.EmailAddress == findEmail); //mencari email address berdasarkan inputan user
        }

        public void EditContact(string name, string phoneNumber, string newEmailAddress, string emailAddress)
        {
            // Cari kontak berdasarkan nomor telepon atau alamat email
            Contact existingContact = FindUserEmail(emailAddress);

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(phoneNumber) || string.IsNullOrWhiteSpace(newEmailAddress))
            {
                Console.WriteLine("\nInvalid input. Make sure all columns are filled in!\n");
                return; // Jika input tidak valid, keluar dari metode.
            }
            // Cek apakah nomor telepon atau alamat email yang baru sudah ada dalam data user yang lain
            if (contacts.Any(c => (c.PhoneNumber == phoneNumber || c.EmailAddress == newEmailAddress)))
            {
                Console.WriteLine("\nThe phone number or email address is already in use by another contact.");
                return;
            }
            // Validasi nomor telepon/email sesuai format "XXX-XXXXXXX"
            if (!cont.IsValidPhoneNumber(phoneNumber) || !cont.IsValidEmail(newEmailAddress))
            {
                Console.WriteLine("\nInvalid phone number/email format!\n");
                return;
            }

            existingContact.Name = name;
            existingContact.PhoneNumber = phoneNumber;
            existingContact.EmailAddress = newEmailAddress;
            Console.WriteLine("\nContact changed successfully.");
            Console.WriteLine("-------------------------------");
        }

        public void FindAllUser(string search)
        {
            // Mencari pengguna yang cocok berdasarkan nama yang mengandung kata kunci
            var searchContact = contacts.Where(u => Regex.IsMatch(u.Name, search, RegexOptions.IgnoreCase) ||
                                              Regex.IsMatch(u.PhoneNumber, search, RegexOptions.IgnoreCase) ||
                                              Regex.IsMatch(u.EmailAddress, search, RegexOptions.IgnoreCase)).ToList();

            if (searchContact.Count == 0)
            {
                Console.WriteLine("There are no contacts that match the keywords given!");
            }
            else
            {
                foreach (var item in searchContact)
                {
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine($"\nNama            : {item.Name}");
                    Console.WriteLine($"Phone Number    : {item.PhoneNumber}");
                    Console.WriteLine($"Email Address   : {item.EmailAddress}");
                    Console.WriteLine("--------------------------------------");

                }
            }
        }
        public void DeleteContact(Contact contact)
        {
            if (contacts.Contains(contact))
            {
                contacts.Remove(contact);
                deletedContacts.Push(contact); // Masukkan kontak yang dihapus ke dalam stack.
                Console.WriteLine("\nContact successfully deleted.");
            }
            else
            {
                Console.WriteLine("\nContact not found.");
            }
        }
        public void ShowDeletedContacts()
        {
            // Tampilkan kontak yang telah dihapus dari stack
            Console.WriteLine("Kontak yang telah dihapus:");
            foreach (var deletedContact in deletedContacts)
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine($"" +
                    $"\nNama                : {deletedContact.Name} " +
                    $"\nPhone Number        : {deletedContact.PhoneNumber} " +
                    $"\nEmail Address       : {deletedContact.EmailAddress}");
                Console.WriteLine("--------------------------------------");

            }
        }
    }
}
