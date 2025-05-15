namespace UI
{
    partial class MainForm
    {
        private Button btnAdmin;
        private Button btnCashier;

        private void InitializeComponent()
        {
            this.btnAdmin = new Button();
            this.btnCashier = new Button();
            this.SuspendLayout();

            this.btnAdmin.Text = "מנהל";
            this.btnAdmin.Location = new System.Drawing.Point(50, 30);
            this.btnAdmin.Size = new System.Drawing.Size(100, 40);
            this.btnAdmin.Click += new EventHandler(this.btnAdmin_Click);

            this.btnCashier.Text = "קופאי";
            this.btnCashier.Location = new System.Drawing.Point(200, 30);
            this.btnCashier.Size = new System.Drawing.Size(100, 40);
            this.btnCashier.Click += new EventHandler(this.btnCashier_Click);

            this.ClientSize = new System.Drawing.Size(400, 120);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.btnCashier);
            this.Text = "מסך פתיחה";
            this.ResumeLayout(false);
        }
    }
}