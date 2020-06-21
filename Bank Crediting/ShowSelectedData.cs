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
    public partial class ShowSelectedData : Form
    {
        string account = "";
        public ShowSelectedData(string acc)
        {
            InitializeComponent();
            account = acc;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Employee_Page employee = new Employee_Page(GlobalVariables.EmployeeId, GlobalVariables.EmployeeFirstName, GlobalVariables.EmployeeLastName);
            employee.ShowDialog();
        }

        private void ShowSelectedData_Load(object sender, EventArgs e)
        {
            int creditor_id = 0;
            //int[] guarantor_id=new int[2];
            int guarantor1_id = 0;
            int guarantor2_id = 0;
            int credit_type_id = 0;
            SqlConnection conn = SQLConnection.connect();
            conn.Open();
            string creditString = "Select client_id, date_of_issue, fully_repaid, credit_type_id, mother_amount from credits where account='" + account + "'";
            SqlCommand command_credit = new SqlCommand(creditString, conn);
            using (SqlDataReader reader = command_credit.ExecuteReader())
            {
                if (reader.Read())
                {
                    creditor_id = int.Parse(reader["client_id"].ToString());
                    credit_type_id= int.Parse(reader["credit_type_id"].ToString());
                    label6.Text = reader["date_of_issue"].ToString();
                    label8.Text = reader["mother_amount"].ToString();
                    label9.Text = account;
                    if ((bool)reader["fully_repaid"] == true)
                    {
                        label10.Text = "Yes";
                    }
                    else
                    {
                        label10.Text = "No";
                    }

                }
            }
            string credit_type = "Select name from types_of_crediting where id='" + credit_type_id + "'";
            SqlCommand command_credit_type = new SqlCommand(credit_type, conn);
            using (SqlDataReader reader = command_credit_type.ExecuteReader())
            {
                if (reader.Read())
                {
                    label7.Text = reader["name"].ToString();
                }
            }

            string creditorString = "Select name,type_of_property,costumer_address,phone,passport_series,social_card_number,workplace from customers where id='" + creditor_id + "'";
            SqlCommand command_creditor = new SqlCommand(creditorString, conn);
            using (SqlDataReader reader = command_creditor.ExecuteReader())
            {
                if (reader.Read())
                {
                    label18.Text = reader["name"].ToString();
                    label19.Text = reader["type_of_property"].ToString();
                    label20.Text = reader["costumer_address"].ToString();
                    label21.Text = reader["phone"].ToString();
                    label22.Text = reader["passport_series"].ToString();
                    label23.Text = reader["social_card_number"].ToString();
                    label24.Text = reader["workplace"].ToString();
                }
            }
            string creditor_guarantorString = "Select guarantor_id from creditor_guarantor where creditor_id='" + creditor_id + "'";
            SqlCommand command_creditor_guarantor = new SqlCommand(creditor_guarantorString, conn);
            using (SqlDataReader reader = command_creditor_guarantor.ExecuteReader())
            {
                int idx = 0;
                while (reader.Read() && idx < 2)
                {
                    if (idx == 0)
                    {
                        guarantor1_id= int.Parse(reader["guarantor_id"].ToString());
                    }
                    if (idx == 1)
                    {
                        guarantor2_id= int.Parse(reader["guarantor_id"].ToString());
                    }
                    idx++;
                } 
            }
            if (guarantor1_id != 0)
            {
                string guarantor1String = "Select name,type_of_property,costumer_address,phone,passport_series,social_card_number,workplace from customers where id='" + guarantor1_id + "'";
                SqlCommand command_guarantor1 = new SqlCommand(guarantor1String, conn);
                using (SqlDataReader reader = command_guarantor1.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        label32.Text = reader["name"].ToString();
                        label33.Text = reader["type_of_property"].ToString();
                        label34.Text = reader["costumer_address"].ToString();
                        label35.Text = reader["phone"].ToString();
                        label36.Text = reader["passport_series"].ToString();
                        label37.Text = reader["social_card_number"].ToString();
                        label38.Text = reader["workplace"].ToString();
                    }
                }
            }
            else
            {
                label32.Text = "";
                label33.Text = "";
                label34.Text = "";
                label35.Text = "";
                label36.Text = "";
                label37.Text = "";
                label38.Text = "";
            }
            if(guarantor2_id != 0)
            {
                string guarantor2String = "Select name,type_of_property,costumer_address,phone,passport_series,social_card_number,workplace from customers where id='" + guarantor2_id + "'";
                SqlCommand command_guarantor2 = new SqlCommand(guarantor2String, conn);
                using (SqlDataReader reader = command_guarantor2.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        label46.Text = reader["name"].ToString();
                        label47.Text = reader["type_of_property"].ToString();
                        label48.Text = reader["costumer_address"].ToString();
                        label49.Text = reader["phone"].ToString();
                        label50.Text = reader["passport_series"].ToString();
                        label51.Text = reader["social_card_number"].ToString();
                        label52.Text = reader["workplace"].ToString();
                    }
                }
            }
            else
            {
                label46.Text = "";
                label47.Text = "";
                label48.Text = "";
                label49.Text = "";
                label50.Text = "";
                label51.Text = "";
                label52.Text = "";
            }
        }
    }
}
