using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ManajemenKontak
{
    public class Contact
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public Contact() { }
        public Contact(string name, string phoneNumber, string emailAddress)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
        }

        public bool IsValidPhoneNumber(string phoneNumber)
        {
            // Lakukan validasi nomor telepon sesuai format yang diinginkan
            // Misalnya, format XXX-XXXXXXX
            // Di sini dapat menggunakan ekspresi reguler (regex) untuk validasi lebih lanjut.
            if (Regex.IsMatch(phoneNumber, @"^\+?[0-9]{8,15}$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsValidEmail(string emailAddress)
        {
            // Lakukan validasi alamat email sesuai format yang diinginkan
            // Di sini dapat menggunakan ekspresi reguler (regex) untuk validasi lebih lanjut.

            if (Regex.IsMatch(emailAddress, @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
