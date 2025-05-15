using System;
using System.Drawing.Drawing2D;
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

        private void btnUpdate_Click(object sender, EventArgs e)
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var id = (int)dataGridView1.SelectedRows[0].Cells["BarcodeSale"].Value;
            bl.sale.Delete(id);
            LoadData();
        }


    }
}
