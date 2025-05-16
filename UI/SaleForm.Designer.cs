namespace UI
{
    partial class SalesForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dataGridView1;
        private TextBox txtBarcode;
        private TextBox txtProductId;
        private TextBox txtQuantity;
        private TextBox txtTotal;
        private CheckBox chkClub;
        private DateTimePicker dtStart;
        private DateTimePicker dtEnd;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;

        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            txtBarcode = new TextBox();
            txtProductId = new TextBox();
            txtQuantity = new TextBox();
            txtTotal = new TextBox();
            chkClub = new CheckBox();
            dtStart = new DateTimePicker();
            dtEnd = new DateTimePicker();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            buttonFilter = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeight = 29;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(600, 200);
            dataGridView1.TabIndex = 0;
            // 
            // txtBarcode
            // 
            txtBarcode.Location = new Point(12, 246);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.Size = new Size(100, 27);
            txtBarcode.TabIndex = 1;
            // 
            // txtProductId
            // 
            txtProductId.Location = new Point(118, 246);
            txtProductId.Name = "txtProductId";
            txtProductId.Size = new Size(100, 27);
            txtProductId.TabIndex = 2;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(227, 246);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(100, 27);
            txtQuantity.TabIndex = 3;
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(343, 246);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(100, 27);
            txtTotal.TabIndex = 4;
            // 
            // chkClub
            // 
            chkClub.Location = new Point(471, 248);
            chkClub.Name = "chkClub";
            chkClub.Size = new Size(141, 24);
            chkClub.TabIndex = 5;
            chkClub.Text = "לקוחות מועדון";
            // 
            // dtStart
            // 
            dtStart.Location = new Point(12, 315);
            dtStart.Name = "dtStart";
            dtStart.Size = new Size(200, 27);
            dtStart.TabIndex = 6;
            // 
            // dtEnd
            // 
            dtEnd.Location = new Point(227, 315);
            dtEnd.Name = "dtEnd";
            dtEnd.Size = new Size(200, 27);
            dtEnd.TabIndex = 7;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(12, 376);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 32);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "הוסף";
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(93, 376);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 32);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "עדכן";
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(174, 376);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 32);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "מחק";
            btnDelete.Click += btnDelete_Click;
            // 
            // buttonFilter
            // 
            buttonFilter.Location = new Point(262, 379);
            buttonFilter.Name = "buttonFilter";
            buttonFilter.Size = new Size(192, 29);
            buttonFilter.TabIndex = 11;
            buttonFilter.Text = "סנן לפי תאריך סיום מבצע";
            buttonFilter.UseVisualStyleBackColor = true;
            buttonFilter.Click += buttonFilter_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 223);
            label1.Name = "label1";
            label1.Size = new Size(30, 20);
            label1.TabIndex = 12;
            label1.Text = "קוד";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(37, 292);
            label2.Name = "label2";
            label2.Size = new Size(139, 20);
            label2.TabIndex = 13;
            label2.Text = "תאריך תחילת מבצע";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(262, 292);
            label3.Name = "label3";
            label3.Size = new Size(123, 20);
            label3.TabIndex = 14;
            label3.Text = "תאריך סיום מבצע";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(367, 223);
            label4.Name = "label4";
            label4.Size = new Size(41, 20);
            label4.TabIndex = 15;
            label4.Text = "מחיר";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(240, 224);
            label5.Name = "label5";
            label5.Size = new Size(87, 20);
            label5.TabIndex = 16;
            label5.Text = "כמות במלאי";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(128, 224);
            label6.Name = "label6";
            label6.Size = new Size(65, 20);
            label6.TabIndex = 17;
            label6.Text = "קוד מוצר";
            // 
            // button1
            // 
            button1.Location = new Point(460, 378);
            button1.Name = "button1";
            button1.Size = new Size(137, 29);
            button1.TabIndex = 18;
            button1.Text = "הצג מבצע לפי קוד";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(601, 378);
            button2.Name = "button2";
            button2.Size = new Size(176, 29);
            button2.TabIndex = 19;
            button2.Text = "הצג את כל המבצעים";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // SalesForm
            // 
            ClientSize = new Size(789, 420);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(buttonFilter);
            Controls.Add(dataGridView1);
            Controls.Add(txtBarcode);
            Controls.Add(txtProductId);
            Controls.Add(txtQuantity);
            Controls.Add(txtTotal);
            Controls.Add(chkClub);
            Controls.Add(dtStart);
            Controls.Add(dtEnd);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Name = "SalesForm";
            Text = "ניהול מבצעים";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Button buttonFilter;
        private void buttonFilter_Click(object sender, EventArgs e)
        {
            LoadData(DateTime.Now);
        }

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button button1;
        private Button button2;
    }


}
