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
    public partial class Form5 : MetroFramework.Forms.MetroForm
    {
        public Form5()
        {
            InitializeComponent();
        }
        DataTable dbdataset;

        public void refresh_table()
        {
            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;password=";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand("SELECT * FROM prct_perumahan_citraland.dbase_customer;", myConn);
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
        private void Form5_Load(object sender, EventArgs e)
        {
            refresh_table();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

            id_customer.Text = row.Cells["id_customer"].Value.ToString();
            tex_nama_Ed.Text = row.Cells["Nama"].Value.ToString();
            tex_Alamat_Ed.Text = row.Cells["Alamat"].Value.ToString();
            tex_nohp_ed.Text = row.Cells["No_Hp"].Value.ToString();
            tex_ktp_ed.Text = row.Cells["KTP"].Value.ToString();
            tex_pekerjaan_Ed.Text = row.Cells["Pekerjaan"].Value.ToString();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;password=";
            string Query = "insert into prct_perumahan_citraland.dbase_customer (id_customer,Nama,Alamat,No_Hp,KTP,Pekerjaan) values('','" + this.tex_Nama_T.Text + " ',' " + this.tex_Alamat_T.Text + "','" + this.tex_noHp_T.Text + "','" + this.tex_ktp_T.Text + "','" + this.tex_pekerjaan_T.Text + "'); ";
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

        private void metroButton2_Click(object sender, EventArgs e)
        {
            string myConnection = "datasource=localhost;port=3306;username=root;password=";
            string Query = " DELETE FROM prct_perumahan_citraland.dbase_customer WHERE id_customer = '" + id_customer.Text + "'; ";
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

        private void metroButton3_Click(object sender, EventArgs e)
        {
            string myConnection = "datasource=localhost;port=3306;username=root;password=";
            string Query = " UPDATE prct_perumahan_citraland.dbase_customer  SET Nama = '" + tex_nama_Ed.Text + "', Alamat	= '" + tex_Alamat_Ed.Text + "', No_Hp	= '" + tex_nohp_ed.Text + "', KTP = '" + tex_ktp_ed.Text + "', Pekerjaan = '" + tex_pekerjaan_Ed.Text + "' WHERE id_customer = '" + id_customer.Text + "'; ";
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

      

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dbdataset);
            dv.RowFilter = string.Format("nama LIKE '%{0}%'", textBox1.Text);
            dataGridView1.DataSource = dv;
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Form10 obj = new Form10();
            obj.Show();
            this.Hide();
        }
    }

       
    }
    

