using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LUCRU_INDIVIDUAL_1_2
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void ad()
        {
            MessageBox.Show("Parola incorecta !!");
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Departaments departaments = new Departaments();
            string admin = "admin";
            string pass = "admin";
            if (textBox1.Text == admin && textBox2.Text == pass)
            {
                this.Hide();
                departaments.ShowDialog();
            }
            else ad();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
