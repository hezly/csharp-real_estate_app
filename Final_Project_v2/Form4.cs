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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();


        }
        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            
           
        }
        private void ChangeImageForSlide(object sender, EventArgs e)
        {
        
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (panel1.Width < 255)
            {
                panel1.Width = panel1.Width + 197;
                pictureBox2.Visible = false;
            }

                
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
      

        }
           
        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            panel3.Show();

            if (panel3.Height < 380)
            {
                panel3.Height = 380;
            }
         
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
          
         
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            if (panel1.Width > 58)
            {
                panel1.Width = panel1.Width - 197;
                pictureBox2.Visible = true;
            }
         
              
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            panel3.Hide();
           
           
        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

      

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint_1(object sender, PaintEventArgs e)
        {

            this.Hide();
           Form2 obj = new Form2();
            obj.Show();
        }
    }
}
