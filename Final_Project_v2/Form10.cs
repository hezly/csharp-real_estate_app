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
    public partial class Form10 : MetroFramework.Forms.MetroForm
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            timer1.Start();
            lbl_Date.Text = DateTime.Now.ToLongDateString();
            lbl_Time.Text = DateTime.Now.ToLongTimeString();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form7 run = new Form7();
            run.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 run = new Form5();
            run.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 run = new Form3();
            run.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form2 run = new Form2();
            run.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form8 run = new Form8();
            run.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_Time.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }
    }
}
