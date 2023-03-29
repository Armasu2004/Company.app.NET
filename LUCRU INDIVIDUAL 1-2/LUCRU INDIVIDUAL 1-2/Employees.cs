using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LUCRU_INDIVIDUAL_1_2
{
    public partial class Employees : Form
    {
        SqlConnection con;
        public Employees()
        {
            InitializeComponent();
            string stringConnection = "Data Source=PC\\MSSQLSERVER01;Initial Catalog=databse_LI2;Integrated Security=True";
            con = new SqlConnection(stringConnection);
        }

       

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open(); // Se deschide conexiunea
                string querry = "SELECT * FROM Employ"; // Se creaza querry-ul ca in SQL
                // Se creaza o variabila cu ajutorul clasei SqlCommand pentru a prelucra querry-ul
                SqlCommand cmd = new SqlCommand(querry, con);
                // Se creaza o variabila de tip DataTable pentru a putea lucra cu dataGridView
                DataTable table = new DataTable();
                // Se incarca tabelul cu datele cerute in querry
                table.Load(cmd.ExecuteReader());
                //Acest tabel creat se duce in datagridview
                datagriedemplpyee.DataSource = table;
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open(); // Open the database connection

                // Create the SQL INSERT statement with parameters
                string query = "INSERT INTO Employ (id, nume, gen, departament, data_nasterii, join_date, salariu) " +
                               "VALUES (@id, @nume, @gen, @depemp, @dob, @joindate, @salary)";

                // Create a new SqlCommand object with the SQL statement and the database connection
                SqlCommand command = new SqlCommand(query, con);

                // Add the parameter values to the SqlCommand object
                command.Parameters.AddWithValue("@id", idTB.Text);
                command.Parameters.AddWithValue("@nume", numeTB.Text);
                command.Parameters.AddWithValue("@gen", gender.SelectedItem.ToString());
                command.Parameters.AddWithValue("@depemp", depEmp.Text);
                command.Parameters.AddWithValue("@dob", DOB.Value);
                command.Parameters.AddWithValue("@joindate", joindate.Value);
                command.Parameters.AddWithValue("@salary", empDaySalar.Text);

                // Execute the SQL INSERT statement
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Datele au fost inserate cu succes!");
                }
                else
                {
                    MessageBox.Show("Nu s-a reușit inserarea datelor.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la inserarea datelor: " + ex.Message);
            }
            finally
            {
                con.Close(); // Close the database connection
            }
        }

       

        private void label11_Click(object sender, EventArgs e)
        {
            Departaments form = new Departaments();
            this.Hide();
            form.ShowDialog();
            form.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idTB.Text);
            string nume = numeTB.Text;
            string gen = gender.SelectedItem.ToString();
            int depemp = Convert.ToInt32(depEmp.Text);
            DateTime value = DOB.Value;
            DateTime join = joindate.Value;
            int salar = Convert.ToInt32(empDaySalar.Text);

            string query = "UPDATE Employ SET id = @id, nume = @nume, gen = @gen, departament = @depemp, data_nasterii = @value, join_date = @join, salariu = @salar WHERE id = @id";

            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@nume", nume);
                command.Parameters.AddWithValue("@gen", gen);
                command.Parameters.AddWithValue("@depemp", depemp);
                command.Parameters.AddWithValue("@value", value);
                command.Parameters.AddWithValue("@join", join);
                command.Parameters.AddWithValue("@salar", salar);

                con.Open();
                int rowsAffected = command.ExecuteNonQuery();
                MessageBox.Show("Datele au fost actualizate");
                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idTB.Text);
            string query = "DELETE FROM Employ  WHERE Id = @id";
            
            using (SqlCommand command = new SqlCommand(query, con))
            {

                command.Parameters.AddWithValue("@id", id);

                con.Open();
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine($"Deleted {rowsAffected} rows.");
                }
                else
                {
                    Console.WriteLine($"No rows were deleted for person with Id = {id}.");
                }
                con.Close();
            }
        }


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Departaments form = new Departaments();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Employees form = new Employees();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void datagriedemplpyee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
