using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zd2_Osolihin
{
    public partial class Form1 : Form
    {
        PhoneBook phone = new PhoneBook();
        public Form1()
        {
            InitializeComponent();
            PhoneBookLoader.Load(phone, Environment.CurrentDirectory + "\\contacts.csv");

            foreach (var item in phone.OutputContacts(phone))
            {
                listBox1.Items.Add(item);
            } 
        }

        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
           
            foreach (var item in phone.Search(textBox1.Text, phone).contacts)
            {
                listBox1.Items.Add(item.Name + "  " + item.Phone);
            }
        }


        
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        
        private void button2_Click(object sender, EventArgs e)
        {
            PhoneBookLoader.Save(phone, Environment.CurrentDirectory + "\\contacts.csv");
            MessageBox.Show("Сохранено!");
        }

        
        private void button4_Click(object sender, EventArgs e)
        {
            Contact newContact = phone.AddContact(textBox2.Text, textBox3.Text);
           
            phone.contacts.Add(newContact);
            listBox1.Items.Add(newContact.Name + "  " + newContact.Phone);

            MessageBox.Show("Добавлено!");
        }


       
        private void button1_Click(object sender, EventArgs e)
        {
            string forDelete = listBox1.SelectedItem as string;
            if (forDelete != null)
            {
                phone = phone.DeleteContact(phone, forDelete);
                listBox1.Items.Remove(forDelete);
                MessageBox.Show("Успешно!");
            }
        }
    }
}
