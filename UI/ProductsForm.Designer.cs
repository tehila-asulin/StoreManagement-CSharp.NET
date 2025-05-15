using BO;
namespace UI
{
    partial class ProductsForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dataGridView1;
        private TextBox txtBarcode;
        private TextBox txtName;
        private ComboBox comboCategory;
        private TextBox txtPrice;
        private TextBox txtQuantity;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnFilter;

        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            txtBarcode = new TextBox();
            txtName = new TextBox();
            comboCategory = new ComboBox();
            txtPrice = new TextBox();
            txtQuantity = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            buttonFilter = new Button();
            btProductById = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeight = 29;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(460, 200);
            dataGridView1.TabIndex = 0;
            // 
            // txtBarcode
            // 
            txtBarcode.Location = new Point(12, 250);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.Size = new Size(100, 27);
            txtBarcode.TabIndex = 1;
            // 
            // txtName
            // 
            txtName.Location = new Point(150, 250);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 27);
            txtName.TabIndex = 2;
            // 
            // comboCategory
            // 
            comboCategory.Items.AddRange(new object[] { "Milky", "Cleanliness", "Sweets", "Breads", "FruitVegetables" });
            comboCategory.Location = new Point(304, 250);
            comboCategory.Name = "comboCategory";
            comboCategory.Size = new Size(121, 28);
            comboCategory.TabIndex = 3;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(12, 299);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(100, 27);
            txtPrice.TabIndex = 4;
            txtPrice.TextChanged += txtPrice_TextChanged;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(150, 299);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(100, 27);
            txtQuantity.TabIndex = 5;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(0, 343);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 34);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "הוסף";
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(81, 343);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 34);
            btnUpdate.TabIndex = 7;
            btnUpdate.Text = "עדכן";
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(175, 343);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 34);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "מחק";
            btnDelete.Click += btnDelete_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 227);
            label1.Name = "label1";
            label1.Size = new Size(47, 20);
            label1.TabIndex = 9;
            label1.Text = "ברקוד";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(161, 227);
            label2.Name = "label2";
            label2.Size = new Size(66, 20);
            label2.TabIndex = 10;
            label2.Text = "שם מוצר";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(34, 276);
            label3.Name = "label3";
            label3.Size = new Size(41, 20);
            label3.TabIndex = 11;
            label3.Text = "מחיר";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(150, 276);
            label4.Name = "label4";
            label4.Size = new Size(87, 20);
            label4.TabIndex = 12;
            label4.Text = "כמות במלאי";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(288, 226);
            label5.Name = "label5";
            label5.Size = new Size(137, 20);
            label5.TabIndex = 13;
            label5.Text = "בחר קטוגוריית מוצר";
            // 
            // buttonFilter
            // 
            buttonFilter.Location = new Point(304, 299);
            buttonFilter.Name = "buttonFilter";
            buttonFilter.Size = new Size(121, 29);
            buttonFilter.TabIndex = 14;
            buttonFilter.Text = "סנן לפי קטגוריה";
            buttonFilter.UseVisualStyleBackColor = true;
            buttonFilter.Click += buttonFilter_Click;
            // 
            // btProductById
            // 
            btProductById.Location = new Point(256, 343);
            btProductById.Name = "btProductById";
            btProductById.Size = new Size(154, 29);
            btProductById.TabIndex = 15;
            btProductById.Text = "הצג מוצר לפי ברקוד";
            btProductById.UseVisualStyleBackColor = true;
            btProductById.Click += btProductById_Click;
            // 
            // ProductsForm
            // 
            ClientSize = new Size(535, 378);
            Controls.Add(btProductById);
            Controls.Add(buttonFilter);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(txtBarcode);
            Controls.Add(txtName);
            Controls.Add(comboCategory);
            Controls.Add(txtPrice);
            Controls.Add(txtQuantity);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Name = "ProductsForm";
            Text = "ניהול מוצרים";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button buttonFilter;
        private Button btProductById;
    }
}
