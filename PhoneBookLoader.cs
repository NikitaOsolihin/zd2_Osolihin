using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zd2_Osolihin
{
    static class PhoneBookLoader
    {

        
        public static void Load(PhoneBook phoneBook, string fileName) 
        {
            var reader = new StreamReader(fileName);
            List<Contact> contactsPhoneBook = new List<Contact>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');

                Contact contact = new Contact()
                {
                Name = values[0],
                Phone = values[1]
                };
                contactsPhoneBook.Add(contact);
            }
            reader.Close();

            phoneBook.contacts = contactsPhoneBook;
        }


       
        public static void Save(PhoneBook phoneBook, string fileName)
        {
             var csv = new StringBuilder();
            foreach (var item in phoneBook.contacts)
            {
                string first = item.Name.ToString();
                string second = item.Phone.ToString();
                var newLine = string.Format("{0};{1}", first, second);
                csv.AppendLine(newLine); 
            }
            File.WriteAllText(fileName, csv.ToString());
        }
    }
}
