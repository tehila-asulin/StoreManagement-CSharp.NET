namespace UI
{
    partial class CustomersForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dataGridView1;
        private TextBox txtId;
        private TextBox txtName;
        private TextBox txtPhone;
        private TextBox txtAddress;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;


        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            txtId = new TextBox();
            txtName = new TextBox();
            txtPhone = new TextBox();
            txtAddress = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            buttonFilter = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
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
            // txtId
            // 
            txtId.Location = new Point(12, 254);
            txtId.Name = "txtId";
            txtId.Size = new Size(100, 27);
            txtId.TabIndex = 1;
            // 
            // txtName
            // 
            txtName.Location = new Point(150, 254);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 27);
            txtName.TabIndex = 2;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(289, 254);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(100, 27);
            txtPhone.TabIndex = 3;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(12, 309);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(100, 27);
            txtAddress.TabIndex = 4;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(12, 383);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 34);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "הוסף";
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(93, 383);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 34);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "עדכן";
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(175, 383);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 34);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "מחק";
            btnDelete.Click += btnDelete_Click;
            // 
            // buttonFilter
            // 
            buttonFilter.Location = new Point(289, 388);
            buttonFilter.Name = "buttonFilter";
            buttonFilter.Size = new Size(131, 29);
            buttonFilter.TabIndex = 8;
            buttonFilter.Text = "סנן לפי שם לקוח";
            buttonFilter.UseVisualStyleBackColor = true;
            buttonFilter.Click += buttonFilter_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 231);
            label1.Name = "label1";
            label1.Size = new Size(34, 20);
            label1.TabIndex = 9;
            label1.Text = "קוד ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 286);
            label2.Name = "label2";
            label2.Size = new Size(52, 20);
            label2.TabIndex = 10;
            label2.Text = "כתובת";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(308, 231);
            label3.Name = "label3";
            label3.Size = new Size(44, 20);
            label3.TabIndex = 11;
            label3.Text = "טלפון";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(165, 231);
            label4.Name = "label4";
            label4.Size = new Size(35, 20);
            label4.TabIndex = 12;
            label4.Text = "שם ";
            // 
            // CustomersForm
            // 
            ClientSize = new Size(624, 442);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(buttonFilter);
            Controls.Add(dataGridView1);
            Controls.Add(txtId);
            Controls.Add(txtName);
            Controls.Add(txtPhone);
            Controls.Add(txtAddress);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Name = "CustomersForm";
            Text = "ניהול לקוחות";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Button buttonFilter;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}
