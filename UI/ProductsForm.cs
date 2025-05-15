using System;
using System.Linq;
using System.Windows.Forms;
using BlApi;
using BO;

namespace UI
{
    public partial class ProductsForm : Form
    {
        private readonly IBl bl = Factory.Get();

        public ProductsForm()
        {
            InitializeComponent();
            LoadData();
        }


        private void LoadData(string filter = "")
        {
            var products = string.IsNullOrWhiteSpace(filter)
                ? bl.product.ReadAll()
                : bl.product.ReadAll(p => p.Category.ToString().Contains(filter, StringComparison.OrdinalIgnoreCase));

            dataGridView1.DataSource = products.Select(p => new { p.Barcode, p.ProductName, p.Price, p.Category }).ToList();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            bl.product.Create(new Product
            {
                Barcode = int.Parse(txtBarcode.Text),
                ProductName = txtName.Text,
                Category = (Category)Enum.Parse(typeof(Category), comboCategory.Text),
                Price = double.Parse(txtPrice.Text),
                QuantityStock = int.Parse(txtQuantity.Text)
            });
            LoadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var id = (int)dataGridView1.SelectedRows[0].Cells["Barcode"].Value;
            bl.product.Update(new Product
            {
                Barcode = id,
                ProductName = txtName.Text,
                Category = (Category)Enum.Parse(typeof(Category), comboCategory.Text),
                Price = double.Parse(txtPrice.Text),
                QuantityStock = int.Parse(txtQuantity.Text)
            });
            LoadData();
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtBarcode.Text, out int barcode))
            {
                try
                {
                    bl.product.Delete(barcode);
                    LoadData();
                    MessageBox.Show("המוצר נמחק בהצלחה.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("אירעה שגיאה בעת המחיקה: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("יש להכניס ברקוד תקני.");
            }
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            LoadData(comboCategory.Text);
        }

        private void btProductById_Click(object sender, EventArgs e)
        {
            int productCode = int.TryParse(txtBarcode.Text, out int code) ? code : -1;

            try
            {
                var product = bl.product.Read(productCode);
                dataGridView1.DataSource = new List<BO.Product> { product };
            }
            catch (Exception ex)
            {
                MessageBox.Show("המוצר לא נמצא: " + ex.Message);
                dataGridView1.DataSource = null;
            }
        }

    }
}
