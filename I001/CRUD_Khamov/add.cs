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
    public partial class add : Form
    {
        public add()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connect = @"Data Source=.\SQLEXPRESS;Initial Catalog=I001;Integrated Security=True;User ID = student; Password = Passw0rd";
            using (SqlConnection connection = new SqlConnection(connect))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = $"INSERT INTO Employees (LastName, FirstName, MiddleName, PhoneNumber) VALUES ('{textBoxLastName.Text}', '{textBoxFirstName.Text}', '{textBoxMiddleName.Text}','{textBoxPhoneNumber.Text}')";
                    cmd.ExecuteNonQuery();
                    this.Hide();
                    Form1 s = new Form1();
                    s.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Convert.ToString(ex));
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
