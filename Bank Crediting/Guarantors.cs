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
    public partial class Guarantors : Form
    {
        int client_id = 0;
        public Guarantors(int id)
        {
            InitializeComponent();
            client_id = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name1 = textBox1.Text;
            string type_of_property1 = textBox2.Text;
            string address1 = textBox3.Text;
            string phone1 = textBox4.Text;
            string passport_series1 = textBox5.Text;
            string social_card_number1 = textBox6.Text;
            string workplace1 = textBox7.Text;
            string guarantor1String = "INSERT INTO customers (name, type_of_property, costumer_address, phone, passport_series,social_card_number,workplace,is_guarantor) OUTPUT INSERTED.ID VALUES ('" + name1 + "', '" + type_of_property1 + "', '" + address1 + "', '" + phone1 + "', '" + passport_series1 + "', '" + social_card_number1 + "', '" + workplace1 + "', '"+ 1 + "')";
            SqlConnection conn = SQLConnection.connect();
            conn.Open();
            SqlCommand command1 = new SqlCommand(guarantor1String, conn);
            int guarantor1= (Int32)command1.ExecuteScalar(); 
            string name2 = textBox8.Text;
            string type_of_property2 = textBox9.Text;
            string address2 = textBox10.Text;
            string phone2 = textBox11.Text;
            string passport_series2 = textBox12.Text;
            string social_card_number2 = textBox13.Text;
            string workplace2 = textBox14.Text;
            string guarantor2String = "INSERT INTO customers (name, type_of_property, costumer_address, phone, passport_series,social_card_number,workplace, is_guarantor) OUTPUT INSERTED.ID VALUES ('" + name2 + "', '" + type_of_property2 + "', '" + address2 + "', '" + phone2 + "', '" + passport_series2 + "', '" + social_card_number2 + "', '" + workplace2 + "', '" + 1 + "')";
            SqlCommand command2 = new SqlCommand(guarantor2String, conn);
            int guarantor2= (Int32)command2.ExecuteScalar();
            string creditor_guarantor1 = "INSERT INTO creditor_guarantor (creditor_id, guarantor_id) VALUES ('" + client_id + "', '" + guarantor1 + "')";
            SqlCommand command21 = new SqlCommand(creditor_guarantor1, conn);
            command21.ExecuteNonQuery();
            string creditor_guarantor2 = "INSERT INTO creditor_guarantor (creditor_id, guarantor_id) VALUES ('" + client_id + "', '" + guarantor2 + "')";
            SqlCommand command22 = new SqlCommand(creditor_guarantor2, conn);
            command22.ExecuteNonQuery();
            Credit_Types credit_Types = new Credit_Types(client_id);
            this.Hide();
            credit_Types.ShowDialog();
        }
    }
}
