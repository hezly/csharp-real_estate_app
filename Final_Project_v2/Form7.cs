using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Final_Project_v2
{
    public partial class Form7 : MetroFramework.Forms.MetroForm
    {
        public Form7()
        {
            InitializeComponent();
        }
        DataTable dbdataset;
        private void Form7_Load(object sender, EventArgs e)
        {
            refresh_table();
        }
        public void refresh_table()
        {
            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;password=";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand("SELECT * FROM prct_perumahan_citraland.dbase_kasir;", myConn);
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDatabase;
                dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                dataGridView1.DataSource = bSource;
                sda.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            tb_idKasir.Text = row.Cells["id_kasir"].Value.ToString();
            tb_username2.Text = row.Cells["user_name"].Value.ToString();
            tb_password2.Text = row.Cells["password"].Value.ToString();
            level2.Text = row.Cells["level"].Value.ToString();
        }

        private void btn_tambah_Click(object sender, EventArgs e)
        {
            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;password=";
            string Query = "insert into prct_perumahan_citraland.dbase_kasir (id_kasir,user_name,password,level) values('','" + this.tb_username.Text + " ',' " + this.tb_password.Text + "','" +this.level.Text+"'); ";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand(Query, myConn);
            MySqlDataReader myReader;

            try
            {
                myConn.Open();
                myReader = cmdDatabase.ExecuteReader();
                MessageBox.Show("Data Inserted Successfuly");
                while (myReader.Read())
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            refresh_table();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            string myConnection = "datasource=localhost;port=3306;username=root;password=";
            string Query = " UPDATE prct_perumahan_citraland.dbase_kasir  SET user_name = '" + tb_username2.Text + "', password	= '" + tb_password2.Text + "' WHERE id_kasir = '" + tb_idKasir.Text + "'; ";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand(Query, myConn);
            MySqlDataReader myReader;

            try
            {
                myConn.Open();
                myReader = cmdDatabase.ExecuteReader();
                MessageBox.Show("Data Updated Successfuly");
                while (myReader.Read())
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            refresh_table();
        }

        private void btn_hapus_Click(object sender, EventArgs e)
        {
            string myConnection = "datasource=localhost;port=3306;username=root;password=";
            string Query = " DELETE FROM prct_perumahan_citraland.dbase_kasir WHERE id_kasir = '" + tb_idKasir.Text + "'; ";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand(Query, myConn);
            MySqlDataReader myReader;

            try
            {
                myConn.Open();
                myReader = cmdDatabase.ExecuteReader();
                MessageBox.Show("Data Delete Successfuly ");
                while (myReader.Read())
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            refresh_table();
        }

        private void tb_cariNama_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(dbdataset);
            dv.RowFilter = string.Format("user_name LIKE '%{0}%'", tb_search.Text);
            dataGridView1.DataSource = dv;
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Form8 run = new Form8();
            run.Show();
            this.Hide();
        }
    }
}
