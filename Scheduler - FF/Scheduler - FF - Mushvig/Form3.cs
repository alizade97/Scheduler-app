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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

          



           

            Application.DoEvents();
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


        Label[] l = new Label[50];
        Label[] l1 = new Label[50];
        Button[] b = new Button[50];


        private void Form3_Load(object sender, EventArgs e)
        {


            this.VerticalScroll.Enabled = true;

            this.HorizontalScroll.Enabled = false;













            button1.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.BorderSize = 0;
             button3.FlatAppearance.BorderSize = 0;
              button4.FlatAppearance.BorderSize = 0;
            button5 .FlatAppearance.BorderSize = 0;
 
               button6.FlatAppearance.BorderSize = 0;
        }







        







        public Point m;

        private void Form3_MouseDown(object sender, MouseEventArgs e)
        {
            m = new Point(-e.X, -e.Y);
        }

        private void Form3_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(m.X, m.Y);
                Location = mousePos;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 t = new Form1();
            t.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 t = new Form4();
            t.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 x = new Form5();
            this.Hide();
            x.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form7 t = new Form7();
            this.Hide();
            t.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label2.Text = "Son tədbirlər";
            label3.Text = "Başlamasına qalan Müddət";
            label1.Text = "Planlaşdırıcı";
            button1.Text = "Profil";
            button2.Text = "Tədbirlər";
            button3.Text = "    Tədbir əlavə et";
            button4.Text = "Təqvim";
            button5.Text = "Çıxış";
            label5.Text = "Indi :";
        }

        private void button7_Click(object sender, EventArgs e)
        {

            label2.Text = "Latest Events";
            label3.Text = "Time to start of Event";
            label1.Text = "Scheduler App";
            button1.Text = "Profile";
            button2.Text = "Events";
            button3.Text = "  Add Event";
            button4.Text = "Calendar";
            button5.Text = "Log out";
            label5.Text = "Current :";
        }

        private void azToolStripMenuItem_Click(object sender, EventArgs e)
        {
           /* label1.Text = "Planlaşdırıcı";
            button1.Text = "Profil";
            button2.Text = "Tədbirlər";
            button3.Text = "    Tədbir əlavə et";
            button4.Text = "Təqvim";
            button5.Text = "Çıxış";*/
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form9 t = new Form9();
            this.Hide();
            t.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text =DateTime.Now.ToShortDateString()+" "+ DateTime.Now.ToLongTimeString();


            scon = new SQLiteConnection("Data Source = scdb.db; Version=3;");
            scon.Open();

            string query = "SELECT * FROM  event WHERE username = '" + Class1.a1 + "'";
            SQLiteCommand scom1 = new SQLiteCommand(query, scon);

            SQLiteDataReader dr = scom1.ExecuteReader();



            int i = 0;
            while (dr.Read())
            {
                l[i] = new Label() { Width = 1000 };
                l1[i] = new Label() { Width = 1000 };


               
                string bbb = dr["sday"].ToString() + "." + dr["smonth"].ToString() + "." + dr["syear"].ToString() + " " + dr["stime"].ToString();

                l[i].BackColor = Color.Transparent;
                 l1[i].BackColor = Color.Transparent;

                

                  DateTime aaa = Convert.ToDateTime(bbb);
                  TimeSpan ttt = aaa - DateTime.Now;

                if (ttt.TotalDays < 10)
                {
                    l[i].Text = dr["name"].ToString();

                    l[i].Top = 85 * (i + 1);


                    l[i].Left = 250;
                    l[i].ForeColor = Color.White;
                    l[i].Font = new Font("Times New Roman", 16.0f);

                    l1[i].Top = 85 * (i + 1);
                    l1[i].Left = 450;
                    l1[i].ForeColor = Color.White;
                    l1[i].Font = new Font("Times New Roman", 16.0f);




                    l1[i].Text = ttt.ToString("d' Days 'h' Hours 'm' Minutes 's' Seconds'");

                  /*  for (int y = 0; y < l1.Length; y++) {
                        for (int x = 0; x < l1.Length; x++)
                        {

                            if (Convert.ToDateTime(l1[x].Text) > Convert.ToDateTime(l1[x + 1].Text))
                            {
                                string nnn;
                                string vvv;

                                vvv = l1[x + 1].ToString();
                                nnn = l[x + 1].ToString();

                                l1[x + 1].Text = l1[x].ToString();
                                l[x + 1].Text = l[x].ToString();

                                l1[x].Text = vvv;
                                l[x].Text = vvv;


                            }
                        }


                    }*/


                    this.Controls.Add(l1[i]);
                    this.Controls.Add(l[i]);
                    i++;
                }
            




            }








            scon.Close();




            timer1.Start();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
