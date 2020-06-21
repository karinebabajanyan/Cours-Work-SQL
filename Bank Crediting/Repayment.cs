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
    public partial class Repayment : Form
    {
       
        int credit_type_id = 0;
        int credit_id = 0;
        int command_credit_payment_day_id = 0;
        float monthly_mother_amount = 0;
        float monthly_interest_amount = 0;
        DateTime payment_day = new DateTime();
        float surcharge_mother_amount = 0;
        float surcharge_interest_amount = 0;
        DateTime date = new DateTime();
        double mother_amount_surcharge = 0;
        double interest_amount_surcharge = 0;
        public Repayment(int credit,int type_id)
        {
            InitializeComponent();
            credit_type_id = type_id;
            credit_id = credit;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int sum = int.Parse(numericUpDown1.Value.ToString());
            
            if (int.Parse(date.Day.ToString())<= int.Parse(payment_day.Day.ToString()))
            {
                string repayment1String = "INSERT INTO repayment (credit_payment_day_id, credit_id, date_of_repayment, paid_mother_amounth, paid_interest_amounth, paid_prew_surcharge, surcharge_mother_amount, surcharge_interest_amount) VALUES ('" + command_credit_payment_day_id + "', '" + credit_id + "', '" + date + "', '" + 1 + "', '" + 1 + "', '" + 1 + "', '" + 0 + "', '" + 0 + "')";
                SqlConnection conn = SQLConnection.connect();
                conn.Open();
                SqlCommand command1 = new SqlCommand(repayment1String, conn);
                command1.ExecuteNonQuery();
            }
            else
            {
                float percentage_of_fines_for_each_day_mother_amount = 0;
                float percentage_of_fines_for_each_day_interest_amount = 0;
                //float mother_amount_surcharge = 0;
                //float interest_amount_surcharge = 0;
                int difference = int.Parse(date.Day.ToString()) - int.Parse(payment_day.Day.ToString());
                SqlConnection conn = SQLConnection.connect();
                conn.Open();
                string credit_typeString = "Select percentage_of_fines_for_each_day_mother_amount, percentage_of_fines_for_each_day_interest_amount from types_of_crediting where id='" + credit_type_id + "'";
                SqlCommand command_credit_type = new SqlCommand(credit_typeString, conn);
                using (SqlDataReader reader = command_credit_type.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        percentage_of_fines_for_each_day_mother_amount = float.Parse(reader["percentage_of_fines_for_each_day_mother_amount"].ToString());
                        percentage_of_fines_for_each_day_interest_amount = float.Parse(reader["percentage_of_fines_for_each_day_interest_amount"].ToString());
                    }
                }
                float monthly_mother_percent = (monthly_mother_amount * percentage_of_fines_for_each_day_mother_amount) / 100;
                
                float monthly_interest_percent = (monthly_interest_amount * percentage_of_fines_for_each_day_interest_amount) / 100;
              
               
                    mother_amount_surcharge = monthly_mother_percent * (float)difference;
                    interest_amount_surcharge = monthly_interest_percent * difference;

              
                string sql = "Insert into repayment (credit_payment_day_id, credit_id, date_of_repayment, paid_mother_amounth, paid_interest_amounth, paid_prew_surcharge, surcharge_mother_amount, surcharge_interest_amount) "
                                                + " values (@credit_payment_day_id, @credit_id, @date_of_repayment, @paid_mother_amounth, @paid_interest_amounth, @paid_prew_surcharge, @surcharge_mother_amount, @surcharge_interest_amount) ";

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;

                cmd.Parameters.Add("@credit_payment_day_id", SqlDbType.Int).Value = command_credit_payment_day_id;
                cmd.Parameters.Add("@credit_id", SqlDbType.Int).Value = credit_id;
                cmd.Parameters.Add("@date_of_repayment", SqlDbType.DateTime).Value = date;
                cmd.Parameters.Add("@paid_mother_amounth", SqlDbType.Bit).Value = 1;
                cmd.Parameters.Add("@paid_interest_amounth", SqlDbType.Bit).Value = 1;
                cmd.Parameters.Add("@paid_prew_surcharge", SqlDbType.Bit).Value = 1;
                cmd.Parameters.Add("@surcharge_mother_amount", SqlDbType.Float).Value = mother_amount_surcharge;
                cmd.Parameters.Add("@surcharge_interest_amount", SqlDbType.Float).Value = interest_amount_surcharge;

                // Execute Command (for Delete,Insert or Update).
                cmd.ExecuteNonQuery();
            }
            this.Hide();
            MessageBox.Show("This credit is successfully paid.");
            Employee_Page employee = new Employee_Page(GlobalVariables.EmployeeId, GlobalVariables.EmployeeFirstName, GlobalVariables.EmployeeLastName);
            employee.ShowDialog();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            date = Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            SqlConnection conn = SQLConnection.connect();
            conn.Open();
            string credit_payment_dayString = "Select id, payment_day, monthly_mother_amount, monthly_interest_amount from credit_payment_day where credit_id='" + credit_id + "' and Month(payment_day)='" + date.Month + "'and Year(payment_day)='" + date.Year +"'";
            SqlCommand command_credit_payment_day = new SqlCommand(credit_payment_dayString, conn);
            using (SqlDataReader reader = command_credit_payment_day.ExecuteReader())
            {
                if (reader.Read())
                {
                    command_credit_payment_day_id = int.Parse(reader["id"].ToString());
                    payment_day = Convert.ToDateTime(reader["payment_day"].ToString());
                    monthly_mother_amount = float.Parse(reader["monthly_mother_amount"].ToString());
                    monthly_interest_amount = float.Parse(reader["monthly_interest_amount"].ToString());
                }
            }
            int payment_day_month = int.Parse(date.Month.ToString()) - 1;
            string repaymentString = "Select surcharge_mother_amount, surcharge_interest_amount from repayment where credit_id='" + credit_id + "' and Month(date_of_repayment)='" + payment_day_month + "'and Year(date_of_repayment)='"+ date.Year +"'";
            SqlCommand command_repayment = new SqlCommand(repaymentString, conn);
            using (SqlDataReader reader = command_repayment.ExecuteReader())
            {
                if (reader.Read())
                {
                    try
                    {
                        surcharge_mother_amount = (float)reader["surcharge_mother_amount"];
                        surcharge_interest_amount = (float)reader["surcharge_interest_amount"];
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                    
                }
            }

            float all_amount = monthly_mother_amount + monthly_interest_amount + surcharge_mother_amount+ surcharge_interest_amount;
            string str = Math.Round(all_amount, MidpointRounding.AwayFromZero).ToString();
            int last = int.Parse(str.Substring(str.Length - 1));
            int balance = 0;
            if (last != 0)
            {
                balance = 10 - last;
            }
            if (last == 0)
            {
                balance = 10;
            }
            int amount = (int)Math.Round(all_amount, MidpointRounding.AwayFromZero)+balance;
            numericUpDown1.Minimum = amount;
        }
    }
}
