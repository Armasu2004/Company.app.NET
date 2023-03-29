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
    public partial class Departaments : Form
    {
        SqlConnection con;
        public Departaments()
        {
            InitializeComponent();
            string stringConnection = "Data Source=PC\\MSSQLSERVER01;Initial Catalog=databse_LI2;Integrated Security=True";
            con = new SqlConnection(stringConnection);
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open(); // Se deschide conexiunea
                string querry = "SELECT * FROM Departament"; // Se creaza querry-ul ca in SQL
                // Se creaza o variabila cu ajutorul clasei SqlCommand pentru a prelucra querry-ul
                SqlCommand cmd = new SqlCommand(querry, con);
                // Se creaza o variabila de tip DataTable pentru a putea lucra cu dataGridView
                DataTable table = new DataTable();
                // Se incarca tabelul cu datele cerute in querry
                table.Load(cmd.ExecuteReader());
                //Acest tabel creat se duce in datagridview
                DepList.DataSource = table;
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

        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open(); // Se deschide conexiunea
                // Se verifica daca campurile nu sunbt nule
                if (idTB.Text != null && DepNameTb.Text != null)
                {
                    // Se creaza querry-ul ca si in SQL
                    string querry = "INSERT INTO Departament VALUES('" + idTB.Text + "','" + DepNameTb.Text + "')";
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

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open(); // Se deschide conexiunea
                if (idTB.Text != null) // Se verifica ca id-ul sa nu fie null
                {
                    SqlCommand cmd = con.CreateCommand(); // Se creaza o variabila de tip SqlCommand
                    cmd.CommandType = CommandType.Text; // se seteaza pentru aceasta variabila ca sa prelucreze querry-uri
                    cmd.CommandText = "delete from Departament where id = '" + idTB.Text + "'"; // Se introduce querry-ul
                    cmd.ExecuteNonQuery(); // Se da la executie querry-ul
                }
            }
            catch (Exception ex)
            {
                // Acest mesaj se afiseaza daca programul din try nu a mers
                MessageBox.Show("Nu sa putut sterge campul ");
            }
            finally
            {
                con.Close(); // Se inchide conexiunea
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open(); // Se deschide conexiunea
                // Se creaza querry-ul, in querry se introduc niste variabile care nu au nici o valoarea
                // In using deja li se da valori
                string querry = "UPDATE Departament SET depName = @depName WHERE id = @id";
                using (SqlCommand command = new SqlCommand(querry, con))
                {
                    // Se dau valori variabilelor din querry
                    command.Parameters.AddWithValue("@depName", DepNameTb.Text);
                    command.Parameters.AddWithValue("@id", idTB.Text);
                    // Se executa querry-ul
                    int rowsAffected = command.ExecuteNonQuery();
                    MessageBox.Show("Datele au fost actualizate");
                }
            }
            catch (Exception ex)
            {
                // In caz ca programul din try nu a mers se afiseaza acest mesaj
                MessageBox.Show("Nu sau putut actualiza datele");
            }
            finally
            {
                con.Close(); // Se inchide conexiunea
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Employees form = new Employees();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Sallary form = new Sallary();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Employees form = new Employees();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Departaments form = new Departaments();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Departaments form = new Departaments();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

    }

