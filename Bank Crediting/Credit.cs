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
    public partial class Credit : Form
    {
        int customer_id = 0;
        int credit_type_id = 0;
        float interest_rate = 0;
        public Credit(int client_id,int type_id, int minimum_amount, int maximum_amount,float rate)
        {
            InitializeComponent();
            numericUpDown1.Maximum = maximum_amount;
            numericUpDown1.Minimum = minimum_amount;
            customer_id = client_id;
            credit_type_id = type_id;
            interest_rate = rate;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime date = Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            int amount = int.Parse(numericUpDown1.Value.ToString());
            string account = textBox1.Text;
            SqlConnection conn = SQLConnection.connect();
            conn.Open();
            string creditString = "INSERT INTO credits (client_id, date_of_issue, fully_repaid, credit_type_id, mother_amount, account) OUTPUT INSERTED.ID VALUES ('" + customer_id + "', '" + date + "', '" + 0 + "', '" + credit_type_id + "', '" + amount + "', '" + account + "')";
            SqlCommand command = new SqlCommand(creditString, conn);
            int credit_id = (Int32)command.ExecuteScalar();
            using (SqlCommand cmd = new SqlCommand("CalculateDay", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@credit_id", SqlDbType.Int).Value = credit_id;
                cmd.Parameters.Add("@credit_type_id", SqlDbType.Int).Value = credit_type_id;
                cmd.Parameters.Add("@credit_amount", SqlDbType.BigInt).Value = amount;
                cmd.Parameters.Add("@interest_rate", SqlDbType.Float).Value = interest_rate;

                cmd.ExecuteNonQuery();
                this.Hide();
                MessageBox.Show("This credit is successfully added.");
                Employee_Page employee = new Employee_Page(GlobalVariables.EmployeeId, GlobalVariables.EmployeeFirstName, GlobalVariables.EmployeeLastName);
                employee.ShowDialog();
            }
        }
    }
}
