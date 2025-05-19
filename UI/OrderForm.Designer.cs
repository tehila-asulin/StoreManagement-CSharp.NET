namespace PL
{
    partial class OrderForm
    {
        private System.ComponentModel.IContainer components = null;

        private ComboBox comboBoxProducts;
        private TextBox textBoxProductCode;
        private TextBox textBoxQuantity;
        private Button buttonAddByCode;
        private Button buttonAddBySelect;
        private Button buttonFinishOrder;
        private Label labelTotal;
        private Label labelCode;
        private Label labelQuantity;
        private DataGridView dataGridViewOrder;
        private TextBox textBoxCustomerCode;
        private Label labelCustomer;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            comboBoxProducts = new ComboBox();
            textBoxProductCode = new TextBox();
            textBoxQuantity = new TextBox();
            buttonAddByCode = new Button();
            buttonAddBySelect = new Button();
            buttonFinishOrder = new Button();
            labelTotal = new Label();
            labelCode = new Label();
            labelQuantity = new Label();
            dataGridViewOrder = new DataGridView();
            labelCustomer = new Label();
            textBoxCustomerCode = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrder).BeginInit();
            SuspendLayout();
            // 
            // comboBoxProducts
            // 
            comboBoxProducts.Location = new Point(20, 60);
            comboBoxProducts.Name = "comboBoxProducts";
            comboBoxProducts.Size = new Size(200, 28);
            comboBoxProducts.TabIndex = 7;
            // 
            // textBoxProductCode
            // 
            textBoxProductCode.Location = new Point(510, 71);
            textBoxProductCode.Name = "textBoxProductCode";
            textBoxProductCode.Size = new Size(100, 27);
            textBoxProductCode.TabIndex = 3;
            // 
            // textBoxQuantity
            // 
            textBoxQuantity.Location = new Point(315, 22);
            textBoxQuantity.Name = "textBoxQuantity";
            textBoxQuantity.Size = new Size(50, 27);
            textBoxQuantity.TabIndex = 5;
            // 
            // buttonAddByCode
            // 
            buttonAddByCode.Location = new Point(400, 22);
            buttonAddByCode.Name = "buttonAddByCode";
            buttonAddByCode.Size = new Size(103, 33);
            buttonAddByCode.TabIndex = 6;
            buttonAddByCode.Text = "הוסף לפי קוד";
            buttonAddByCode.Click += buttonAddByCode_Click;
            // 
            // buttonAddBySelect
            // 
            buttonAddBySelect.Location = new Point(230, 60);
            buttonAddBySelect.Name = "buttonAddBySelect";
            buttonAddBySelect.Size = new Size(120, 28);
            buttonAddBySelect.TabIndex = 8;
            buttonAddBySelect.Text = "הוסף מהרשימה";
            buttonAddBySelect.Click += buttonAddBySelect_Click;
            // 
            // buttonFinishOrder
            // 
            buttonFinishOrder.Location = new Point(400, 310);
            buttonFinishOrder.Name = "buttonFinishOrder";
            buttonFinishOrder.Size = new Size(120, 30);
            buttonFinishOrder.TabIndex = 11;
            buttonFinishOrder.Text = "סיים הזמנה";
            buttonFinishOrder.Click += buttonFinishOrder_Click;
            // 
            // labelTotal
            // 
            labelTotal.Location = new Point(20, 310);
            labelTotal.Name = "labelTotal";
            labelTotal.Size = new Size(300, 23);
            labelTotal.TabIndex = 10;
            labelTotal.Text = "סה\"כ לתשלום: 0 ₪";
            // 
            // labelCode
            // 
            labelCode.Location = new Point(383, 74);
            labelCode.Name = "labelCode";
            labelCode.Size = new Size(100, 23);
            labelCode.TabIndex = 2;
            labelCode.Text = "קוד מוצר:";
            // 
            // labelQuantity
            // 
            labelQuantity.Location = new Point(259, 20);
            labelQuantity.Name = "labelQuantity";
            labelQuantity.Size = new Size(50, 23);
            labelQuantity.TabIndex = 4;
            labelQuantity.Text = "כמות:";
            // 
            // dataGridViewOrder
            // 
            dataGridViewOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewOrder.ColumnHeadersHeight = 29;
            dataGridViewOrder.Location = new Point(20, 100);
            dataGridViewOrder.Name = "dataGridViewOrder";
            dataGridViewOrder.ReadOnly = true;
            dataGridViewOrder.RowHeadersWidth = 51;
            dataGridViewOrder.Size = new Size(500, 200);
            dataGridViewOrder.TabIndex = 9;
            // 
            // labelCustomer
            // 
            labelCustomer.Location = new Point(12, 24);
            labelCustomer.Name = "labelCustomer";
            labelCustomer.Size = new Size(100, 23);
            labelCustomer.TabIndex = 0;
            labelCustomer.Text = "קוד לקוח:";
            // 
            // textBoxCustomerCode
            // 
            textBoxCustomerCode.Location = new Point(118, 20);
            textBoxCustomerCode.Name = "textBoxCustomerCode";
            textBoxCustomerCode.Size = new Size(100, 27);
            textBoxCustomerCode.TabIndex = 1;
            // 
            // OrderForm
            // 
            ClientSize = new Size(622, 432);
            Controls.Add(labelCustomer);
            Controls.Add(textBoxCustomerCode);
            Controls.Add(labelCode);
            Controls.Add(textBoxProductCode);
            Controls.Add(labelQuantity);
            Controls.Add(textBoxQuantity);
            Controls.Add(buttonAddByCode);
            Controls.Add(comboBoxProducts);
            Controls.Add(buttonAddBySelect);
            Controls.Add(dataGridViewOrder);
            Controls.Add(labelTotal);
            Controls.Add(buttonFinishOrder);
            Name = "OrderForm";
            Text = "קופה - הזמנה";
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrder).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}

