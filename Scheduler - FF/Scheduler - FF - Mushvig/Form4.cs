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
    public partial class Form4 : Form
    {
        public Form4()
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

        Button[] a = new Button[42];

        void calendar()
        {
            try
            {
                
                a[0] = button1;
                a[1] = button2;
                a[2] = button3;
                a[3] = button4;
                a[4] = button5;
                a[5] = button6;
                a[6] = button7;
                a[7] = button8;
                a[8] = button9;
                a[9] = button10;
                a[10] = button11;
                a[11] = button12;
                a[12] = button13;
                a[13] = button14;
                a[14] = button15;
                a[15] = button16;
                a[16] = button17;
                a[17] = button18;
                a[18] = button19;
                a[19] = button20;
                a[20] = button21;
                a[21] = button22;
                a[22] = button23;
                a[23] = button24;
                a[24] = button25;
                a[25] = button26;
                a[26] = button27;
                a[27] = button28;
                a[28] = button29;
                a[29] = button30;
                a[30] = button31;
                a[31] = button32;
                a[32] = button33;
                a[33] = button34;
                a[34] = button35;
                a[35] = button36;
                a[36] = button37;
                a[37] = button38;
                a[38] = button39;
                a[39] = button40;
                a[40] = button41;
                a[41] = button42;



                int m = 50;
                string wd;
                label3.Text = textBox1.Text;
                if (textBox2.Text == "1")
                {
                    m = 31;

                    label4.Text = "January";
                }
                if (textBox2.Text == "2")
                {
                    if (int.Parse(textBox1.Text) % 4 == 0 || int.Parse(textBox1.Text) % 100 == 0 || int.Parse(textBox1.Text) % 400 == 0)
                    {
                        m = 29;
                    }
                    else m = 28;
                    label4.Text = "February";
                }
                if (textBox2.Text == "3")
                {
                    m = 31;
                    label4.Text = "March";
                }
                if (textBox2.Text == "4")
                {
                    m = 30;
                    label4.Text = "April";
                }
                if (textBox2.Text == "5")
                {
                    m = 31;
                    label4.Text = "May";
                }
                if (textBox2.Text == "6")
                {
                    m = 30;
                    label4.Text = "June";
                }
                if (textBox2.Text == "7")
                {
                    m = 31;
                    label4.Text = "July";
                }
                if (textBox2.Text == "8")
                {
                    m = 31;
                    label4.Text = "August";
                }
                if (textBox2.Text == "9")
                {
                    m = 30;
                    label4.Text = "September";
                }
                if (textBox2.Text == "10")
                {
                    m = 31;
                    label4.Text = "October";
                }

                if (textBox2.Text == "11")
                {
                    m = 30;
                    label4.Text = "November";
                }

                if (textBox2.Text == "12")
                {
                    m = 31;
                    label4.Text = "December";
                }

                wd = (7).ToString() + "." + (int.Parse(textBox2.Text)).ToString() + "." + textBox1.Text;
                DateTime f = Convert.ToDateTime(wd);



                for (int i = 0; i < 42; i++)
                {
                    a[i].Hide();
                    a[i].FlatAppearance.BorderSize = 0;

                }

                int j = 1;
                for (int i = (int)f.DayOfWeek; i < m + (int)f.DayOfWeek; i++)
                {


                    a[i].Show();
                    a[i].Text = j.ToString();
                    j++;

                    if ((Convert.ToDateTime(a[i].Text + "." + textBox2.Text + "." + textBox1.Text)).ToString("dd.MM.yyyy") == DateTime.Now.ToShortDateString())
                    {

                        a[i].BackColor = Color.Red;
                        a[i].ForeColor = Color.White;
                    }
                    else
                    {
                        a[i].BackColor = Color.Transparent;
                        a[i].ForeColor = Color.Black;
                    }
                }


                
                scon = new SQLiteConnection("Data Source = scdb.db; Version=3;");

                scon.Open();
                string query = "SELECT * FROM  event ";
                SQLiteCommand scom1 = new SQLiteCommand(query, scon);
                 scom1.ExecuteNonQuery();
                SQLiteDataReader dr = scom1.ExecuteReader();

                int u = 0;



                while (dr.Read())
                {
                    for (u = 0; u < 42; u++)
                    {
                        if (Class1.a1==dr["username"].ToString() &&  a[u].Text == dr["sday"].ToString() && textBox2.Text == dr["smonth"].ToString() && textBox1.Text == dr["syear"].ToString())
                        {

                            a[u].BackColor = Color.Green;

                        }

                    }

                }




                scon.Close();

                for (int x = 0; x < a.Length; x++)
                {
                    
                        a[x].Click += new EventHandler(ButtonClicks);


                }



            }





            catch (Exception)
            {

                MessageBox.Show("There is a Error");

            }
        }



        public void ButtonClicks(object sender, EventArgs e)

        {

           

            int i;
            for (i = 0; i < a.Length; i++)
            { if (a[i] == (Button)sender) break;
                 }

            Form6 y = new Form6();
           

            scon = new SQLiteConnection("Data Source = scdb.db; Version=3;");
            scon.Open();

           string query = "SELECT * FROM  event WHERE sday = '" + a[i].Text + "' AND smonth = '" + textBox2.Text + "' AND syear = '" +textBox1.Text+"'";
          SQLiteCommand scom1 = new SQLiteCommand(query, scon);

            SQLiteDataReader dr = scom1.ExecuteReader();

            int say=0;

           
            while (dr.Read())
            {

                say++;
                

                y.label2.Text = dr["name"].ToString();
                y.label9.Text = dr["location"].ToString();
                y.label10.Text = dr["sday"].ToString() + "." + dr["smonth"].ToString() + "." + dr["syear"].ToString();
                y.label11.Text = dr["eday"].ToString() + "." + dr["emonth"].ToString() + "." + dr["eyear"].ToString();
                y.textBox1.Text = dr["description"].ToString();

               /* yyyy[0] = dr["name"].ToString();
                yyyy[1] = dr["location"].ToString();
                yyyy[2] = dr["sday"].ToString() + "." + dr["smonth"].ToString() + "." + dr["syear"].ToString();
                yyyy[3] = dr["eday"].ToString() + "." + dr["emonth"].ToString() + "." + dr["eyear"].ToString();
                yyyy[4] = dr["description"].ToString();*/



            }

            scon.Close();


            if (say >0 )
            {

                this.Hide();
                y.Show();
                


                DateTime s = Convert.ToDateTime(y.label10.Text);
                TimeSpan m = s - DateTime.Now;
               
                    y.label12.Text = m.ToString("d' Days 'h' Hours '");


               /* y.label2.Text = yyyy[0];
                y.label9.Text = yyyy[1];
                y.label10.Text = yyyy[2]; ;
                y.label11.Text = yyyy[3]; ;
                y.textBox1.Text = yyyy[4]; ;*/

               

            }

            

        }


        



            private void Form4_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;



            try
            {

                textBox1.Text = DateTime.Now.Year.ToString();
                textBox2.Text = DateTime.Now.Month.ToString();
                calendar();
            }
            catch (Exception)
            {
                MessageBox.Show("There is a Error");
            }

        }

        private void button43_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text == "1")
                {
                    textBox1.Text = (int.Parse(textBox1.Text) - 1).ToString();
                    textBox2.Text = "12";

                }
                else
                {

                    textBox2.Text = (int.Parse(textBox2.Text) - 1).ToString();

                }
                calendar();
            }
            catch (Exception)
            {
                MessageBox.Show("There is Error");
            }
        }

        private void button44_Click(object sender, EventArgs e)
        {

            try
            {
                if (textBox2.Text == "12")
                {
                    textBox1.Text = (int.Parse(textBox1.Text) + 1).ToString();
                    textBox2.Text = "1";

                }
                else
                {
                    textBox2.Text = (int.Parse(textBox2.Text) + 1).ToString();
                }

                calendar();

            }
            catch (Exception)
            {
                MessageBox.Show("There is Error");
            }
        }

        private void button45_Click(object sender, EventArgs e)
        {
            calendar();
        }

        private void button46_Click(object sender, EventArgs e)
        {
            Form3 t = new Form3();
            this.Hide();
            t.Show();
        }

        private void button48_Click(object sender, EventArgs e)
        { 
            label5.Text = "Il : ";
            label6.Text = "Ay : ";
            label14.Text = "Dil : ";
            button46.Text = "Geri Qayıt";
            label1.Text = "Ili daxil edin :";
            label2.Text = "Ayı daxil edin :";
            button45.Text = "Göstər";
            label7.Text = "B.E.";
            label8.Text = "Ç.A.";
            label9.Text = "Çər.";
            label10.Text = "C.A.";
            label11.Text = "Cüm.";
            label12.Text = "Şən.";
            label13.Text = "Baz.";
        }

        private void button47_Click(object sender, EventArgs e)
        {
            label5.Text = "Year : ";
            label6.Text = "Month : ";
            label14.Text = "Language : ";
            button46.Text = "Return Back";
            label1.Text = "Enter year :";
            label2.Text = "Enter month :";
            button45.Text = "Show";
            label7.Text = "Mon.";
            label8.Text = "Tue.";
            label9.Text = "Wed.";
            label10.Text = "Thu.";
            label11.Text = "Fri.";
            label12.Text = "Sat.";
            label13.Text = "Sun.";
        }
    }
}
