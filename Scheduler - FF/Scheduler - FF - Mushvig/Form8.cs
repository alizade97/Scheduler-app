using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Scheduler___FF___Mushvig
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }





        private SQLiteConnection scon;
        private SQLiteCommand scom;
        private SQLiteDataAdapter sad;


        private void setcon()
        {

            scon = new SQLiteConnection("Data Source = scdb.db; Version=3;");

        }

        private void ExecuteQuery(string txtQuery)

        {
            setcon();
            scon.Open();
            scom = scon.CreateCommand();

            scom.CommandText = txtQuery;

            scom.ExecuteNonQuery();

            scon.Close();

        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                string query = "update registration set password='" + textBox2.Text + "' where username='" + Class1.a1 + "'";

                ExecuteQuery(query);
            }

             else
            {
                MessageBox.Show("Fill the textbox");
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form8_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            scon = new SQLiteConnection("Data Source = scdb.db; Version=3;");
            scon.Open();

            string query = "SELECT * FROM  registration WHERE username = '" + Class1.a1 + "'";
            SQLiteCommand scom1 = new SQLiteCommand(query, scon);

            SQLiteDataReader dr = scom1.ExecuteReader();




            while (dr.Read())
            {

             


                textBox2.Text += "  " + dr["password"].ToString();
                textBox3.Text += "  " + dr["name"].ToString();
                textBox4.Text += "  " + dr["surname"].ToString();
                textBox5.Text += "  " + dr["email"].ToString();
                textBox6.Text += "  " + dr["sex"].ToString();
            }

            scon.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                string query = "update registration set email='" + textBox5.Text + "' where username='" + Class1.a1 + "'";

                ExecuteQuery(query);
            }

            else
            {
                MessageBox.Show("Fill the textbox");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
          /* if (textBox4.Text != "" && textBox3.Text != "" && textBox2.Text != "" && textBox5.Text != "" && textBox6.Text != "" )
            {
                string query = "update registration set surname='" + textBox4.Text +"' and set name = '"+textBox3.Text+ "' and set email = '" + textBox5.Text + "' and set sex = '" + textBox6.Text + "' and set password = '" + textBox2.Text + "' where username='" + Class1.a1 + "'";

                ExecuteQuery(query);
            }
            */

            this.Hide();
            Form7 t = new Form7();
            t.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                string query = "update registration set name='" + textBox3.Text + "' where username='" + Class1.a1 + "'";

                ExecuteQuery(query);
            }
            else
            {
                MessageBox.Show("Fill the textbox");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (textBox4.Text != "")
            {
                string query = "update registration set surname='" + textBox4.Text + "' where username='" + Class1.a1 + "'";

                ExecuteQuery(query);
            }
            else
            {
                MessageBox.Show("Fill the textbox");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox6.Text != "") {
                string query = "update registration set sex='" + textBox6.Text + "' where username='" + Class1.a1 + "'";

                ExecuteQuery(query);
            }
            else
            {
                MessageBox.Show("Fill the textbox");
            }
        }
    }
}
