using PL;
using System;
using System.Windows.Forms;

namespace UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            ModernStyleHelper.ApplyModernStyle(this);
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            AdminPanel adminForm = new AdminPanel();
            this.Hide();
            adminForm.FormClosed += Menu_FormClosed;
            adminForm.Show();

        }
        private void Menu_FormClosed(object? sender, FormClosedEventArgs e)
        {
            this.Show();
        }
        private void btnCashier_Click(object sender, EventArgs e)
        {

            OrderForm orderForm = new OrderForm();
            this.Hide();
            orderForm.FormClosed += Form_Closed;
            orderForm.Show();


        }
        
        private void Form_Closed(object? sender, FormClosedEventArgs e)
        {
            this.Show();
        }
    }
}