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
    public partial class Form2 : Form
    {
        public Form2()
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


        private void button2_Click(object sender, EventArgs e)
        {
            Form1 t = new Form1();
            this.Hide();
            t.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            button4.FlatAppearance.BorderSize = 0;
            button5.FlatAppearance.BorderSize = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label1.Text = "     Qeydiyyat ";
            label2.Text = "Istifadəçi adı :";
            label3.Text = "Şifrə :";
            label4.Text = "Şifrə :";
            label5.Text = "     Ad :";
            label6.Text = "     Soyad :";
            label7.Text = "E-poçt :";
            label8.Text = " Cinsiyyət :";
            radioButton1.Text = "Kişi";
            radioButton2.Text = "Qadın";
            radioButton3.Text = "Qeyri-müəyyən";
            label9.Text = "     Dil :";
            button3.Text = "Qeydiyyatdan keç";
            button2.Text = "Daxil ol";
            this.Text = "Planlaşdırıcı tətbiqi proqramı - Qeydiyyat";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            label1.Text = "Registration Form ";
            label2.Text = "Username :";
            label3.Text = "Password :";
            label4.Text = "Password :";
            label5.Text = "Name :";
            label6.Text = "Surname :";
            label7.Text = "E-mail :";
            label8.Text = "Sexuality :";
            radioButton1.Text = "Male";
            radioButton2.Text = "Female";
            radioButton3.Text = "None";
            label9.Text = "Language :";
            button3.Text = "Register";
            button2.Text = "Return to Login";
            this.Text = "Scheduler app - Registration form";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("your password does not match");
            }

            if (textBox2.Text == textBox3.Text && textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {
                string s = "";
                if (radioButton1.Checked == true)
                {
                    s = "male";
                }
                if (radioButton2.Checked == true)
                {
                    s = "female";
                }
                if (radioButton3.Checked == true)
                {
                    s = "none";
                }

                scon = new SQLiteConnection("Data Source = scdb.db; Version=3;");
                scon.Open();
                string query = "SELECT username FROM  registration ";
                SQLiteCommand scom1 = new SQLiteCommand(query, scon);

                SQLiteDataReader dr = scom1.ExecuteReader();

                Boolean a = false;

                while (dr.Read())
                {

                    if (textBox1.Text == dr["username"].ToString())
                    {
                        a = true;
                    }

                }

                scon.Close();

                if (a == false)
                {
                    string q = "insert into registration (username,password,name,surname,email,sex) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + s + "')";
                    ExecuteQuery(q);
                    MessageBox.Show("You have registered");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    radioButton3.Checked = false;
                }
                else
                {
                    MessageBox.Show("Choose another username");
                }


            }

            else
            {


                MessageBox.Show("You have not filled all boxes");

            }
        }

        private void azToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }
    }
}
