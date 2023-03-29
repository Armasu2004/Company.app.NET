using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LUCRU_INDIVIDUAL_1_2
{

    public partial class Sallary : Form
    {
        SqlConnection con;
        public Sallary()
        {
            InitializeComponent();
            string stringConnection = "Data Source=PC\\MSSQLSERVER01;Initial Catalog=databse_LI2;Integrated Security=True";
            con = new SqlConnection(stringConnection);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open(); // Se deschide conexiunea
                // Se verifica daca campurile nu sunbt nule
                if (textBox2.Text != null && textBox3.Text != null)
                {
                    // Se creaza querry-ul ca si in SQL
                    string querry = "INSERT INTO salary VALUES('" + textBox2.Text + "','" + textBox3.Text + "')";
                    // Cu ajutorul clasei SqlCommand prelucram querry-ul
                    SqlCommand cmd = new SqlCommand(querry, con);
                    // In aceasta secventa de cod punem sa executam querry-ul
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nu sau putut insera datele");
            }
            finally
            {
                con.Close(); // Se inchide conexiunea
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void printButton_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open(); // Se deschide conexiunea
                string querry = "SELECT * FROM salary"; // Se creaza querry-ul ca in SQL
                // Se creaza o variabila cu ajutorul clasei SqlCommand pentru a prelucra querry-ul
                SqlCommand cmd = new SqlCommand(querry, con);
                // Se creaza o variabila de tip DataTable pentru a putea lucra cu dataGridView
                DataTable table = new DataTable();
                // Se incarca tabelul cu datele cerute in querry
                table.Load(cmd.ExecuteReader());
                //Acest tabel creat se duce in datagridview
                dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                // Acest mesaj se afiseaza daca programul din try a avut o eroare
                MessageBox.Show("Nu se poate printa tabelul");
            }
            finally
            {
                con.Close(); // Se inchide conexiunea
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
