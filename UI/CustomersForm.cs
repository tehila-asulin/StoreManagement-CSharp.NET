using System;
using System.Linq;
using System.Windows.Forms;
using BlApi;
using BO;

namespace UI
{
    public partial class CustomersForm : Form
    {
        private readonly IBl bl = Factory.Get();

        public CustomersForm()
        {
            InitializeComponent();
            LoadData();
        }

 
        private void LoadData(string filter = "")
        {
            var customers = string.IsNullOrWhiteSpace(filter)
                ? bl.customer.ReadAll()
                : bl.customer.ReadAll(c => c.Name.Contains(filter, StringComparison.OrdinalIgnoreCase));

            dataGridView1.DataSource = customers.Select(c => new { c.Id, c.Name, c.Phone }).ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bl.customer.Create(new Customer(
                int.Parse(txtId.Text),
                txtName.Text,
                int.Parse(txtPhone.Text),
                txtAddress.Text));
            LoadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var id = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;
            bl.customer.Update(new Customer(
                id,
                txtName.Text,
                int.Parse(txtPhone.Text),
                txtAddress.Text));
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (int.TryParse(txtId.Text, out int id))
            {
                try
                {
                    bl.customer.Delete(id);
                    LoadData();
                    MessageBox.Show("הלקוח נמחק בהצלחה.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("אירעה שגיאה בעת המחיקה: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("יש להכניס תעודת זהות תקנית.");
            }
        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            LoadData(txtName.Text);
        }
    }
}
