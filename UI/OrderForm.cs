using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BlApi;
using BO;
using UI;

namespace PL
{
    public partial class OrderForm : Form
    {
        static readonly IBl _bl = Factory.Get();
        private Order currentOrder = new();
        private List<BO.Product> allProducts;
        private double totalPrice = 0;

        public OrderForm()
        {
            InitializeComponent();
            ModernStyleHelper.ApplyModernStyle(this);
            InitProductComboBox();
            RefreshOrderDisplay();
        }

        private void InitProductComboBox()
        {
            allProducts = _bl.product.ReadAll();
            comboBoxProducts.DataSource = allProducts;
            comboBoxProducts.DisplayMember = "ProductName";
            comboBoxProducts.ValueMember = "Barcode";
        }

        private void RefreshOrderDisplay()
        {
            dataGridViewOrder.DataSource = null;
            var display = currentOrder.ProductsInOrder.Select(p => new
            {
                p.ProductId,
                p.ProductName,
                p.AmountOfOrder,
                p.BasePrice,
                p.TotalPrice
            }).ToList();
            dataGridViewOrder.DataSource = display;

            totalPrice = currentOrder.ProductsInOrder.Sum(p => p.TotalPrice);
            labelTotal.Text = $"סה\"כ לתשלום: {totalPrice:N2} ₪";
        }

        private void buttonAddByCode_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxProductCode.Text, out int code))
            {
                try
                {
                    var product = _bl.product.Read(code);
                    int quantity = int.TryParse(textBoxQuantity.Text, out int q) && q > 0 ? q : 1;
                    int customerCode = int.TryParse(textBoxCustomerCode.Text, out int custCode) ? custCode : -1;
                    try { currentOrder.IsFevorite = _bl.customer.IsCustomerExist(customerCode); } 
                    catch (Exception exc){ }
                   
                    _bl.order.AddProductToOrder(currentOrder, product.Barcode, quantity);
                }
                catch (BLIdNotExistException ex)
                {
                    MessageBox.Show( ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void buttonAddBySelect_Click(object sender, EventArgs e)
        {
            if (comboBoxProducts.SelectedItem is BO.Product product)
            {
                try
                {
                    int quantity = int.TryParse(textBoxQuantity.Text, out int q) && q > 0 ? q : 1;
                    int customerCode = int.TryParse(textBoxCustomerCode.Text, out int code) ? code : -1;
                    try { currentOrder.IsFevorite = _bl.customer.IsCustomerExist(customerCode); }
                    catch (Exception exc) { }
                    _bl.order.AddProductToOrder(currentOrder, product.Barcode, quantity);
                    RefreshOrderDisplay();
                }
                catch (BLIdNotExistException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show( ex.Message);
                }
            }
            else
            {
                MessageBox.Show("לא נבחר מוצר.");
            }
        }

        private void buttonFinishOrder_Click(object sender, EventArgs e)
        {
            try
            {
                _bl.order.DoOrder(currentOrder);
                MessageBox.Show("ההזמנה בוצעה בהצלחה!");
                currentOrder = new();
                RefreshOrderDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message);
            }
        }
    }
}
