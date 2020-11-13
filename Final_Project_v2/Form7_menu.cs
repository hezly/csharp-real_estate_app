using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project_v2
{
    public partial class Form7_menu : MetroFramework.Forms.MetroForm
    {
        public Form7_menu()
        {
            InitializeComponent();
            Timer tim = new Timer();
            tim.Interval = 2000;
            tim.Tick += new EventHandler(ChangeImageForSlide);
            tim.Start();
        }

        private void Form7_menu_Load(object sender, EventArgs e)
        {
            metroPanel2.Hide();
            metroPanel3.Hide();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            
            metroPanel2.Show();

            if (metroPanel2.Height < 247)
            {
                metroPanel2.Height = 380;
            }
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (metroPanel1.Width < 233)
            {
                metroPanel1.Width = metroPanel1.Width + 200;
                pictureBox2.Visible = false;
            }
          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            if (metroPanel1.Width > 33)
            {
                metroPanel1.Width = metroPanel1.Width - 200;
                pictureBox2.Visible = true;
            }
         
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {

            metroPanel1.Show();
            
        }

        private void metroPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroPanel3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void ChangeImageForSlide(object sender, EventArgs e)
        {
            List<Bitmap> b1 = new List<Bitmap>();
            b1.Add(Properties.Resources.untitled);
            b1.Add(Properties.Resources.untitled1);
            b1.Add(Properties.Resources.untitled2);
            int index = DateTime.Now.Second % b1.Count;
            pictureBox4.Image = b1[index];
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            metroPanel3.Show();
            metroPanel1.Show();

            if (metroPanel3.Height < 247)
            {
                metroPanel3.Height = 380;
            }
            metroPanel2.Hide();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            //  MetroFramework.MetroMessageBox.Show(this, "Do You Want to Close" , "message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            var back = MetroFramework.MetroMessageBox.Show(this, "\n\nAnda yakin untuk keluar dari Akun ini ?", "Keluar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (back == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
              /*  Form1 obj = new Form1();
                obj.Show();

                if (MessageBox.Show("Apakah anda yakin untuk keluar dari akun ini?", "Keluar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Exit();
                }*/
                
            }

        }
    }
}
