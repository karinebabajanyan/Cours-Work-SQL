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

namespace Bank_Crediting
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login=textBox1.Text;
            string password=textBox2.Text;
            SqlConnection conn = SQLConnection.connect();
            conn.Open();
            string selectString = "Select id,firstname,lastname from employee where username='" + login+ "' and pass='" + password+ "'";
            SqlCommand command = new SqlCommand(selectString, conn);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    GlobalVariables.EmployeeId = int.Parse(reader["id"].ToString());
                    GlobalVariables.EmployeeFirstName = reader["firstname"].ToString();
                    GlobalVariables.EmployeeLastName = reader["lastname"].ToString();
                        Employee_Page employee = new Employee_Page(GlobalVariables.EmployeeId, GlobalVariables.EmployeeFirstName, GlobalVariables.EmployeeLastName);
                        this.Hide();
                        employee.ShowDialog();
                } 
            }

            conn.Close();
        }
    }
}
