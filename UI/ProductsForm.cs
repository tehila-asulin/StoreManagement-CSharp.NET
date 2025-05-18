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
            ModernStyleHelper.ApplyModernStyle(this);
            LoadData();
        }

        private void LoadData(string filter = "")
        {
            var products = string.IsNullOrWhiteSpace(filter)
                ? bl.product.ReadAll()
                : bl.product.ReadAll(p => p.Category.ToString().Contains(filter, StringComparison.OrdinalIgnoreCase));

            dataGridView1.DataSource = products.Select(p => new { p.Barcode, p.ProductName, p.Price, p.Category, p.QuantityStock }).ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                bl.product.Create(new Product
                {
                    ProductName = txtName.Text,
                    Category = (Category)Enum.Parse(typeof(Category), comboCategory.Text),
                    Price = double.Parse(txtPrice.Text),
                    QuantityStock = int.Parse(txtQuantity.Text)
                });
                LoadData();
            }
            catch (BLCodeExistException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtBarcode.Text, out int barcode))
                {
                    MessageBox.Show("ברקוד לא תקין");
                    return;
                }


                Product existing = bl.product.Read(barcode);
                if (existing == null)
                {
                    MessageBox.Show("המוצר לא קיים");
                    return;
                }


                if (!string.IsNullOrWhiteSpace(txtName.Text))
                    existing.ProductName = txtName.Text;

                if (!string.IsNullOrWhiteSpace(comboCategory.Text))
                    existing.Category = (Category)Enum.Parse(typeof(Category), comboCategory.Text);

                if (!string.IsNullOrWhiteSpace(txtPrice.Text))
                    existing.Price = double.Parse(txtPrice.Text);

                if (!string.IsNullOrWhiteSpace(txtQuantity.Text))
                    existing.QuantityStock = int.Parse(txtQuantity.Text);

                bl.product.Update(existing);
                LoadData();
            }
            catch (BLIdNotExistException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                catch (BLIdNotExistException ex)
                {
                    MessageBox.Show("לא ניתן למחוק מוצר שלא קיים: " + ex.Message);
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
            catch (BLIdNotExistException ex)
            {
                MessageBox.Show(ex.Message);
                dataGridView1.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ProductsForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
