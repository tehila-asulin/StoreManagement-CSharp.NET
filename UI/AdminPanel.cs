using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UI
{
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            CustomersForm customersForm = new CustomersForm();
            this.Hide();
            customersForm.FormClosed += Form_Closed;
            customersForm.Show();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            ProductsForm productsForm = new ProductsForm();
            this.Hide();
            productsForm.FormClosed += Form_Closed;
            productsForm.Show();
        }

        private void btnDeals_Click(object sender, EventArgs e)
        {
             SalesForm salesForm = new SalesForm();
             this.Hide();
            salesForm.FormClosed += Form_Closed;
            salesForm.Show();
        }
       

        private void Form_Closed(object? sender, FormClosedEventArgs e)
        {
            this.Show();
        }
    }
}
