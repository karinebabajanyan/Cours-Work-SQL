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
    public partial class Credit_Types : Form
    {
        int client_id = 0;
        public Credit_Types(int id)
        {
            InitializeComponent();
            client_id = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string unicName="";
            int credit_type_id = 0;
            int maximum_amount = 0;
            int minimum_amount = 0;
            if (radioButton1.Checked == true)
            {
                unicName = "cc01";
            }
            else if (radioButton2.Checked == true)
            {
                unicName = "lc12";
            }
            else if (radioButton3.Checked == true)
            {
                unicName = "mc02";
            }
            else
            {
                unicName = "bcc3";
            }
            SqlConnection conn = SQLConnection.connect();
            conn.Open();
            string selectString = "Select id,minimum_amount,maximum_amount,interest_rate from types_of_crediting where unic_name='" + unicName +"'";
            SqlCommand command = new SqlCommand(selectString, conn);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    credit_type_id = int.Parse(reader["id"].ToString());
                    string min = Convert.ToString(reader["minimum_amount"]);
                    string max = Convert.ToString(reader["maximum_amount"]);
                    float interest_rate = float.Parse(reader["interest_rate"].ToString());
                    if (min == "")
                    {
                        minimum_amount = 0;
                    }
                    else
                    {
                        minimum_amount = int.Parse(min);
                    }
                    maximum_amount = int.Parse(max);
                    Credit credit = new Credit(client_id, credit_type_id, minimum_amount, maximum_amount, interest_rate);
                    this.Hide();
                    credit.ShowDialog();
                }
            }
            conn.Close();
        }
    }
}
