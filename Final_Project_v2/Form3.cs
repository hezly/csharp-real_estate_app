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
using System.IO;

namespace Final_Project_v2
{
    public partial class Form3 : MetroFramework.Forms.MetroForm
    {
        public Form3()
        {
            InitializeComponent();
        }
        DataTable dbdataset;
        public void refresh_table()
        {
            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;password=";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand("SELECT* FROM prct_perumahan_citraland.dbase_rumah;", myConn);
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
      
        private void Form3_Load(object sender, EventArgs e)
        {
            refresh_table();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];

            id_rumah.Text = row.Cells["id_rumah"].Value.ToString();
            lbl_cluster_D.Text = row.Cells["Cluster"].Value.ToString();
            lbl_tipeRumah_D.Text = row.Cells["tipe_rumah"].Value.ToString();
            lbl_luasB_D.Text = row.Cells["luas_bangunan"].Value.ToString();
            lbl_luasT_D.Text = row.Cells["luas_tanah"].Value.ToString();
            lbl_StrukturB_D.Text = row.Cells["struktur_bangunan"].Value.ToString();
            lbl_pondasi_D.Text = row.Cells["pondasi"].Value.ToString();
            lbl_dinding_D.Text = row.Cells["dinding"].Value.ToString();
            lbl_Atap_D.Text = row.Cells["atap"].Value.ToString();
            lbl_rangkaA_D.Text = row.Cells["rangka_atap"].Value.ToString();
            lbl_plafon_D.Text = row.Cells["plafon"].Value.ToString();
            lbl_lantai_D.Text = row.Cells["lantai"].Value.ToString();
            lbl_sinitair_D.Text= row.Cells["sinitair"].Value.ToString();
            lbl_kusen_D.Text = row.Cells["kusen"].Value.ToString();
            lbl_pintu_D.Text = row.Cells["pintu_dan_jendela"].Value.ToString();
            lbl_listrik_D.Text = row.Cells["listrik"].Value.ToString();
            lbl_instalasiA_D.Text = row.Cells["instalasi_air"].Value.ToString();
            lbl_hargaKPR_D.Text = row.Cells["harga_KPR"].Value.ToString();
            lbl_harga_Inhouse_D.Text = row.Cells["harga_INHOUSE"].Value.ToString();
            lbl_Status_D.Text = row.Cells["status"].Value.ToString();


            var data1 = (byte[])(row.Cells["gambar1"].Value);
            var stream1 = new MemoryStream(data1);
            pictureBox1.Image = Image.FromStream(stream1);
            
        }

    private void textBox1_TextChanged(object sender, EventArgs e)
        {

            DataView dv = new DataView(dbdataset);
            dv.RowFilter = string.Format("Cluster LIKE '%{0}%'", textBox1.Text);
            dataGridView2.DataSource = dv;

        }

        private void lbl_cluster_D_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroTabPage2_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel25_Click(object sender, EventArgs e)
        {

        }

        private void lbl_rangkaA_D_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void lbl_luasT_D_Click(object sender, EventArgs e)
        {

        }

        private void lbl_harga_Inhouse_D_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Form8 run = new Form8();
            run.Show();
            this.Hide();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Form10 run = new Form10();
            run.Show();
            this.Hide();
        }
    }
}
