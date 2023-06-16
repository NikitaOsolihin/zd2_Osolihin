using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace zd2_Osolihin
{
    public class PhoneBook
    {
      public List<Contact> contacts { get; set; }


        public PhoneBook Search(string str, PhoneBook phone)
        {
            PhoneBook search = new PhoneBook();
            search.contacts = new List<Contact>();
            if (str == "" || str == null || str == " ")
            {
                foreach (var item in phone.contacts)
                {
                    search.contacts.Add(new Contact() 
                    {
                        Name = item.Name, 
                        Phone = item.Phone
                    });
                }
            }

            else
            {

                foreach (var item in phone.contacts)
                {
                    if (item.Name.ToLower().Contains(str.ToLower()))
                        search.contacts.Add(new Contact()
                        {
                            Name = item.Name,
                            Phone = item.Phone
                        });
                }
            }
            return search;
        } 
        
        
        public Contact AddContact(string name, string Phone)
        {
            Contact contact = new Contact()
            {
                Name = name,
                Phone = Phone
            };
            return contact;
        }

        public List<string> OutputContacts(PhoneBook phone)
        {
            List<Contact> contacts = phone.contacts;
            List<string> contactsList = new List<string>();
            foreach (var item in contacts) 
            {
                contactsList.Add(item.Name + "   " + item.Phone);
            }
            return contactsList;
        }

        public PhoneBook DeleteContact(PhoneBook phone, string str)
        {
            foreach (var item in phone.contacts)
            {
                if ((item.Name + "  " + item.Phone).Contains(str))
                {
                    phone.contacts.Remove(item);
                    break;
                }
            }
            return phone;


        }




    }
}
