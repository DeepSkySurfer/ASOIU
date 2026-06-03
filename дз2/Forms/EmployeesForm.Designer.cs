namespace ДЗ3_6.Forms
{
    partial class EmployeesForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.lblId = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblSalary = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cmbPosition = new System.Windows.Forms.ComboBox();
            this.txtSalary = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            this.SuspendLayout();

            // dgvEmployees
            this.dgvEmployees.AllowUserToAddRows = false;
            this.dgvEmployees.AllowUserToDeleteRows = false;
            this.dgvEmployees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEmployees.Location = new System.Drawing.Point(12, 12);
            this.dgvEmployees.MultiSelect = false;
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.ReadOnly = true;
            this.dgvEmployees.RowHeadersVisible = false;
            this.dgvEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployees.Size = new System.Drawing.Size(660, 300);
            this.dgvEmployees.TabIndex = 0;
            this.dgvEmployees.SelectionChanged += new System.EventHandler(this.dgvEmployees_SelectionChanged);

            // lblId
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(12, 330);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(27, 20);
            this.lblId.TabIndex = 1;
            this.lblId.Text = "ID:";

            // lblName
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 365);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(51, 20);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "ФИО:";

            // lblPosition
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(300, 330);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(86, 20);
            this.lblPosition.TabIndex = 3;
            this.lblPosition.Text = "Должность:";

            // lblSalary
            this.lblSalary.AutoSize = true;
            this.lblSalary.Location = new System.Drawing.Point(300, 365);
            this.lblSalary.Name = "lblSalary";
            this.lblSalary.Size = new System.Drawing.Size(162, 20);
            this.lblSalary.TabIndex = 4;
            this.lblSalary.Text = "Зарплата (тыс. руб.):";

            // txtId
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(80, 327);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(80, 27);
            this.txtId.TabIndex = 5;

            // txtName
            this.txtName.Location = new System.Drawing.Point(80, 362);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 27);
            this.txtName.TabIndex = 6;

            // cmbPosition
            this.cmbPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPosition.Location = new System.Drawing.Point(470, 327);
            this.cmbPosition.Name = "cmbPosition";
            this.cmbPosition.Size = new System.Drawing.Size(200, 28);
            this.cmbPosition.TabIndex = 7;

            // txtSalary
            this.txtSalary.Location = new System.Drawing.Point(470, 362);
            this.txtSalary.Name = "txtSalary";
            this.txtSalary.Size = new System.Drawing.Size(200, 27);
            this.txtSalary.TabIndex = 8;

            // btnAdd
            this.btnAdd.Location = new System.Drawing.Point(12, 410);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 35);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnSave
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(120, 410);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnDelete
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(230, 410);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 35);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(340, 410);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // EmployeesForm
            this.ClientSize = new System.Drawing.Size(784, 481);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtSalary);
            this.Controls.Add(this.cmbPosition);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblSalary);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.dgvEmployees);
            this.Name = "EmployeesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Управление работниками";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView dgvEmployees;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblSalary;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cmbPosition;
        private System.Windows.Forms.TextBox txtSalary;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
    }
}