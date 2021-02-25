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
    public partial class change : Form
    {

        string connect = @"Data Source=.\SQLEXPRESS;Initial Catalog=I001;Integrated Security=True;User ID = student; Password = Passw0rd";
        private string LastName, FirstName, MiddleName, PhoneNumber;
        private int id;

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connect))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = $"Update Employees set LastName = '{textBoxLastName.Text}', FirstName = '{textBoxFirstName.Text}', MiddleName = '{textBoxMiddleName.Text}', " +
                    $"PhoneNumber = '{textBoxPhoneNumber.Text}' where ID = '{id}'";
                cmd.ExecuteNonQuery();
                this.Hide();
                Form1 f = new Form1();
                f.Show();
            }
        }

        public change()
        {
            InitializeComponent();
        }
        public change(string LastName, string FirstName, string MiddleName, string PhoneNumber, int id)
        {
            InitializeComponent();
            this.LastName = LastName;
            this.FirstName = FirstName;
            this.MiddleName = MiddleName;
            this.PhoneNumber = PhoneNumber;
            this.id = id;
        }

        private void change_Load(object sender, EventArgs e)
        {
            textBoxLastName.Text = LastName;
            textBoxFirstName.Text = FirstName;
            textBoxMiddleName.Text = MiddleName;
            textBoxPhoneNumber.Text = PhoneNumber;
        }
    }
}
