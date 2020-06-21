using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_Crediting
{
    public partial class Employee_Page : Form
    {
        int id_employee = 0;
        public Employee_Page(int id, string firstname, string lastname)
        {
            InitializeComponent();
            label1.Text = firstname + " " + lastname;
            id_employee = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Select_Customer_Data customer = new Select_Customer_Data("select");
            this.Hide();
            customer.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Customer_Data customer_data = new Customer_Data();
            this.Hide();
            customer_data.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Select_Customer_Data customer = new Select_Customer_Data("repayment");
            this.Hide();
            customer.ShowDialog();
        }
    }
}
