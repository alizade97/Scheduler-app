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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            button1.FlatAppearance.BorderSize = 0;
            textBox1.MaxLength = 10;
            textBox2.MaxLength = 10;
            button4.FlatAppearance.BorderSize = 0;
            button5.FlatAppearance.BorderSize = 0;



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



        public Point m;
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            m = new Point(-e.X, -e.Y);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(m.X, m.Y);
                Location = mousePos;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            scon = new SQLiteConnection("Data Source = scdb.db; Version=3;");
            scon.Open();

            string query = "select * from  registration where username= '" + textBox1.Text + "' AND password= '" + textBox2.Text + "'";
            SQLiteCommand scom1 = new SQLiteCommand(query, scon);

            SQLiteDataReader dr = scom1.ExecuteReader();

            int say = 0;



            while (dr.Read())
            {


                say++;



            }




            if (say == 1)

            {
                this.Hide();
                Form3 t = new Form3();

                t.Show();
                if (textBox1.Text != "")
                {
                    Class1.a1 = textBox1.Text;
                }
            }

            if (say != 1)
            {

                MessageBox.Show("Wrong Username or Password");
            }


            scon.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label1.Text = "Giriş formu";
            label2.Text = "Istifadəçi adı";
            label3.Text = "    Şifrə";
            button2.Text = "Daxil ol";
            button3.Text = "Qeydiyyat";
            label5.Text = "Dil seçimi";
            label4.Text = "       Planlaşdırıcı \n\r    tətbiqi proqramı";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label1.Text = "Login form";
            label2.Text = "Username";
            label3.Text = "Password";
            button2.Text = "Log in";
            button3.Text = "Register";
            label5.Text = "Language";
            label4.Text = "Scheduler application";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 t = new Form2();
            this.Hide();
            t.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
