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
    public partial class Select_Customer_Data : Form
    {
        string incidentificate = "";
        public Select_Customer_Data(string incidenty)
        {
            InitializeComponent();
            incidentificate = incidenty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string account = textBox1.Text;
            if (incidentificate == "select")
            {
                ShowSelectedData showSelectedData = new ShowSelectedData(account);
                this.Hide();
                showSelectedData.ShowDialog();
            }
            if(incidentificate == "repayment")
            {
                int credit_id = 0;
                int credit_type_id = 0;
                SqlConnection conn = SQLConnection.connect();
                conn.Open();
                string creditString = "Select id, credit_type_id from credits where account='" + account + "'";
                SqlCommand command_credit = new SqlCommand(creditString, conn);
                using (SqlDataReader reader = command_credit.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        credit_id = int.Parse(reader["id"].ToString());
                        credit_type_id = int.Parse(reader["credit_type_id"].ToString());
                    }
                }
                Repayment repayment = new Repayment(credit_id, credit_type_id);
                this.Hide();
                repayment.ShowDialog();
            }
        }
    }
}
