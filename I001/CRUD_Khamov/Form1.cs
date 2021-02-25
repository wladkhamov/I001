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

namespace CRUD_BAKUNOV
{
    public partial class Form1 : Form
    {
        string connect = @"Data Source=.\SQLEXPRESS;Initial Catalog=I001;Integrated Security=True;User ID = student; Password = Passw0rd";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            DataSet ds = new DataSet();
            SqlConnection dataBaseConnection = new SqlConnection(connect);
            dataBaseConnection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select e.LastName 'Фамилия', e.FirstName 'Имя', e.MiddleName 'Отчество', e.PhoneNumber 'Номер телефона' from Employees as e", dataBaseConnection);
            dataAdapter.Fill(ds, "Employees");
            dataGridView1.DataSource = ds.Tables["Employees"];
            dataGridView1.Rows[0].Selected = true;
            dataBaseConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1 || dataGridView1.SelectedCells.Count == 1)
            {
                int i = dataGridView1.CurrentRow.Index;
                int id;
                using (SqlConnection connection = new SqlConnection(connect))
                {
                    connection.Open();
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = $"select ID from Employees where LastName = '{dataGridView1[0, i].Value}'";
                    id = Convert.ToInt32(cmd.ExecuteScalar());
                }
                
                change c = new change(Convert.ToString(dataGridView1[0, i].Value), Convert.ToString(dataGridView1[1, i].Value), Convert.ToString(dataGridView1[2, i].Value), Convert.ToString(dataGridView1[3, i].Value), id);
                c.Show();
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            add a = new add();
            a.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            string lastName = Convert.ToString(dataGridView1[0, i].Value);
            string sqlDelete = $"Delete from Employees where LastName = '{lastName}'";
            using (SqlConnection dataBaseConnection = new SqlConnection(connect))
            {
                dataBaseConnection.Open();
                SqlCommand cmd = new SqlCommand(sqlDelete, dataBaseConnection);
                cmd.ExecuteNonQuery();
                dataGridView1.Rows.RemoveAt(i);
            }
        }
    }
}
