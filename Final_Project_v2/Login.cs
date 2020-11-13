using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using MySql.Data.MySqlClient;

namespace Final_Project_v2
{
    public partial class Login : Form
    {
        public Login()
        {
            Thread obj = new Thread(new ThreadStart(SplashStart));
            obj.Start();
            Thread.Sleep(5000);
            InitializeComponent();
            obj.Abort();
        }

        public void SplashStart()
        {
            Application.Run(new sps());
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //
            try
            {
                //connection 
                string myConnection = "datasource=localhost;port=3306;username=root;password=";
                MySqlConnection myConn = new MySqlConnection(myConnection);

                MySqlCommand SelectCommand = new MySqlCommand("select * from prct_perumahan_citraland.dbase_kasir where user_name= '" + this.textBox_username.Text + "' and password='" + this.textBox_password.Text + "' ;", myConn);
                MySqlDataReader myReader;

                myConn.Open(); // start connection
                myReader = SelectCommand.ExecuteReader();
                int count = 0;
                while (myReader.Read())
                {
                    count = count + 1;
                }
                if (count == 1)
                {
                    MessageBox.Show("WELCOME");
                    // codes to call an Interface
                    Form10 run = new Form10();
                    run.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Wrong username or password");
                }
                myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkBox_show_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_show.Checked)
            {
                textBox_password.UseSystemPasswordChar = true;
            }
            else
            {
                textBox_password.UseSystemPasswordChar = false;
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
    }

