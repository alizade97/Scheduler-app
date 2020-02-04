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
    public partial class Form5 : Form
    {
        public Form5()
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




        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 t = new Form3();
            t.Show();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ad = Class1.a1;

            string[] x = new string[6];
            string[] x1 = new string[6];

            x = dateTimePicker1.Value.ToString().Split('.', ' ', ':');
            x1 = dateTimePicker2.Value.ToString().Split('.', ' ', ':');


            string stime = comboBox1.GetItemText(comboBox1.SelectedItem);
            string etime = comboBox2.GetItemText(comboBox2.SelectedItem);

            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && etime != "" && stime != "")
            {

            string q = "insert into event(username, name,location,syear,smonth,sday,stime,eyear,emonth,eday,etime,description  ) values('" + ad + "','" + textBox1.Text + "','" + textBox2.Text + "','" + x[2] + "','" + (int.Parse(x[1]) ).ToString() + "','" + x[0] + "','" + stime + "','" + x1[2] + "','" + (int.Parse(x1[1])).ToString() + "','" + x1[0] + "','" + etime + "','" + textBox3.Text + "')";


            ExecuteQuery(q);
            MessageBox.Show("Event added");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
             
          }

        }

        private void button48_Click(object sender, EventArgs e)
        {
            label1.Text = "Yeni tədbir əlavə et";
            label2.Text = "Tədbirin adı :";
            label3.Text = "   Tədbirin yeri :";
            label4.Text = "Başlama tarixi :";
            label5.Text = "Qurtarma tarixi :";
            label6.Text = "          Haqqında :";
            label7.Text = "Vaxt :";
            label8.Text = "Vaxt :";
            button1.Text = "Bağla";
            button2.Text = "Əlavə et";

        }

        private void button47_Click(object sender, EventArgs e)
        {
            label1.Text = "Add new Event";
            label2.Text = "  Event name:";
            label3.Text = "Event Location :";
            label4.Text = "          Start date:";
            label5.Text = "          End date :";
            label6.Text = "Event description :";
            label7.Text = "Time :";
            label8.Text = "Time :";
            button1.Text = "Close";
            button2.Text = "Add";
        }
    }
}
