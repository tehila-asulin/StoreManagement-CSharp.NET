using System;
using System.Linq;
using System.Windows.Forms;
using BlApi;
using BO;

namespace UI
{
    public partial class SalesForm : Form
    {
        private readonly IBl bl = Factory.Get();

        public SalesForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData(DateTime? endDateFilter = null)
        {
            var sales = bl.sale.ReadAll();

            if (endDateFilter.HasValue)
            {
                sales = sales.Where(s => s.EndSale >= endDateFilter.Value).ToList();
            }

            dataGridView1.DataSource = sales
                .Select(s => new
                {
                    s.BarcodeSale,
                    s.ProductId,
                    s.RequiredItems,
                    s.TotalPrice,
                    s.IsCustomersClub,
                    s.BeginingSale,
                    s.EndSale
                }).ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                bl.sale.Create(new Sale(
                    int.Parse(txtBarcode.Text),
                    int.Parse(txtProductId.Text),
                    int.Parse(txtQuantity.Text),
                    int.Parse(txtTotal.Text),
                    chkClub.Checked,
                    dtStart.Value,
                    dtEnd.Value));
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
                var id = int.Parse(txtBarcode.Text);
                bl.sale.Update(new Sale(
                    id,
                    int.Parse(txtProductId.Text),
                    int.Parse(txtQuantity.Text),
                    int.Parse(txtTotal.Text),
                    chkClub.Checked,
                    dtStart.Value,
                    dtEnd.Value));
                LoadData();
            }
            catch (BLIdNotExistException ex)
            {
                MessageBox.Show("המבצע לא קיים: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה בעדכון המבצע: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var id = (int)dataGridView1.SelectedRows[0].Cells["BarcodeSale"].Value;
                bl.sale.Delete(id);
                LoadData();
            }
            catch (BLIdNotExistException ex)
            {
                MessageBox.Show("לא ניתן למחוק מבצע שלא קיים: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה במחיקה: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int saleCode = int.TryParse(txtBarcode.Text, out int code) ? code : -1;

            try
            {
                var sale = bl.sale.Read(saleCode);
                dataGridView1.DataSource = new List<BO.Sale> { sale };
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

        private void button2_Click(object sender, EventArgs e)
        {
            LoadData(); 
        }
    }
}
