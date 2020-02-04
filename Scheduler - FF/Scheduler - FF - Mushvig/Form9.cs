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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 t = new Form3();
            this.Hide();
            t.Show();
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        Label[] l = new Label[50];
        Button[] b = new Button[50];
        Button[] ee = new Button[50];

        private void Form9_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;

            scon = new SQLiteConnection("Data Source = scdb.db; Version=3;");
            scon.Open();

            string query = "SELECT name FROM  event WHERE username = '" + Class1.a1 + "'";
            SQLiteCommand scom1 = new SQLiteCommand(query, scon);

            SQLiteDataReader dr = scom1.ExecuteReader();



            int i = 0;
            while (dr.Read())
            {
                l[i] = new Label();
                b[i] = new Button();
                ee[i] = new Button();


                l[i].Text =  dr["name"].ToString();
                b[i].Text = "Show details";
                ee[i].Text = "Delete";

                l[i].Top = 80 * (i + 1);
                l[i].Left = 100;
                l[i].ForeColor = Color.White;
                l[i].Font = new Font("Times New Roman", 16.0f);
                
                b[i].Top = 80 * (i + 1);
                b[i].Left = 400;
                b[i].ForeColor = Color.White;
                b[i].Size = new Size(100,47);
                b[i].Font= new Font("Times New Roman", 16.0f);
                b[i].Click += new EventHandler(ButtonClicks);


                ee[i].Top = 80 * (i + 1);
                ee[i].Left = 600;
                ee[i].ForeColor = Color.White;
                ee[i].Size = new Size(100, 47);
                ee[i].Font = new Font("Times New Roman", 16.0f);
                ee[i].Click += new EventHandler(ButtonClicks1);



                this.Controls.Add(ee[i]);
                this.Controls.Add(b[i]);
                this.Controls.Add(l[i]);
                i++;

                


            }


            





            scon.Close();
        }


        public void ButtonClicks(object sender, EventArgs e)

        {

            Form6 y = new Form6();
            this.Hide();
            y.Show();

            int i;
            for (i = 0; i < b.Length; i++)
            { if (b[i] == (Button)sender) break; }



            scon = new SQLiteConnection("Data Source = scdb.db; Version=3;");
            scon.Open();

            string query = "SELECT * FROM  event WHERE name = '" + l[i].Text + "'";
            SQLiteCommand scom1 = new SQLiteCommand(query, scon);

            SQLiteDataReader dr = scom1.ExecuteReader();




            while (dr.Read())
            {



                y.label2.Text = dr["name"].ToString();
                y.label9.Text = dr["location"].ToString();
                y.label10.Text = dr["sday"].ToString() + " / " + dr["smonth"].ToString() + " / " + dr["syear"].ToString();
                y.label11.Text = dr["eday"].ToString() + " / " + dr["emonth"].ToString() + " / " + dr["eyear"].ToString();
                y.textBox1.Text = dr["description"].ToString();

            }




            DateTime s = Convert.ToDateTime(y.label10.Text);
            TimeSpan m = s - DateTime.Now;

            y.label12.Text = m.ToString("d' Days 'h' Hours '");









            scon.Close();

        }




        public void ButtonClicks1(object sender, EventArgs e)

        {

            

            int i;
            for (i = 0; i < ee.Length; i++)
            { if (ee[i] == (Button)sender) break; }



           

            string query = "DELETE FROM  event WHERE name = '" + l[i].Text + "'";
         

            ExecuteQuery(query);

            
            


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick_2(object sender, EventArgs e)
        {
           
        }
    }
}
