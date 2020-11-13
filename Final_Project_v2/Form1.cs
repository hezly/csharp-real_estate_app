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
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataTable dbdataset;
        void fillCombo()
        {

            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;password=";
            string Query = "SELECT * FROM prct_perumahan_citraland.dbase_customer;";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand(Query, myConn);
            MySqlDataReader myReader;

            try
            {
                myConn.Open();
                myReader = cmdDatabase.ExecuteReader();
                while (myReader.Read())
                {
                    string sName = myReader.GetString("Nama");// load field nama from table db_customer
                   comboBox1.Items.Add(sName); //add nama into ComboBoxItem
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void refresh_table2()
        {
            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;password=";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_transaksi, id_rumah, tipe_pembayaran, nominal_tanda_jadi, uang_DP, nominal_cash, nominal_cicilan_1, nominal_cicilan_2, nominal_cicilan_3, denda FROM prct_perumahan_citraland.dbase_transaksi;", myConn);
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDatabase;
                dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                dataGridView2.DataSource = bSource;
                sda.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void refresh_table1()
        {
            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;password=";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_rumah, Cluster, tipe_rumah, luas_bangunan, luas_tanah, harga_KPR, harga_INHOUSE, status FROM prct_perumahan_citraland.dbase_rumah;", myConn);
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
        public void refresh_table_on()
        {
            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;password=";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_rumah, Cluster, tipe_rumah, luas_bangunan, luas_tanah, harga_KPR, harga_INHOUSE, status FROM prct_perumahan_citraland.dbase_rumah WHERE status > 0;", myConn);
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

        public void refresh_table_off()
        {
            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;password=";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_rumah, Cluster, tipe_rumah, luas_bangunan, luas_tanah, harga_KPR, harga_INHOUSE, status FROM prct_perumahan_citraland.dbase_rumah WHERE status = 0;", myConn);
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
        public void status_rumah_on(int id_rumah)
        {
            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;password=";
            string Query = "UPDATE prct_perumahan_citraland.dbase_rumah SET status = '>1' WHERE  id_rumah ='" + lbl_idRumah.Text + "';";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand(Query, myConn);
            MySqlDataReader myReader;

            try
            {
                myConn.Open();
                myReader = cmdDatabase.ExecuteReader();
                while (myReader.Read())
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void status_rumah_off(int id_rumah)
        {
            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;password=";
            string Query = "UPDATE prct_perumahan_citraland.dbase_rumah SET status= '0' WHERE  id_rumah='" + lbl_idRumah.Text + "';";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand(Query, myConn);
            MySqlDataReader myReader;

            try
            {
                myConn.Open();
                myReader = cmdDatabase.ExecuteReader();
                while (myReader.Read())
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            cb_tipePembayaran.Items.Add("Cash");
            cb_tipePembayaran.Items.Add("Cicil");
            fillCombo();
            refresh_table1();
            refresh_table2();

        }

    private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void metroTextBox5_Click(object sender, EventArgs e)
        {

        }

        private void metroDateTime3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

          
        }

        private void metroTabPage2_Click(object sender, EventArgs e)
        {

        }

        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroTabPage1_Click(object sender, EventArgs e)
        {

        }

        private void metroTabPage4_Click(object sender, EventArgs e)
        {

        }

        private void metroComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;password=";
            string Query = "SELECT * FROM prct_perumahan_citraland.dbase_customer where Nama='" + comboBox1.Text + "';";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand(Query, myConn);
            MySqlDataReader myReader;

            try
            {
                myConn.Open();
                myReader = cmdDatabase.ExecuteReader();
                while (myReader.Read())
                {
                    string sID = myReader.GetString("id_customer").ToString();
                    label_id.Text = sID;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        { 
            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;password=";

            string Query = "INSERT INTO prct_perumahan_citraland.dbase_transaksi (id_transaksi, id_rumah, tipe_pembayaran, tanggal_tanda_jadi, nominal_tanda_jadi, sisa_pembayaran)  VALUES(NULL,  '" + lbl_idRumah.Text + "','" + cb_tipePembayaran.Text + "','" + date_tanda_jadi.Value.Date.ToString("yyyy-MM-dd") + "', '" + textbox_nominal_TJ.Text + "','" +lbl_sisa_pembayaran.Text+ "'); ";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand(Query, myConn);
            MySqlDataReader myReader;

            try
            {
                myConn.Open();
                myReader = cmdDatabase.ExecuteReader();
                MessageBox.Show("Thank You");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          status_rumah_off(Convert.ToInt32(lbl_idRumah.Text));//kirim id_mobil ke fungsi untuk rubah status

            
            refresh_table_off(); 
            refresh_table_on();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            lbl_idRumah.Text = row.Cells["id_rumah"].Value.ToString();
            lbl_cluster_DT.Text = row.Cells["cluster"].Value.ToString();
            lbl_tipeRumah_DT.Text = row.Cells["tipe_rumah"].Value.ToString();          
           lbl_luasB_DT.Text = row.Cells["luas_bangunan"].Value.ToString();
           lbl_luasT_DT.Text = row.Cells["luas_tanah"].Value.ToString();
            harga_kpr_DT.Text = row.Cells["harga_KPR"].Value.ToString();
            harga_inhouse_DT.Text = row.Cells["harga_INHOUSE"].Value.ToString();
            lbl_status_DT.Text = row.Cells["status"].Value.ToString();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
           
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;password=";
            string Query = "SELECT * FROM prct_perumahan_citraland.dbase_customer where Nama ='" + comboBox1.Text + "';";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand(Query, myConn);
            MySqlDataReader myReader;

            try
            {
                myConn.Open();
                myReader = cmdDatabase.ExecuteReader();
                while (myReader.Read())
                {
                    string sID = myReader.GetString("id_customer").ToString();
                    label_id.Text = sID;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dbdataset);
            dv.RowFilter = string.Format("tipe_pembayaran LIKE '%{0}%'", textBox2.Text);
            dataGridView2.DataSource = dv;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        
            DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];

           lbl_id_Transaksi_Pall.Text = row.Cells["id_transaksi"].Value.ToString();
           lbl_id_rumah_Pcash.Text = row.Cells["id_rumah"].Value.ToString();
           lbl_tipe_pembayaran_Pcash.Text = row.Cells["tipe_pembayaran"].Value.ToString();
           lbl_nominal_tandajadi_Pcash.Text = row.Cells["nominal_tanda_jadi"].Value.ToString();

           textbox_nominal_DP_All.Text = row.Cells["uang_DP"].Value.ToString();
           textbox_nominal_cash_P.Text = row.Cells["nominal_cash"].Value.ToString();
           textbox_denda_P_all.Text = row.Cells["denda"].Value.ToString();

            //textBox_nominal_cicilan1.Text = row.Cells["nominal_cicilan_1"].Value.ToString();
            //textBox_nominal_cicilan2.Text = row.Cells["nominal_cicilan_2"].Value.ToString();
            //textBox_nominal_cicilan3.Text = row.Cells["nominal_cicilan_3"].Value.ToString();
              

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

      

        private void metroButton2_Click_1(object sender, EventArgs e)
        {
            try
            {
                long dp_cash = 0;

                long denda = 0;
                denda = Convert.ToInt64(textbox_denda_P_all.Text);

                long dp = 0;
                dp = Convert.ToInt64(textbox_nominal_DP_All.Text);

                long cash = 0;
                cash = Convert.ToInt64(textbox_nominal_cash_P.Text);

                //penjumlahan nominal dp dan nominal cash yang disetor
                dp_cash = dp + cash;
                lbl_Total_setoran2.Text = dp_cash.ToString();
          
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            string myConnection = "datasource=localhost;port=3306;username=root;password=";
            string Query = " UPDATE prct_perumahan_citraland.dbase_transaksi SET tanggal_beri_DP = '" + dateTimePicker_DP_all.Value.Date.ToString("yyyy-MM-dd") + "', uang_DP	= '" + textbox_nominal_DP_All.Text + "', denda = '" + textbox_denda_P_all.Text + "', tanggal_beri_uang_cash = '"+ dateTimePicker_Uang_cash.Text +"', Nominal_cash = '"+ textbox_nominal_cash_P.Text + "' WHERE id_transaksi = '" + lbl_id_Transaksi_Pall.Text + "'; ";
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
            refresh_table2();
        }

        private void groupBox2_Enter_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void tb_tipePembayaran_SelectedIndexChanged(object sender, EventArgs e)
        {
            long sisa = 0;
            long harga = Convert.ToInt64(harga_inhouse_DT.Text);
            double dp = harga*(1.3);
            long total = Convert.ToInt64(harga_inhouse_DT.Text) - Convert.ToInt64(textbox_nominal_TJ.Text);
            sisa = harga - Convert.ToInt64(textbox_nominal_TJ.Text);
            lbl_sisa_pembayaran.Text = Convert.ToString(sisa);
            lbl_total_dp.Text = Convert.ToString(dp);
            lbl_totalygharusdibayar.Text = harga_inhouse_DT.Text;
        }

        private void button_cicilan_Click(object sender, EventArgs e)
        {

        }
    }
}
