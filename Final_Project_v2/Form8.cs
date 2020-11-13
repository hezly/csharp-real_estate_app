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
using System.Drawing.Printing;

namespace Final_Project_v2
{
    public partial class Form8 : MetroFramework.Forms.MetroForm
    {
        public Form8()
        {
            InitializeComponent();
        }
        DataTable dbdataset;
        private void Form8_Load(object sender, EventArgs e)
        {
            cb_tipePembayaran.Items.Add("Cash");
            cb_tipePembayaran.Items.Add("Cicil");
            fillCombo();
            refresh_table1();
            refresh_table_pembayaran();
            refresh_table_log();
        }
        void status_transaksi_off() //Mengurangi jumlah status rumah yang belum terjual
        {
            long status = Convert.ToInt64(lbl_sisa_pembayaran2.Text);
            if (status == 0)
            {
                //connection 
                string myConnection = "datasource=localhost;port=3306;username=root;password=";
                string Query = "UPDATE prct_perumahan_citraland.dbase_transaksi SET status= '" + 1 + "' WHERE  id_transaksi ='" + lbl_id_Transaksi_Pall.Text + "';";
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
        }
        public void hitungCash()
        {
            long sisa_pembayaran = Convert.ToInt64(lbl_sisa_pembayaran2.Text); //Sisa yang belum dibayar sebelum cash
            long kembalianCash = 0; //Sisa uang pelanggan dari membayar cash
            long uangCash = Convert.ToInt64(textBox_uangCash.Text); //Uang pelanggan
            
            textbox_nominal_cash_P.Text = Convert.ToString(sisa_pembayaran); //tampilkan textbox_nominal_cash.Text = sisa pembayaran
            kembalianCash = uangCash - sisa_pembayaran; //uang untuk kembalian kepada customer
            label_kembalianCash.Text = kembalianCash.ToString(); //tampilkan uang kembalian pada label_kembalianCash.Text
            
        }
        public void hitungDP()
        {
            //menghitung dp
            long harga = Convert.ToInt64(label_harga.Text);
            double dp = harga * (0.3);
            textbox_nominal_DP_All.Text = Convert.ToString(dp);
            //menghitung sisa pembayaran
            //long sisaPem = Convert.ToInt64(lbl_sisa_pembayaran2.Text);
            //long sisa = sisaPem - Convert.ToInt64(dp);
            //lbl_sisa_pembayaran2.Text = sisa.ToString();

        }
        public void hitungDenda()
        {
            try
            {
                int denda = 0;
                DateTime tanggal1;
                DateTime tanggal2;
                int hari = 0;
                TimeSpan ts = new TimeSpan();

               // tanggal1 = ;
                tanggal2 = DateTime.Now;
               // ts = tanggal2.Subtract(tanggal1); //count days using substract              
                hari = Convert.ToInt32(ts.Days + 1);

                //count total denda
                int count = 0;
                count = hari / 30 - 1;
                if (count > 0)
                {
                    denda = 100000 * count;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Anda Belum Memilih Mobil....");
            }
        }
        public void refresh_table1()
        {
            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;password=";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_rumah, Cluster, tipe_rumah, luas_bangunan, luas_tanah, harga_KPR, harga_INHOUSE, status FROM prct_perumahan_citraland.dbase_rumah where status>0;", myConn);
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
        public void refresh_table_pembayaran()
        {
            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;password=";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_transaksi, id_rumah,id_customer, tipe_pembayaran, nominal_tanda_jadi, uang_DP, nominal_cash, nominal_cicilan_1, nominal_cicilan_2, nominal_cicilan_3,harga,total_pembayaran,sisa_pembayaran, denda,tanggal_tanda_jadi,status FROM prct_perumahan_citraland.dbase_transaksi WHERE status ='"+ 0 +"';", myConn);
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
        public void refresh_table_log()
        {
            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;password=";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand("SELECT id_transaksi, id_rumah,id_customer, tipe_pembayaran, nominal_tanda_jadi, uang_DP, nominal_cash, nominal_cicilan_1, nominal_cicilan_2, nominal_cicilan_3,harga,total_pembayaran,sisa_pembayaran, denda,tanggal_tanda_jadi,status FROM prct_perumahan_citraland.dbase_transaksi;", myConn);
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDatabase;
                dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                dataGridView3.DataSource = bSource;
                sda.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void status_rumah_off(int id_rumah) //Mengurangi jumlah status rumah yang belum terjual
        {
            int status = Convert.ToInt32(lbl_status_DT.Text);
            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;password=";
            string Query = "UPDATE prct_perumahan_citraland.dbase_rumah SET status= '"+ (status-1) + "' WHERE  id_rumah='" + id_rumah + "';";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            lbl_idRumah.Text = row.Cells["id_rumah"].Value.ToString();
            lbl_cluster_DT.Text = row.Cells["cluster"].Value.ToString();
            lbl_tipeRumah_DT.Text = row.Cells["tipe_rumah"].Value.ToString();
            lbl_luasB_DT.Text = row.Cells["luas_bangunan"].Value.ToString();
            lbl_luasT_DT.Text = row.Cells["luas_tanah"].Value.ToString();
            harga_inhouse_DT.Text = row.Cells["harga_INHOUSE"].Value.ToString();
            lbl_status_DT.Text = row.Cells["status"].Value.ToString();
        }

        private void cb_tipePembayaran_SelectedIndexChanged(object sender, EventArgs e)
        {
            long sisa = 0;
            long harga = Convert.ToInt64(harga_inhouse_DT.Text);
            double dp = harga * (0.3);
            long total = Convert.ToInt64(harga_inhouse_DT.Text) - Convert.ToInt64(textbox_nominal_TJ.Text);
            sisa = harga - Convert.ToInt64(textbox_nominal_TJ.Text);
            lbl_sisa_pembayaran.Text = Convert.ToString(sisa);
            lbl_total_dp.Text = Convert.ToString(dp);
            lbl_totalygharusdibayar.Text = harga_inhouse_DT.Text;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;password=";

            string Query = "INSERT INTO prct_perumahan_citraland.dbase_transaksi (id_transaksi, id_rumah, tipe_pembayaran, tanggal_tanda_jadi, nominal_tanda_jadi, sisa_pembayaran,Harga,id_customer,total_pembayaran)  VALUES(NULL,  '" + lbl_idRumah.Text + "','" + cb_tipePembayaran.Text + "','" + date_tanda_jadi.Value.Date.ToString("yyyy-MM-dd") + "', '" + textbox_nominal_TJ.Text + "','" + lbl_sisa_pembayaran.Text + "','"+ lbl_totalygharusdibayar.Text + "','"+ label_id.Text + "','"+ textbox_nominal_TJ.Text + "'); ";

            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand(Query, myConn);
            MySqlDataReader myReader;

            try
            {
                myConn.Open();
                myReader = cmdDatabase.ExecuteReader();
                MessageBox.Show("Berhasil!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            status_rumah_off(Convert.ToInt32(lbl_idRumah.Text));//kirim id_mobil ke fungsi untuk rubah status

            refresh_table1();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            string myConnection = "datasource=localhost;port=3306;username=root;password=";
            string Query = " UPDATE prct_perumahan_citraland.dbase_transaksi SET tanggal_beri_DP = '" + dateTimePicker_DP_all.Value.Date.ToString("yyyy-MM-dd") + "', uang_DP	= '" + textbox_nominal_DP_All.Text + "', denda = '" + textbox_denda_P_all.Text + "',total_pembayaran = '"+ (Convert.ToInt64(lbl_Total_setoran2.Text)+Convert.ToInt64(textbox_nominal_DP_All.Text)) + "',sisa_pembayaran = '" + (Convert.ToInt64(lbl_sisa_pembayaran2.Text) - Convert.ToInt64(textbox_nominal_DP_All.Text)) + "'  WHERE id_transaksi = '" + lbl_id_Transaksi_Pall.Text + "'; ";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand(Query, myConn);
            MySqlDataReader myReader;

            try
            {
                myConn.Open();
                myReader = cmdDatabase.ExecuteReader();
                MessageBox.Show("Pembayaran DP Berhasil!");
                while (myReader.Read())
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            hitungDP();
            refresh_table_pembayaran();
        }

        private void btn_bayar_cash_Click(object sender, EventArgs e)
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dbdataset);
            dv.RowFilter = string.Format("id_customer LIKE '%{0}%'", textBox2.Text);
            dataGridView2.DataSource = dv;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];

            lbl_id_Transaksi_Pall.Text = row.Cells["id_transaksi"].Value.ToString();
            lbl_id_rumah_Pcash.Text = row.Cells["id_rumah"].Value.ToString();
            lbl_tipe_pembayaran_Pcash.Text = row.Cells["tipe_pembayaran"].Value.ToString();
            textbox_nominal_DP_All.Text = row.Cells["uang_DP"].Value.ToString();
            textbox_nominal_cash_P.Text = row.Cells["nominal_cash"].Value.ToString();
            textbox_denda_P_all.Text = row.Cells["denda"].Value.ToString();
            label_tgl_jadi.Text = row.Cells["tanggal_tanda_jadi"].Value.ToString();
            label_harga.Text = row.Cells["Harga"].Value.ToString();
            lbl_Total_setoran2.Text = row.Cells["total_pembayaran"].Value.ToString();
            hitungDP();
            lbl_sisa_pembayaran2.Text = row.Cells["sisa_pembayaran"].Value.ToString();
            textbox_nominal_cash_P.Text = lbl_sisa_pembayaran2.Text;
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            refresh_table1();
        }

        private void btn_refresh2_Click(object sender, EventArgs e)
        {
            refresh_table_pembayaran();
        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            hitungDP();
            //
            long sisa = 0;
            long harga = Convert.ToInt64(label_harga.Text);
            double dp = harga * (0.3);
            long total = Convert.ToInt64(label_harga.Text) - Convert.ToInt64(textbox_nominal_TJ.Text);
            sisa = harga - Convert.ToInt64(textbox_nominal_TJ.Text);
            lbl_sisa_pembayaran2.Text = Convert.ToString(sisa);
            lbl_total_dp.Text = Convert.ToString(dp);
            lbl_totalygharusdibayar.Text = label_harga.Text;

            //Kembalian dari pembayaran DP
            long uang = Convert.ToInt64(textBox_uang.Text);
            long kembalian = 0;
            kembalian = uang - Convert.ToInt64(dp);
            label_kembalian.Text = kembalian.ToString();
        }

        private void btn_bayar_cash_Click_1(object sender, EventArgs e)
        {
            hitungCash();
            string myConnection = "datasource=localhost;port=3306;username=root;password=";
            string Query = " UPDATE prct_perumahan_citraland.dbase_transaksi SET Tanggal_beri_uang_cash = '" + dateTimePicker_Uang_cash.Value.Date.ToString("yyyy-MM-dd") +"', denda = '" + textbox_denda_P_all.Text + "',total_pembayaran = '" + (Convert.ToInt64(lbl_Total_setoran2.Text) + Convert.ToInt64(textbox_nominal_cash_P.Text)) + "',sisa_pembayaran = '" + (Convert.ToInt64(lbl_sisa_pembayaran2.Text) - Convert.ToInt64(textbox_nominal_cash_P.Text)) + "'  WHERE id_transaksi = '" + lbl_id_Transaksi_Pall.Text + "'; ";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand(Query, myConn);
            MySqlDataReader myReader;

            try
            {
                myConn.Open();
                myReader = cmdDatabase.ExecuteReader();
                MessageBox.Show("Pembayaran DP Berhasil!");
                while (myReader.Read())
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            status_transaksi_off();
            refresh_table_pembayaran();

        }

        private void btn_cek_Click(object sender, EventArgs e)
        {

        }

        private void metroButton2_Click_1(object sender, EventArgs e)
        {
            string myConnection = "datasource=localhost;port=3306;username=root;password=";
            string Query = " DELETE FROM prct_perumahan_citraland.dbase_transaksi WHERE id_transaksi = '" + label_idTransaksi.Text + "'; ";
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
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView3.Rows[e.RowIndex];
            label_idTransaksi2.Text = row.Cells["id_transaksi"].Value.ToString();
            label_idRumah.Text = row.Cells["id_rumah"].Value.ToString();
            id_customer.Text = row.Cells["id_customer"].Value.ToString();
            label_tipePembayaran.Text = row.Cells["tipe_pembayaran"].Value.ToString();
            label_tgl_tanda_jadi.Text = row.Cells["tanggal_tanda_jadi"].Value.ToString();
            label_nominal_tanda_jadi.Text = row.Cells["nominal_tanda_jadi"].Value.ToString();
            label_tgl_tanda_jadi.Text = row.Cells["tanggal_tanda_jadi"].Value.ToString();
            label_uangDP.Text = row.Cells["uang_DP"].Value.ToString();
            //label_tgl_sisa_pembayaran.Text = row.Cells["Tanggal_beri_uang_cash"].Value.ToString();
            label_harga_rumah.Text = row.Cells["harga"].Value.ToString();
            label_total_pembayaran.Text = row.Cells["total_pembayaran"].Value.ToString();
            label_sisa_pembayaran.Text = row.Cells["sisa_pembayaran"].Value.ToString();
            //label_id_kasir.Text = row.Cells["id_kasir"].Value.ToString();
            label_status.Text = row.Cells["status"].Value.ToString();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Form10 run = new Form10();
            run.Show();
            this.Hide();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1170);
                pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
                pd.Print();

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while printing", ex.ToString());
            }
        }
        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            ev.Graphics.DrawString("Citraland", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, 20, 30);
            ev.Graphics.DrawString("===================", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, 20, 50);
            ev.Graphics.DrawString("Struk Pembayaran", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, 20, 50);
            ev.Graphics.DrawString("===================", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, 20, 50);
            ev.Graphics.DrawString(" " + DateTime.Now.ToString() + "", new Font("Times New Roman", 20, FontStyle.Bold), Brushes.Black, 20, 150);
            ev.Graphics.DrawString("     ID Transaksi = " + label_idTransaksi2.Text.ToString() + "", new Font("Times New Roman", 20, FontStyle.Bold), Brushes.Black, 20, 150);
            ev.Graphics.DrawString("     ID Rumah = " + label_idRumah.Text.ToString() + "", new Font("Times New Roman", 20, FontStyle.Bold), Brushes.Black, 20, 150);
            ev.Graphics.DrawString("     Tipe Pembayaran = " + label_tipePembayaran.Text.ToString() + "", new Font("Times New Roman", 20, FontStyle.Bold), Brushes.Black, 20, 150);
            ev.Graphics.DrawString("     Harga Rumah = " + label_harga_rumah.Text.ToString() + "", new Font("Times New Roman", 20, FontStyle.Bold), Brushes.Black, 20, 150);
            ev.Graphics.DrawString("     Total Pembayaran = " + label_total_pembayaran.Text.ToString() + "", new Font("Times New Roman", 20, FontStyle.Bold), Brushes.Black, 20, 150);
            int status = Convert.ToInt32(label_status.Text);
            if (status == 1)
            {
                ev.Graphics.DrawString("Status = Lunas", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, 20, 50);
            }
            else
            {
                ev.Graphics.DrawString("Status = Belum Lunas", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, 20, 50);
            }
            /* if (t < 2)
             {
                 t++;
                 if(t<2)
                 { 
                     ev.HasMorePages = true;
                 }
                 else
                 {
                     ev.HasMorePages = false;
                 }
             }*/
        }
    }
}
