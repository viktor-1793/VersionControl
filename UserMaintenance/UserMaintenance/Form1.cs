using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {

        BindingList<User> users = new BindingList<User>();

        public Form1()
        {
            InitializeComponent();

            label1.Text = Resource1.FullName; // label1
            //label2.Text = Resource1.FirstName; // label2
            button1.Text = Resource1.Add; // button1
            button2.Text = Resource1.Felirat;

            listBox1.DataSource = users;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = textBox1.Text
                //FirstName = textBox2.Text
            };
            users.Add(u);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.InitialDirectory = Application.StartupPath;
            sfd.Filter = "Comma Seperated Values (*.csv)|*.csv";
            sfd.DefaultExt = "csv";
            sfd.AddExtension = true;

            if (sfd.ShowDialog() != DialogResult.OK) return;
           
            /*
            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sfd.FileName);
            foreach (var item in listBox1.Items)
            {
                SaveFile.WriteLine(item.ToString());
            }
            */

            using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
            {
                /*sw.WriteLine(listBox1.Items.ToString()+textBox1.Text+textBox2.Text);
                sw.Close();*/

                sw.Write("ID:");
                sw.Write(";");
                sw.Write("Fullname:");
                sw.WriteLine();

                foreach (User u in listBox1.Items) sw.WriteLine(/*u.FullName+";"+u.ID*/string.Format("{0};{1}", u.ID, u.FullName));
                
            }

            MessageBox.Show("A fájlba írás megtörtént");

            Application.Exit();
        }
    }
}
