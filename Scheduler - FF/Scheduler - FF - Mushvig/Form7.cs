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
    public partial class Form7 : Form
    {
        public Form7()
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




        private void Form7_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;

            scon = new SQLiteConnection("Data Source = scdb.db; Version=3;");
            scon.Open();

            string query = "SELECT * FROM  registration WHERE username = '" + Class1.a1 + "'";
            SQLiteCommand scom1 = new SQLiteCommand(query, scon);

            SQLiteDataReader dr = scom1.ExecuteReader();

            


            while (dr.Read())
            {

                


                label2.Text += "  "+dr["username"].ToString();
                label3.Text += "  " + dr["name"].ToString();
                label4.Text += "  " + dr["surname"].ToString();
                label5.Text += "  " + dr["email"].ToString();
                label7.Text += "  " + dr["sex"].ToString();
            }

            scon.Close();



        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 t = new Form3();
            t.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form8 f = new Form8();
            f.Show();
        }
    }
}
