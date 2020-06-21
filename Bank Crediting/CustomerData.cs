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
    public partial class Customer_Data : Form
    {
        public Customer_Data()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string type_of_property = textBox2.Text;
            string address = textBox3.Text;
            string phone = textBox4.Text;
            string passport_series = textBox5.Text;
            string social_card_number = textBox6.Text;
            string workplace = textBox7.Text;
            string customerString= "INSERT INTO customers (name, type_of_property, costumer_address, phone, passport_series,social_card_number,workplace) OUTPUT INSERTED.ID VALUES ('" + name + "', '" + type_of_property + "', '" + address + "', '" + phone + "', '" + passport_series + "', '" + social_card_number + "', '" + workplace + "')";
            SqlConnection conn = SQLConnection.connect();
            conn.Open();
            SqlCommand command = new SqlCommand(customerString, conn);
            //command.ExecuteNonQuery();
            int client_id = (Int32)command.ExecuteScalar();
            if (checkBox1.Checked)
            {
                Guarantors guarantors = new Guarantors(client_id);
                this.Hide();
                guarantors.ShowDialog();
            }
            else
            {
                Credit_Types credit_Types = new Credit_Types(client_id);
                this.Hide();
                credit_Types.ShowDialog();
            }
        }
    }
}
